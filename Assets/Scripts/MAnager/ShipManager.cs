using Assets.Scripts.Controller;
using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    [SerializeField] ShipMoveView shipMoveView;
    [SerializeField] ShipView shipView;

    ShipMoveController shipMoveController;
    ShipMoveModel shipMoveModel;

    ShipController shipController;
    ShipModel shipModel;
    private void Start()
    {
        shipMoveModel = new ShipMoveModel(0.75f);
        shipMoveController = new ShipMoveController(shipMoveView, shipMoveModel);

        shipModel = new ShipModel(3);
        shipController = new ShipController(shipView, shipModel);

    }

}
