using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Model
{
    [Serializable]
    class ShipMoveModel
    {
        public ShipMoveModel(float speed)
        {
            Speed = speed;
        }

        public float Speed { get; set; }

    }
}
