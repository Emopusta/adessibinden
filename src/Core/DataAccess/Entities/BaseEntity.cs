using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Entities
{
    public class BaseEntity<TId> : IEntityDates
    {
        public TId Id { get; set; }
        public DateOnly CreatedDate { get; set; }
        public DateOnly? UpdatedDate { get; set; }
        public DateOnly? DeletedDate { get; set; }

    }
}
