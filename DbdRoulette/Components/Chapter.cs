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
    [Table("Chapter")]
    public class Chapter
    {
        public int Id { get; set; }
        public string Name {get; set; }
        public string DateRelease {get; set; }
        public string Description {get; set; }
        public int ChapterTypeId {get; set; }
        public byte[] MainImage {get; set; }
        public virtual ChapterType ChapterType { get; set; }

        public virtual ICollection<KillerChapter> KillerChapter { get; set; }
    }
}
