using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows;

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
        public virtual ICollection<ChapterCharm> ChapterCharm { get; set; }
        public string UpperName
        {
            get
            {
                return Name.ToUpper();
            }
        }
        public string KillerEnumerable
        {
            get
            {
                if (Killer.Count == 1)
                {
                    return Killer.FirstOrDefault().Name;
                }
                else
                {
                    return null;
                }
            }
        }
        public string SurvivorsEnumerable
        {
            get
            {
                if (Survivor.Count == 1)
                {
                    return $"Новый Выживший: {Survivor.FirstOrDefault().Name}";
                }
                else if(Survivor.Count > 1)
                {
                    List<string> survivorNames = new List<string>();
                    foreach (var survivor in Survivor)
                    {
                        survivorNames.Add(survivor.Name);
                    }
                    return $"Новые Выжившие: {string.Join(" и ", survivorNames)}";
                }
                else
                {
                    return null;
                }
            }
        }

        public string CharmName
        {
            get
            {
                var selectedCharm = ChapterCharm.FirstOrDefault(x => x.ChapterId == Id);
                if (selectedCharm != null)
                {
                    return selectedCharm.Charm.Name;
                }
                else
                {
                    return null;
                }
            }
        }

        public string MapName
        {
            get
            {
                var selectedMap = Map.FirstOrDefault(x => x.ChapterId == Id);
                if (selectedMap != null)
                {
                    return selectedMap.Name;
                }
                else
                {
                    return null;
                }
            }
        }

        public string ExclusiveItem
        {
            get
            {
                string charactersName = null;
                var killerExclusive = Killer.FirstOrDefault().KillerCosmeticOutfit.Where(x => x.CosmeticOutfit.IsExclusive == true).FirstOrDefault();
                List<string> Names = new List<string>();  

                if (Survivor != null)
                {
                    foreach (var survivor in Survivor)
                    {
                        if(survivor.SurvivorCosmeticOutfit.FirstOrDefault(x => x.CosmeticOutfit.IsExclusive == true) != null)
                        {
                            Names.Add(survivor.Name);
                        }
                    }
                }

                if (killerExclusive != null)
                {
                    Names.Add(killerExclusive.Killer.Name);
                }
                if(Names.Count > 0)
                {
                    charactersName += string.Join(" и ", Names);
                }

                if (charactersName != null)
                {
                    return $"Эксклюзивный предмет для {charactersName}";
                }
                else
                {
                    return null;
                }    
            }
        }

        public Visibility KillerVisibility
        {
            get
            {
                if (KillerEnumerable == null)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }
        public Visibility SurvivorVisibility
        {
            get
            {
                if (SurvivorsEnumerable == null)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }
        public Visibility MapVisibility
        {
            get
            {
                if (Map.Count == 0)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }
        public Visibility ExclusiveVisibility
        {
            get
            {
                if (ExclusiveItem == null)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }
        public Visibility CharmVisibility
        {
            get
            {
                if (CharmName == null)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

       

    }
}
