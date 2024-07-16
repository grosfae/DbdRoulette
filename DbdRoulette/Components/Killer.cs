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
        public int DifficultyId { get; set; }
        public string Lore { get; set; }
        public string MoveSpeed { get; set; }
        public string TerrorRadius { get; set; }
        public string Height { get; set; }
        public byte[] MainIcon { get; set; }
        public byte[] MainImage { get; set; }
        public byte[] MainBackground { get; set; }
        public int ChapterId { get; set; }
        public int PowerId { get; set; }
        public virtual Chapter Chapter { get; set; }
        public virtual Difficulty Difficulty { get; set; }
        public virtual Power Power { get; set; }
        public virtual ICollection<KillerPerk> KillerPerk { get; set; }
        public string DiaryLetter { get; set; }
        public virtual ICollection<KillerCosmeticOutfit> KillerCosmeticOutfit { get; set; }
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
                if (Chapter.ChapterType.Id == 1)
                {
                    return "#FFB5873C";
                }
                if (Chapter.ChapterType.Id == 2)
                {
                    return "#FF6C6358";
                }
                if (Chapter.ChapterType.Id == 3)
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
                if (Chapter.ChapterType.Id == 1)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/MetalCuts/Gold.jpg";
                }
                if (Chapter.ChapterType.Id == 2)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/MetalCuts/Metal.jpg";
                }
                if (Chapter.ChapterType.Id == 3)
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
                if (Chapter.ChapterType.Id == 1)
                {
                    return "";
                }
                if (Chapter.ChapterType.Id == 2)
                {
                    return "";
                }
                if (Chapter.ChapterType.Id == 3)
                {
                    return "";
                }
                else
                {
                    return null;
                }
            }

        }
        public string DifficultyImage
        {
            get
            {
                if (DifficultyId == 1)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/DifficultyIcons/Easy.png";
                }
                if (DifficultyId == 2)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/DifficultyIcons/Medium.png";
                }
                if (DifficultyId == 3)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/DifficultyIcons/Hard.png";
                }
                if (DifficultyId == 4)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/DifficultyIcons/VeryHard.png";
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
