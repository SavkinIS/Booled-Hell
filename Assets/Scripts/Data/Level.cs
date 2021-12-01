using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Data
{
    [Serializable]
    public class Level
    {
        public int EnemyCount;
        public int AsteroidCount;
        public float EnemySpanPeriod;
        public float AsteroidSpanPeriod;

        public bool Open;



        public bool IsInit()
        {
            if (EnemyCount == 0 || AsteroidCount == 0 || EnemySpanPeriod == 0 || AsteroidSpanPeriod == 0) return false;
            else return true;
        }
    }
}
