using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DbdRoulette.Components
{
    [Table("Power")]
    public class Power
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Quote { get; set; }
        public byte[] MainIcon { get; set; }
        public byte[] DemoImage { get; set; }
        public virtual ICollection<PowerAddon> PowerAddon { get; set; }
        public virtual ICollection<Killer> Killer { get; set; }
        public virtual ICollection<PowerItem> PowerItem { get; set; }


        public string UpperName
        {
            get
            {
                return Name.ToUpper();
            }
        }
        public string OwnerName
        {
            get
            {
                var killer = Killer.FirstOrDefault();
                if (killer != null)
                {
                    return killer.Name.ToUpper();
                }
                else
                {
                    return "НЕИЗВЕСТНО";
                }
            }
        }
        public string HazeCloud
        {
            get
            {
                return "pack://application:,,,/DbdRoulette;component/Resources/ColorHazes/CommonHaze.png"; 
            }
        }
        public Visibility ShowQuote
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Quote))
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }
        }
    }
}
