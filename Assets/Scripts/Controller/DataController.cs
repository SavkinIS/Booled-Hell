using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;

namespace Assets.Scripts.Controller
{
    class DataController
    {

        DataView dataView;
        DataModel dataModel;

        public DataController(DataView dataView, DataModel dataModel)
        {
            this.dataView = dataView;
            this.dataModel = dataModel;


            this.dataModel.GameData.Value.Levels[0].ObserveEveryValueChanged(l => l.Open).Subscribe(lvlBut => this.dataView.SetActiveLevel1(lvlBut));
            this.dataModel.GameData.Value.Levels[1].ObserveEveryValueChanged(l => l.Open).Subscribe(lvlBut => this.dataView.SetActiveLevel2(lvlBut));
            this.dataModel.GameData.Value.Levels[2].ObserveEveryValueChanged(l => l.Open).Subscribe(lvlBut => this.dataView.SetActiveLevel3(lvlBut));

            this.dataModel.GameData.Value.Indicators.ObserveEveryValueChanged(a => a.TotalDestroyedAsteroids).Subscribe(ast => this.dataView.SetTextAsteroidDestroyed(ast.ToString()));
            this.dataModel.GameData.Value.Indicators.ObserveEveryValueChanged(e => e.TotalKilledEnemy).Subscribe(enemy => this.dataView.SetTextEnemyKilled(enemy.ToString()));

            this.dataView.ResetValues += () =>
            {
                Data.DataWork.Init();
                this.dataModel.GameData.Value = Data.DataWork.GetGameData();
            };
                // this.shipModel.Lives.ObserveEveryValueChanged(l => l.Value).Subscribe(lv => this.shipView.RenderLives(this.shipModel.Lives.Value));
        }
    }
}
