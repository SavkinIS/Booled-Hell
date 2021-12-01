using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;

namespace Assets.Scripts.Model
{
    class EnemyModel : Moving
    {
        public EnemyModel(float speed, float shootRate)
        {
            Speed = new ReactiveProperty<float>(speed);
            ShootRate = new ReactiveProperty<float>(shootRate);
        }
        public ReactiveProperty<float> ShootRate { get; set; }

    }
}
