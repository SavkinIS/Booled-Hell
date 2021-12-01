using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Data
{
    [Serializable]
    public class GameData
    {
        //    public Level Level_1;
        //    public Level Level_2;
        //    public Level Level_3;

        public List<Level> Levels;
        public Indicators Indicators;


        public Level GetLevel(int i)
        {
            if (i - 1 >= Levels.Count()) return null;
                return Levels[i-1];
        }

        public void UpdateLevel(Level level, int i)
        {
            if (i - 1 <= Levels.Count()) Levels[i-1] = level;
        }

        public void UpdateIndicators(int enemy, int asterids)
        {
            Indicators.TotalDestroyedAsteroids += asterids;
            Indicators.TotalKilledEnemy += enemy;
        }

        public void OpenNextLevel(int i)
        {
            if(i< Levels.Count())
            {
                Levels[i].Open = true;
            }
            
        }
    }


    
}
