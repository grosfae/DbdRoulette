using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("AddonEffect")]
    public class AddonEffect
    {
        public int Id { get; set; }
        public int AddonId { get; set; }
        public int EffectId { get; set; }
        public virtual Addon Addon { get; set; }
        public virtual Effect Effect { get; set; }
    }
}
