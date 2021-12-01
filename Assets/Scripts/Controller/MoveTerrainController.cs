using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTerrainController 
{
    MoveTerrainView view;
    MoveTerrainModel model;

    public MoveTerrainController(MoveTerrainView view, MoveTerrainModel model)
    {
        this.view = view;
        this.model = model;

        this.view.SetProperties(this.model.Speed, this.model.Step);
    }
}
