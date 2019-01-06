using CqrsApp.ReadModel.Repositories;
using System.Linq;
using System.Web.Mvc;
using System;
using CqrsApp.ReadModel.Entities;
using SimpleCqrs.Commanding;
using SimpleCqrs;
using CqrsApp.ReadModel.Interfaces;
using CqrsApp.Domain.Commands;

namespace CqrsApp.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamRepository teamRepository;
        private readonly ICommandBus CommandBus;

        public TeamController() : this(ServiceLocator.Current.Resolve<ICommandBus>(), new TeamRepository())
        {

        }

        public TeamController(ICommandBus CommandBus, ITeamRepository teamRepository)
        {
            this.CommandBus = CommandBus;
            this.teamRepository = teamRepository;
        }

        // GET: Team
        public ActionResult Index()
        {
            return View("Index", teamRepository.Entities.ToList());
        }

        public ActionResult Edit(Guid? id)
        {
            if (!id.HasValue || id == Guid.Empty)
            {
                return View("Edit", new Team() { Id = Guid.Empty });
            }
            var team = this.teamRepository.Entities.FirstOrDefault(t => t.Id == id);
            return View(team);
        }

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                if (team.Id == Guid.Empty)
                {
                    CommandBus.Send(new CreateTeamCommand(team.Name, team.ImageUrl));
                }
                else
                {
                    CommandBus.Send(new UpdateTeamCommand(team.Id, team.Name, team.ImageUrl));
                }
                return RedirectToAction("Index");
            }
            return View(team);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null) {
                Response.Write("Null id!");
                return RedirectToAction("Index");
            }
            var team = teamRepository.Entities.FirstOrDefault(p => p.Id == id);
            return View(team);
        }

        [HttpPost]
        public ActionResult Delete(Guid id)
        {
            CommandBus.Send(new DeleteTeamCommand(id));
            return RedirectToAction("Index");
        }
    }
}