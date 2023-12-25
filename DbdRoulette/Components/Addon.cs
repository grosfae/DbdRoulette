using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public virtual Rarity Rarity { get; set; }
        public virtual ThematicCollection ThematicCollection { get; set; }
        public virtual ICollection<AddonEffect> AddonEffect { get; set; }
        public virtual ICollection<AddonItemType> AddonItemType { get; set; }
    }
}
