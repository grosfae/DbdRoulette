using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("ChapterCharm")]
    public class ChapterCharm
    {
        public int Id { get; set; }
        public int ChapterId { get; set; }
        public virtual Chapter Chapter { get; set; }
        public int CharmId { get; set; }
        public virtual Charm Charm { get; set; }
    }
}
