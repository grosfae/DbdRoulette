using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("SurvivorCosmeticOutfit")]
    public class SurvivorCosmeticOutfit
    {
        public int Id { get; set; }
        public int SurvivorId { get; set; }
        public virtual Survivor Survivor { get; set; }
        public int CosmeticOutfitId { get; set; }
        public virtual CosmeticOutfit CosmeticOutfit { get; set; }
    }
}
