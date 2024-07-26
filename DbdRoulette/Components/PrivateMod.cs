using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("PrivateMod")]
    public class PrivateMod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] ModLogo { get; set; }
    }
}
