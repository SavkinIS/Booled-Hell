using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Controller
{
    class ShipMoveController
    {
        ShipMoveView shipMoveView;
        ShipMoveModel shipMoveModel;

        public ShipMoveController(ShipMoveView shipMoveView, ShipMoveModel shipMoveModel)
        {
            this.shipMoveView = shipMoveView;
            this.shipMoveModel = shipMoveModel;

            this.shipMoveView.Speed = this.shipMoveModel.Speed;
        }
    }
}
