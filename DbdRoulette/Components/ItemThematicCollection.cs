using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("ItemThematicCollection")]
    public class ItemThematicCollection
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int ThematicCollectionId { get; set; }
        public virtual Item Item { get; set; }
        public virtual ThematicCollection ThematicCollection { get; set; }

    }
}
