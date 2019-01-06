using AutoMapper;
using CqrsApp.Domain.Commands;
using CqrsApp.Models;
using CqrsApp.ReadModel.Entities;
using CqrsApp.ReadModel.Interfaces;
using CqrsApp.ReadModel.Repositories;
using SimpleCqrs;
using SimpleCqrs.Commanding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CqrsApp.Controllers
{
    public class PlayerController : Controller
    {
        private const string ImgServerPath = "/Content/img/";
        private const int PageSize = 3;

        private readonly ICommandBus CommandBus;
        private readonly IPlayerRepository playerRepository;
        private readonly ITeamRepository teamRepository;
        public PlayerController() : this(ServiceLocator.Current.Resolve<ICommandBus>(), new PlayerRepository(), new TeamRepository())
        {
        }

        public PlayerController(ICommandBus CommandBus, IPlayerRepository playerRepository, ITeamRepository teamRepository)
        {
            this.CommandBus = CommandBus;
            this.playerRepository = playerRepository;
            this.teamRepository = teamRepository;
        }

        public ActionResult Index(int page = 1)
        {
            ViewBag.TotalPlayersCount = (playerRepository.Entities.Count() / PageSize);
            return View(playerRepository.Entities
                .OrderBy(x => x.Name)
                .Skip((page - 1) * PageSize).Take(PageSize).ToList());
        }

        private void InitializeTeams()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Player, PlayerViewModel>());
            var teams = new List<SelectListItem>() {
                new SelectListItem { Text = "Select team", Value = "Null" }
            };
            var listItems = (from team in teamRepository.Entities
                             select new SelectListItem { Text = team.Name, Value = team.Id.ToString() }).ToList();
            teams.AddRange(listItems);
            ViewData["AllTeams"] = teams;
        }

        public ActionResult Edit(Guid? id)
        {
            Player player = playerRepository.Entities.FirstOrDefault(p => p.Id == id);
            if (player != null)
            {
                InitializeTeams();

                PlayerViewModel playerModel = Mapper.Map<Player, PlayerViewModel>(player);
                playerModel.PlayerId = id.Value;
                playerModel.IsEdit = true;
                return View(playerModel);
            }
            return View(new PlayerViewModel());
        }

        [HttpPost]
        public ActionResult Edit(PlayerViewModel player, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string fileName = string.Empty;
                if (file != null)
                {
                    fileName = Path.GetFileName(file.FileName);
                    var filePath = Path.Combine(Server.MapPath("~" + ImgServerPath), fileName);
                    file.SaveAs(filePath);
                }
                if (!player.IsEdit)
                    CommandBus.Send(new CreatePlayerCommand(player.PlayerNumber, player.Name, player.Surname, player.Age, player.Country, player.DayBirth, !string.IsNullOrEmpty(fileName) ? ImgServerPath + fileName : player.ImageUrl, player.TeamId));
                else
                    CommandBus.Send(new UpdatePlayerCommand(player.PlayerId, player.PlayerNumber, player.Name, player.Surname, player.Age, player.Country, player.DayBirth, !string.IsNullOrEmpty(fileName) ? ImgServerPath + fileName : player.ImageUrl, player.TeamId));
            }
            else
            {
                InitializeTeams();
                return View(player);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            InitializeTeams();

            return View("Edit", new PlayerViewModel());
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                Response.Write("Null id!");
                return RedirectToAction("Index");
            }
            Player player = playerRepository.Entities.FirstOrDefault(p => p.Id == id);
            return View(player);
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            CommandBus.Send(new DeletePlayerCommand(id));
            return RedirectToAction("Index");
        }
    }
}