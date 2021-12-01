using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Controller
{
    class AsteroidController
    {
        AsteroidModel asteroidModel;
        AsteroidView asteroidView;

        public AsteroidController(AsteroidModel asteroidModel, AsteroidView asteroidView)
        {
            this.asteroidModel = asteroidModel;
            this.asteroidView = asteroidView;

            asteroidView.SpeedZ = this.asteroidModel.Speed.Value;
        }
    }
}
