using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MoveTerrainModel 
{
    public MoveTerrainModel(float speed, float step)
    {
        Speed = speed;
        Step = step;
    }

    public float Speed { get; set; }
   public float Step { get; set; }
}
