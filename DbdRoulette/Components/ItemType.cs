using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("ItemType")]
    public class ItemType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quote { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<Addon> Addon { get; set; }

        public string UpperName
        {
            get
            {
                return Name.ToUpper();
            }
        }
        public string Color
        {
            get
            {
                if (Id == 3)
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
                    return "#FF654D3B";
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

    }
}
