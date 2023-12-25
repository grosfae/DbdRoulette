using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DbdRoulette.Components
{
    [Table("Item")]
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Quote { get; set; }
        public byte[] MainIcon { get; set; }
        public int RarityId { get; set; }
        public int ItemTypeId { get; set; }
        public Nullable<int> ThematicCollectionId { get; set; }
        public virtual Rarity Rarity { get; set; }
        public virtual ThematicCollection ThematicCollection { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual ICollection<PowerItem> PowerItem { get; set; }

        public string ItemUpperName
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
                return Rarity.ColorHaze;
            }
        }

        public Visibility ShowCollection
        {
            get
            {
                if (ThematicCollection != null)
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

        public Visibility ShowItemTypeQuote
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ItemType.Quote))
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
