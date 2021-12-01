using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Controller
{
    class AsteroidManagerController
    {

        AsteroidManagerModel asteroidManagerModel;
        AsteroidManagerView asteroidManagerView;

        public AsteroidManagerController(AsteroidManagerModel asteroidManagerModel, AsteroidManagerView asteroidManagerView)
        {
            this.asteroidManagerModel = asteroidManagerModel;
            this.asteroidManagerView = asteroidManagerView;
            Init();
        }


        void Init()
        {
            asteroidManagerView.Init(
                asteroidManagerModel.maxRangeZ.Value,
                asteroidManagerModel.speedZAster.Value,
                asteroidManagerModel.xRangePos.Value,
                asteroidManagerModel.asteroidSpanPeriod.Value,
                asteroidManagerModel.asteroidAmount.Value);
        }
    }
}
