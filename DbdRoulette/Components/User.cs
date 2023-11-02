using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PieValue { get; set; }

    }
}
