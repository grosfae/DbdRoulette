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
    public class User : INotifyPropertyChanged
    {
        private string name;

        private int pieValue;

        public int Id { get; set; }

        public string Name
        {
            get { return name; }
            set 
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public int PieValue
        {
            get { return pieValue; }
            set
            {
                pieValue = value;
                OnPropertyChanged("PieValue");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")

        {

            if (PropertyChanged != null)

                PropertyChanged(this, new PropertyChangedEventArgs(prop));

        }
    }
}
