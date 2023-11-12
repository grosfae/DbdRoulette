using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("KillerCosmeticOutfit")]
    public class KillerCosmeticOutfit
    {
        public int Id { get; set; }
        public int KillerId { get; set; }
        public virtual Killer Killer { get; set; }
        public int CosmeticOutfitId { get; set; }
        public virtual CosmeticOutfit CosmeticOutfit { get; set; }
    }
}
