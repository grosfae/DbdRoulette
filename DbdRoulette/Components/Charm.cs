using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("Charm")]
    public class Charm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] MainIcon { get; set; }
        public string UnlockCondition { get; set; }
        public int RarityId { get; set; }
        public virtual Rarity Rarity { get; set; }
        public int CosmeticTypeId { get; set; }
        public virtual CosmeticType CosmeticType { get; set; }
        public int CharmTypeId { get; set; }
        public virtual CharmType CharmType { get; set; }
        public virtual ICollection<ChapterCharm> ChapterCharm { get; set; }
    }
}
