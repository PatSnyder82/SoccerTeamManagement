using SoccerTeamManagement.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerTeamManagement.Data.Models
{
    public class AuditableEntityBase : EntityBase, IArchivable, ICreatable, IDeletable, IUpdatable
    {
        public string ArchivedBy { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset? DateArchived { get; set; }

        public DateTimeOffset? DateCreated { get; set; }

        public DateTimeOffset? DateDeleted { get; set; }

        public DateTimeOffset? DateUpdated { get; set; }

        public string DeletedBy { get; set; }

        public string UpdatedBy { get; set; }
    }
}