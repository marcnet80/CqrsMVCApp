using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CqrsApp.ReadModel.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
