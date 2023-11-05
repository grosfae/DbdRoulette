using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("KillerPerk")]
    public class KillerPerk
    {
        public int Id { get; set; }
        public int KillerId { get; set; }
        public int PerkId { get; set; }
        public virtual Killer Killer { get; set; }
        public virtual Perk Perk { get; set; }
    }
}
