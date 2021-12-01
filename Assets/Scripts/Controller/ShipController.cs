using Assets.Scripts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace Assets.Scripts.Controller
{
    class ShipController
    {
        ShipView shipView;
        ShipModel shipModel;


        public ShipController(ShipView shipView, ShipModel shipModel)
        {
            this.shipView = shipView;
            this.shipModel = shipModel;

            this.shipModel.Lives.ObserveEveryValueChanged(l => l.Value).Subscribe(lv => this.shipView.RenderLives(this.shipModel.Lives.Value));

            this.shipView.ObserveEveryValueChanged(v => v.TakeDamage).Subscribe(m => TakeDamage());

        }



        void TakeDamage()
        {
            if (shipView.TakeDamage)
            {
                shipModel.Lives.Value--;
                if (shipModel.Lives.Value <= 0)
                {
                   shipView.Die();
                }
                else shipView.TakeDamage = false;
            }            
        }
    }
}
