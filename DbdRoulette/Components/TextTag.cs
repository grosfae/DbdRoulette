using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("TextTag")]
    public class TextTag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TagColor { get; set; }
        public virtual ICollection<PerkTextTag> PerkTextTag { get; set; }
    }
}
