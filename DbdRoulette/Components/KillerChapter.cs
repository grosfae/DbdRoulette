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
    public class KillerChapter : INotifyPropertyChanged
    {

        private int killerId;

        private int chapterId;

        public virtual Chapter Сhapter { get; set; }

        public virtual Killer Killer { get; set; }

        public int Id { get; set; }

        public int KillerId
        {
            get { return killerId; }
            set
            {
                killerId = value;
                OnPropertyChanged("KillerId");
            }
        }

        public int ChapterId
        {
            get { return chapterId; }
            set
            {
                chapterId = value;
                OnPropertyChanged("ChapterId");
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
