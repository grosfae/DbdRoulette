using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DbdRoulette.Components
{
    [Table("Power")]
    public class Power
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Quote { get; set; }
        public byte[] MainIcon { get; set; }
        public byte[] DemoImage { get; set; }
        public string Range { get; set; }
        public string Count { get; set; }
        public virtual ICollection<Killer> Killer { get; set; }
        public virtual ICollection<PowerItem> PowerItem { get; set; }

        public string OwnerName
        {
            get
            {
                var killer = Killer.FirstOrDefault();
                if (killer != null)
                {
                    return killer.Name.ToUpper();
                }
                else
                {
                    return "НЕИЗВЕСТНО";
                }
            }
        }
    }
}
