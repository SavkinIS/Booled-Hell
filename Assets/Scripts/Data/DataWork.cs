using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public static class DataWork
    {
        static GameData gameData;


        public static GameData GetGameData()
        {
            if (gameData != null) return gameData;
            else return LoadData();
        }

        // <summary>
        /// name of the configuration file
        /// </summary>
        const string saveData = "SaveData.json";
        readonly static string path = Application.dataPath + "/Scripts/Data/" + saveData;
        public  static void Save(GameData gameDataToSave)
        {            
            string json = JsonUtility.ToJson(gameDataToSave);
            using (var sw = new StreamWriter(path))
            {
                sw.Write(json);
                sw.Close();
            }
        }


        public static GameData LoadData()
        {
            try
            {
                string jsonR = File.ReadAllText(path);
                gameData = JsonUtility.FromJson<GameData>(jsonR);
                return gameData;
            }
            catch (Exception e )
            {

                Debug.LogError(e.Message);
                return null;
            }
            
        }


        public static void Init()
        {
            GameData data = new GameData();
            Level level_1 = new Level { AsteroidCount = 0, AsteroidSpanPeriod = 0, EnemyCount = 0, EnemySpanPeriod = 0, Open = true };
            Level level_2 = new Level { AsteroidCount = 0, AsteroidSpanPeriod = 0, EnemyCount = 0, EnemySpanPeriod = 0, Open = false };
            Level level_3 = new Level { AsteroidCount = 0, AsteroidSpanPeriod = 0, EnemyCount = 0, EnemySpanPeriod = 0, Open = false };

            Indicators indicators = new Indicators { TotalDestroyedAsteroids = 0, TotalKilledEnemy = 0 };

            data.Levels = new List<Level> { level_1, level_2, level_3 };
            data.Indicators = indicators;

            string json = JsonUtility.ToJson(data);
            using (var sw = new StreamWriter(path))
            {
                sw.Write(json);
            }

        }


    }
}
