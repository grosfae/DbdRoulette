using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace DbdRoulette.Components
{
    [Table("Killer")]
    public class Killer : INotifyPropertyChanged
    {
        private string name;

        private int pieValue;

        private byte[] mainImage;

        public virtual ICollection<KillerChapter> KillerChapter { get; set; }

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

        public byte[] MainImage
        {
            get { return mainImage; }
            set
            {
                mainImage = value;
                OnPropertyChanged("MainImage");
            }
        }


        public string ShadowColor
        {
            get
            {
                var killerChapter = App.DB.KillerChapters.FirstOrDefault(x => x.KillerId == Id);
                if (killerChapter != null)
                {
                    if (killerChapter.Сhapter.ChapterType.Id == 1)
                    {
                        return "#FFB5873C";
                    }
                    if (killerChapter.Сhapter.ChapterType.Id == 2)
                    {
                        return "#FF6C6358";
                    }
                    if (killerChapter.Сhapter.ChapterType.Id == 3)
                    {
                        return "#FFC50000";
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
        }

        public string BackgroundMetal
        {
            get
            {
                var killerChapter = App.DB.KillerChapters.FirstOrDefault(x => x.KillerId == Id);
                if (killerChapter != null)
                {
                    if (killerChapter.Сhapter.ChapterType.Id == 1)
                    {
                        return "pack://application:,,,/DbdRoulette;component/Resources/Misc/Gold.jpg";
                    }
                    if (killerChapter.Сhapter.ChapterType.Id == 2)
                    {
                        return "pack://application:,,,/DbdRoulette;component/Resources/Misc/Metal.jpg";
                    }
                    if (killerChapter.Сhapter.ChapterType.Id == 3)
                    {
                        return "pack://application:,,,/DbdRoulette;component/Resources/Misc/RedMetal.jpg";
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
        }
        
        public string Symbol
        {
            get
            {
                var killerChapter = App.DB.KillerChapters.FirstOrDefault(x => x.KillerId == Id);
                if (killerChapter != null)
                {
                    if (killerChapter.Сhapter.ChapterType.Id == 1)
                    {
                        return "";
                    }
                    if (killerChapter.Сhapter.ChapterType.Id == 2)
                    {
                        return "";
                    }
                    if (killerChapter.Сhapter.ChapterType.Id == 3)
                    {
                        return "";
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }

        }
        public string KillerType
        {
            get
            {
                var killerChapter = App.DB.KillerChapters.FirstOrDefault(x => x.KillerId == Id);
                if (killerChapter != null)
                {
                    return killerChapter.Сhapter.ChapterType.Name;
                }
                else
                {
                    return null;
                }
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
