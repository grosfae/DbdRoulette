using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("SurvivorPerk")]
    public class SurvivorPerk
    {
        public int Id { get; set; }
        public int SurvivorId { get; set; }
        public int PerkId { get; set; }
        public virtual Survivor Survivor { get; set; }
        public virtual Perk Perk { get; set; }
    }
}
