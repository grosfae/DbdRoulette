using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("PerkEffect")]
    public class PerkEffect
    {
        public int Id { get; set; }
        public int PerkId { get; set; }
        public int EffectId { get; set; }
        public virtual Perk Perk { get; set; }
        public virtual Effect Effect { get; set; }
    }
}
