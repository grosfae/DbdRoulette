using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("Rarity")]
    public class Rarity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<Charm> Charm { get; set; }

        public string RarityColor
        {
            get
            {
                if (Id == 1)
                {
                    return "#FFAB5E00";
                }
                else if(Id == 2)
                {
                    return "#FFD0B607";
                }
                else if (Id == 3)
                {
                    return "#FF0F8416";
                } 
                else if (Id == 4)
                {
                    return "#FFAB00FF";
                }
                else if (Id == 5)
                {
                    return "#FFC4174B";
                }
                else if (Id == 6)
                {
                    return "#FFFF9800";
                }
                else if (Id == 7)
                {
                    return "#FFC10303";
                }
                else if (Id == 8)
                {
                    return "#FF9BA9B9";
                }
                else if (Id == 9)
                {
                    return "#FFFFA802";
                }
                else if (Id == 10)
                {
                    return "#FFEC0CBE";
                }
                else
                {
                    return "White";
                }
            }
        }

        public string UpperName
        {
            get
            {
                return Name.ToUpper();
            }
        }
        public string ColorHaze
        {
            get
            {
                if(Id == 1)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/ColorHazes/CommonHaze.png";
                }
                if (Id == 2)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/ColorHazes/UncommonHaze.png";
                }
                if (Id == 3)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/ColorHazes/RareHaze.png";
                }
                if (Id == 4)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/ColorHazes/VeryRareHaze.png";
                }
                if (Id == 5)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/ColorHazes/UltraRareHaze.png";
                }
                if (Id == 6)
                {
                    return null;
                }
                if (Id == 7)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/ColorHazes/LimitedHaze.png";
                }
                if (Id == 8)
                {
                    return null;
                }
                if (Id == 9)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/ColorHazes/EventHaze.png";
                }
                if (Id == 10)
                {
                    return null;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
