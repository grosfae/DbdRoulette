using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        public string Quote { get; set; }
        public byte[] MainIcon { get; set; }
        public byte[] DemoImage { get; set; }
        public int PerkTypeId { get; set; }
        public virtual PerkType PerkType { get; set; }
        public virtual ICollection<SurvivorPerk> SurvivorPerk { get; set; }
        public virtual ICollection<KillerPerk> KillerPerk { get; set; }
        public virtual ICollection<PerkEffect> PerkEffect { get; set; }
        public string PerkBorderColor
        {
            get
            {
                if (KillerPerk.Count > 0)
                {
                    return "#FFAA1A18";
                }
                else
                {
                    return "#3881EF";
                }
            }
        }
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

        public string HazeCloud
        {
            get
            {
                return "pack://application:,,,/DbdRoulette;component/Resources/ColorHazes/VeryRareHaze.png";
            }
        }
        public Visibility ShowEffect
        {
            get
            {
                if (PerkEffect.Count > 0)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }
        public Visibility ShowQuote
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Quote))
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }

    }
}
