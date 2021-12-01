using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;

namespace Assets.Scripts.Model
{
    class AsteroidManagerModel
    {
        public AsteroidManagerModel(float xRangePos,  float maxRangeZ, float speedZAster, float asteroidSpanPeriod, int asteroidCount)
        {
            this.xRangePos = new ReactiveProperty<float>(xRangePos);
            this.maxRangeZ = new ReactiveProperty<float>(maxRangeZ);
            this.speedZAster = new ReactiveProperty<float>(speedZAster);
            this.asteroidSpanPeriod = new ReactiveProperty<float>(asteroidSpanPeriod);
            this.asteroidAmount = new ReactiveProperty<int>(asteroidCount);
        }

        public ReactiveProperty<float> xRangePos { get; set; }
        public ReactiveProperty<float> maxRangeZ { get; set; }
        public ReactiveProperty<float> speedZAster { get; set; }
        public ReactiveProperty<float> asteroidSpanPeriod { get; set; }
        public ReactiveProperty<int> asteroidAmount { get; set; }
    }
}
