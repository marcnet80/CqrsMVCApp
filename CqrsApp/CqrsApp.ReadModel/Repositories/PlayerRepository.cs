using System.Linq;
using CqrsApp.ReadModel.Entities;
using CqrsApp.ReadModel.Interfaces;

namespace CqrsApp.ReadModel.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly Concrete.EFContext context = new Concrete.EFContext();

        public IQueryable<Player> Entities => context.Players;

        public void Delete(System.Guid id)
        {
            var entity = context.Teams.Find(id);
            if (entity != null)
            {
                context.Teams.Remove(entity);
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public void Save(Player entity)
        {
            var player = context.Players.Find(entity.Id);
            if (player != null)
            {
                player.Name = entity.Name;
                player.ImageUrl = entity.ImageUrl;
                context.SaveChanges();
            }
        }
    }
}
