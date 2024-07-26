using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbdRoulette.Components.NoneDatabase
{
    public class PartyPlayer
    {
        public string Name {get; set;}
        public int PlayerNumber { get; set; }
        public string NumberImage
        {
            get
            {
                if (PlayerNumber == 1)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/RouletteIcon/NumberFirstIcon.png";
                }
                if (PlayerNumber == 2)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/RouletteIcon/NumberSecondIcon.png";
                }
                if (PlayerNumber == 3)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/RouletteIcon/NumberThirdIcon.png";
                }
                if (PlayerNumber == 4)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/RouletteIcon/NumberFourthIcon.png";
                }
                if (PlayerNumber == 5)
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/RouletteIcon/NumberFifthIcon.png";
                }
                else
                {
                    return "pack://application:,,,/DbdRoulette;component/Resources/RouletteIcon/SpectatorIcon.png";
                }
            }
        }
    }
}
