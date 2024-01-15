using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Entities
{
    public class Entity : EntityOnlyId, IEntityTimestamps
    {
        
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

    }

    public class EntityOnlyId : BaseEntity
    {
        public int Id { get; set; }
    }

    public class BaseEntity
    {

    }

}
