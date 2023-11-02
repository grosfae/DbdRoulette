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
    public class Killer
    {
        public int Id { get; set; }

        public string Name {get; set; }

        public int PieValue { get; set; }

        public string Description { get; set; }

        public string Lore { get; set; }

        public byte[] MainImage { get; set; }

        public virtual ICollection<KillerChapter> KillerChapter { get; set; }

        public string DiaryLetter { get; set; }
        public string ShortLetter
        {
            get
            {
                if (DiaryLetter.Length >= 130)
                {
                    return $"{DiaryLetter.Substring(0, 130)}...";
                }
                else
                {
                    return $"{DiaryLetter}...";
                }
            }
        }

        public string ShadowColor
        {
            get
            {
                var killerChapter = App.DB.KillerChapter.FirstOrDefault(x => x.KillerId == Id);
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
                var killerChapter = App.DB.KillerChapter.FirstOrDefault(x => x.KillerId == Id);
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
                var killerChapter = App.DB.KillerChapter.FirstOrDefault(x => x.KillerId == Id);
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
                var killerChapter = App.DB.KillerChapter.FirstOrDefault(x => x.KillerId == Id);
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
    }
}
