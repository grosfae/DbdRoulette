using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DbdRoulette.Components
{
    [Table("Addon")]
    public class Addon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Quote { get; set; }
        public byte[] MainIcon { get; set; }
        public int RarityId { get; set; }
        public Nullable<int> ThematicCollectionId { get; set; }
        public int ItemTypeId { get; set; }
        public virtual Rarity Rarity { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual ThematicCollection ThematicCollection { get; set; }
        public virtual ICollection<AddonEffect> AddonEffect { get; set; }
        public virtual ICollection<PowerAddon> PowerAddon { get; set; }
        public string UpperName
        {
            get
            {
                return Name.ToUpper();
            }
        }
        public string SignatureText
        {
            get
            {
                return $"{Rarity.UpperName} - {ItemType.UpperName} - УЛУЧШЕНИЕ";
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
        public Visibility ShowEffect
        {
            get
            {
                if (AddonEffect.Count > 0)
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
