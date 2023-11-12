using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("CosmeticType")]
    public class CosmeticType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Charm> Charm { get; set; }
    }
}
