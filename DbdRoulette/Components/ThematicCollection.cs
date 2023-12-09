using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("ThematicCollection")]
    public class ThematicCollection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ItemThematicCollection> ItemThematicCollection { get; set; }
    }
}
