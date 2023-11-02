using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("ChapterType")]
    public class ChapterType
    {
        public int Id { get; set; }
        public string Name {get; set; }
        public virtual ICollection<Chapter> Chapter { get; set; }

    }
}
