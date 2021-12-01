using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Controller
{
    class EnemyManagerController
    {
        EmemyManagerView ememyManagerView;
        EnemyManagerModel enemyManagerModel;

        public EnemyManagerController(EmemyManagerView ememyManagerView, EnemyManagerModel enemyManagerModel)
        {
            this.ememyManagerView = ememyManagerView;
            this.enemyManagerModel = enemyManagerModel;

            InitView();
        }


       void InitView()
        {
            ememyManagerView.Init(
                enemyManagerModel.shootRate.Value,
                enemyManagerModel.speedZEnemy.Value,
                enemyManagerModel.maxRangeZ.Value,
                enemyManagerModel.spawnPeriod.Value,
                enemyManagerModel.xRangePos.Value,
                enemyManagerModel.enemyCount.Value
                );
        }
    }
}
