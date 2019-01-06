namespace CqrsApp.ReadModel.EFContext
{
    using CqrsApp.ReadModel.Entities;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<CqrsApp.ReadModel.Concrete.EFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"EFContext";
        }

        protected override void Seed(CqrsApp.ReadModel.Concrete.EFContext context)
        {
            var teamId = Guid.NewGuid();
            var team2Id = Guid.NewGuid();

            Player player = new Player()
            {
                Id = Guid.NewGuid(),
                Age = 29,
                Name = "Lionel",
                Surname = "Messi",
                PlayerNumber = 10,
                ImageUrl = "/Content/img/messi.jpg",
                Country = "Argentina",
                DayBirth = new System.DateTime(1987 , 06 , 24)
            };
            Player player2 = new Player()
            {
                Id = Guid.NewGuid(),
                Age = 31,
                Name = "Cristiano",
                Surname = "Ronaldo",
                PlayerNumber = 7,
                ImageUrl = "/Content/img/ronaldo.jpg",
                Country = "Portugal",
                DayBirth = new System.DateTime(1985 , 02 , 05)
            };
            context.Players.Add(player);
            context.Players.Add(player2);


            Team team = new Team()
            {
                Id = teamId,
                Name = "Barcelona",
                ImageUrl = "/Content/img/barcelona.jpg"
            };
            Team team2 = new Team()
            {
                Id = team2Id,
                Name = "Real Madrid",
                ImageUrl = "/Content/img/realmadrid.jpg"
            };

            team.Players.Add(player);
            team2.Players.Add(player2);

            context.Teams.Add(team);
            context.Teams.Add(team2);
        }
    }
}
