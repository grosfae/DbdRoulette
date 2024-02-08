using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("PowerAddon")]
    public class PowerAddon
    {
        public int Id { get; set; }
        public int AddonId { get; set; }
        public int PowerId { get; set; }
        public virtual Addon Addon { get; set; }
        public virtual Power Power { get; set; }
    }
}
