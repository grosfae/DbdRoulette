using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("CosmeticOutfit")]
    public class CosmeticOutfit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] MainIcon { get; set; }
        public bool IsExclusive { get; set; }
        public int RarityId { get; set; }
        public virtual Rarity Rarity { get; set; }
        public int BodyPartId { get; set; }
        public virtual BodyPart BodyPart { get; set; }
        public int CosmeticTypeId { get; set; }
        public virtual CosmeticType CosmeticType { get; set; }
        public virtual ICollection<SurvivorCosmeticOutfit> SurvivorCosmeticOutfit { get; set; }
        public virtual ICollection<KillerCosmeticOutfit> KillerCosmeticOutfit { get; set; }

    }
}
