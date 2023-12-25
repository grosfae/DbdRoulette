using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("Effect")]
    public class Effect
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Quote { get; set; }
        public byte[] MainIcon { get; set; }
        public bool IsBuff { get; set; }
        public virtual ICollection<PerkEffect> PerkEffect { get; set; }
        public virtual ICollection<AddonEffect> AddonEffect { get; set; }
    }
}
