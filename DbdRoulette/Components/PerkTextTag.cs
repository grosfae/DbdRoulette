using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("PerkTextTag")]
    public class PerkTextTag
    {
        public int Id { get; set; }
        public int PerkId { get; set; }
        public int TextTagId { get; set; }
        public virtual Perk Perk { get; set; }
        public virtual TextTag TextTag { get; set; }
    }
}
