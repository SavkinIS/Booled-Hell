using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;

namespace Assets.Scripts.Model
{
    class EnemyManagerModel
    {
        public EnemyManagerModel(float xRangePos,float shootRate, float speedZEnemy, float maxRangeZ, float spawnPeriod, int enemyCount)
        {
            this.xRangePos = new ReactiveProperty<float>(xRangePos);
            this.shootRate = new ReactiveProperty<float>(shootRate);
            this.speedZEnemy = new ReactiveProperty<float>(speedZEnemy);
            this.maxRangeZ = new ReactiveProperty<float>(maxRangeZ);
            this.spawnPeriod = new ReactiveProperty<float>(spawnPeriod);
            this.enemyCount = new ReactiveProperty<int>(enemyCount);
        }

        public ReactiveProperty<float> xRangePos { get; set; }
        public ReactiveProperty<float> shootRate { get; set; }
        public ReactiveProperty<float> speedZEnemy { get; set; }
        public ReactiveProperty<float> maxRangeZ { get; set; }
        public ReactiveProperty<float> spawnPeriod { get; set; }
        public ReactiveProperty<int> enemyCount { get; set; }
    }
}
