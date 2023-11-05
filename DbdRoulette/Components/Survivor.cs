using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components
{
    [Table("Survivor")]
    public class Survivor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PieValue { get; set; }
        public string Lore { get; set; }
        public byte[] MainIcon { get; set; }
        public byte[] MainImage { get; set; }
        public byte[] MainBackground { get; set; }
        public int ChapterId { get; set; }
        public virtual Chapter Сhapter { get; set; }
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
                if (Сhapter.ChapterType.Id == 1)
                {
                    return "#FFB5873C";
                }
                if (Сhapter.ChapterType.Id == 2)
                {
                    return "#FF6C6358";
                }
                if (Сhapter.ChapterType.Id == 3)
                {
                    return "#FFC50000";
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
                if (Сhapter.ChapterType.Id == 1)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/MetalCuts/Gold.jpg";
                }
                if (Сhapter.ChapterType.Id == 2)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/MetalCuts/Metal.jpg";
                }
                if (Сhapter.ChapterType.Id == 3)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/MetalCuts/RedMetal.jpg";
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
                if (Сhapter.ChapterType.Id == 1)
                {
                    return "";
                }
                if (Сhapter.ChapterType.Id == 2)
                {
                    return "";
                }
                if (Сhapter.ChapterType.Id == 3)
                {
                    return "";
                }
                else
                {
                    return null;
                }
            }

        }
    }
}
