using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("Power")]
    public class Power
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] MainIcon { get; set; }
        public byte[] DemoImage { get; set; }
        public string Range { get; set; }
        public string Count { get; set; }
        public virtual ICollection<Killer> Killer { get; set; }
        public virtual ICollection<PowerItem> PowerItem { get; set; }
    }
}
