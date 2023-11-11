using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("Map")]
    public class Map
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ChapterId { get; set; }
        public virtual Chapter Chapter { get; set; }
        public virtual ICollection<MapGallery> MapGallery { get; set; }
    }
}
