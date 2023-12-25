using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("AddonItemType")]
    public class AddonItemType
    {
        public int Id { get; set; }
        public int AddonId { get; set; }
        public int ItemTypeId { get; set; }
        public virtual Addon Addon { get; set; }
        public virtual ItemType ItemType { get; set; }
    }
}
