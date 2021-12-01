using Assets.Scripts.Controller;
using Assets.Scripts.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] DataView dataView;

    DataController dataController;
    DataModel dataModel;


   void Start()
    {
        dataModel = new DataModel();

        dataController = new DataController(dataView, dataModel);


    }
}
