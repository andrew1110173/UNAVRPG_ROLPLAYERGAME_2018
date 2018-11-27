using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Core
{
    namespace MemorySystem
    {
        public class MemorySystem
        {
            string path;
            public static void Save(GameData gameData, string fileName)
            {
                string path = Path.Combine(Application.persistentDataPath, fileName);
                FileStream file = File.Create(path);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, gameData);
                file.Close();

                Debug.Log("Game Saved at:" + path);
            }

            public static void Load(string path)
            {
                if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
                {
                    
                }
            }
        }
    }
}
