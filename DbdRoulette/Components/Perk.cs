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
        public string EngName { get; set; }
        public int PieValue { get; set; }
        public string Description { get; set; }
        public byte[] MainIcon { get; set; }
        public byte[] DemoImage { get; set; }
        public virtual ICollection<PerkTextTag> PerkTextTag { get; set; }
        public virtual ICollection<SurvivorPerk> SurvivorPerk { get; set; }
        public virtual ICollection<KillerPerk> KillerPerk { get; set; }

        public string OwnerName
        {
            get
            {
                var killerPerk = KillerPerk.FirstOrDefault();
                var survivorPerk = SurvivorPerk.FirstOrDefault();

                if(killerPerk != null)
                {
                    return killerPerk.Killer.Name.ToUpper();
                }
                else if (survivorPerk != null)
                {
                    return survivorPerk.Survivor.Name.ToUpper();
                }
                else
                {
                    return "ОБЩИЙ";
                }
            }
        }

        public string PerkUpperName
        {
            get
            {
                return Name.ToUpper();
            }
        }

    }
}
