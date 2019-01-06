using CqrsApp.ReadModel.Entities;
using CqrsApp.ReadModel.Interfaces;
using System;
using System.Linq;

namespace CqrsApp.ReadModel.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly Concrete.EFContext context = new Concrete.EFContext();

        public IQueryable<Team> Entities => context.Teams;

        public void Delete(Guid id)
        {
            var entity = context.Teams.Find(id);
            if(entity != null)
            {
                context.Teams.Remove(entity);
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Save(Team team)
        {
            Team entity = context.Teams.Find(team.Id);
            team.Name = entity.Name;
            entity.ImageUrl = entity.ImageUrl;
            context.SaveChanges();
        }
    }
}
