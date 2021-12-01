using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;

namespace Assets.Scripts.Model
{
    class ShipModel
    {
        public ShipModel(int lives)
        {
            Lives  = new ReactiveProperty<int>(lives);
        }

        public ReactiveProperty<int> Lives { get; set; }
    }
}
