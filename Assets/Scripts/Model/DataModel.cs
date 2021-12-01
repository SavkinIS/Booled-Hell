using Assets.Scripts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx; 

namespace Assets.Scripts.Model
{
    class DataModel
    {
        public ReactiveProperty< GameData> GameData { get; set; }

        public DataModel()
        {
            if (DataWork.LoadData() == null)
            {
                DataWork.Init();
            }
            GameData = new ReactiveProperty<GameData>(DataWork.GetGameData());

        }

    }
}
