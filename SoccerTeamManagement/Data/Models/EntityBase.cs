using SoccerTeamManagement.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Data.Models
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
    }
}