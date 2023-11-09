using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("Perk")]
    public class Perk
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PieValue { get; set; }
        public string Description { get; set; }
        public byte[] MainIcon { get; set; }
        public byte[] DemoImage { get; set; }
        public int PerkTypeId { get; set; }
        public virtual PerkType PerkType { get; set; }
        public virtual ICollection<SurvivorPerk> SurvivorPerk { get; set; }
        public virtual ICollection<KillerPerk> KillerPerk { get; set; }

        public string PerkBorderColor
        {
            get
            {
                if(PerkTypeId == 1)
                {
                    return "#FFAA1A18";
                }
                else
                {
                    return "#3881EF";
                }
            }
        }
    }
}
