using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("Item")]
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] MainIcon { get; set; }
        public int RarityId { get; set; }
        public virtual Rarity Rarity { get; set; }
        public virtual ICollection<PowerItem> PowerItem { get; set; }

    }
}
