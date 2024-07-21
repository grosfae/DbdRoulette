using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("RouletteResult")]
    public class RouletteResult
    {
        public int Id { get; set; }
        public string RouletteName { get; set; }
        public DateTime RollDate { get; set; }
        public string Result { get; set; }

    }
}
