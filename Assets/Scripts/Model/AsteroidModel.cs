using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;

namespace Assets.Scripts.Model
{
    class AsteroidModel : Moving
    {
        public AsteroidModel(float speed )
        {
            Speed = new ReactiveProperty<float>(speed);
        }

    }
}
