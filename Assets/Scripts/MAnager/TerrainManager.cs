using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    [SerializeField] MoveTerrainView terrainView;

    MoveTerrainController terrainController;
    MoveTerrainModel terrainModel;

    void Start()
    {
        terrainModel = new MoveTerrainModel(0.75f, 15);
        terrainController = new MoveTerrainController(terrainView, terrainModel);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
