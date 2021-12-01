using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Controller
{
    class EnemyController
    {
        EnemyModel enemyModel;
        EnemyView enemyView;

        public EnemyController(EnemyModel enemyModel, EnemyView enemyView)
        {
            this.enemyModel = enemyModel;
            this.enemyView = enemyView;

            this.enemyView.Init(this.enemyModel.Speed.Value, this.enemyModel.ShootRate.Value);
        }
    }
}
