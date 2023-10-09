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
    [Table("Chapter")]
    public class Chapter : INotifyPropertyChanged
    {
        private string name;

        private string dateRelease;

        private string description;

        private int chapterTypeId;

        public virtual ChapterType ChapterType { get; set; }

        public virtual ICollection<KillerChapter> KillerChapter { get; set; }

        private byte[] mainImage;

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

        public string DateRelease
        {
            get { return dateRelease; }
            set
            {
                dateRelease = value;
                OnPropertyChanged("DateRelease");
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public int ChapterTypeId
        {
            get { return chapterTypeId; }
            set
            {
                chapterTypeId = value;
                OnPropertyChanged("ChapterTypeId");
            }
        }

        public byte[] MainImage
        {
            get { return mainImage; }
            set
            {
                mainImage = value;
                OnPropertyChanged("MainImage");
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
