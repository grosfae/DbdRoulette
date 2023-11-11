using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DbdRoulette.Components
{
    [Table("Chapter")]
    public class Chapter
    {
        public int Id { get; set; }
        public string Name {get; set; }
        public string DateRelease {get; set; }
        public string Description {get; set; }
        public int ChapterTypeId {get; set; }
        public byte[] MainImage {get; set; }
        public virtual ChapterType ChapterType { get; set; }
        public virtual ICollection<Killer> Killer { get; set; }
        public virtual ICollection<Survivor> Survivor { get; set; }
        public virtual ICollection<Map> Map { get; set; }
        public virtual ICollection<Charm> Charm { get; set; }


        public string SurvivorsEnumerable
        {
            get
            {
                if (Survivor.Count == 1)
                {
                    return $"Новый Выживший: {Survivor}";
                }
                else if(Survivor.Count > 1)
                {
                    string survivorNames = "Новые Выжившие:";
                    foreach(var survivor in Survivor)
                    {
                        survivorNames += survivor.Name;
                    }
                    return survivorNames;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
