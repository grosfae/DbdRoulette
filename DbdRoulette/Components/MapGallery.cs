using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("MapGallery")]
    public class MapGallery
    {
        public int Id { get; set; }
        public byte[] Screenshot { get; set; }
        public int MapId { get; set; }
        public virtual Map Map { get; set; }
    }
}
