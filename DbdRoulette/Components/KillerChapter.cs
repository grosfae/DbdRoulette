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
    [Table("KillerChapter")]
    public class KillerChapter
    {
        public int Id { get; set; }
        public int KillerId {get; set;}
        public int ChapterId {get; set;}
        public virtual Chapter Сhapter { get; set; }
        public virtual Killer Killer { get; set; }
    }
}
