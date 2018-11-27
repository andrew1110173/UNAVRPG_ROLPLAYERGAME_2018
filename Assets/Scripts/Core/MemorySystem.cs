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

            public static void Save(GameData gameData)
            {
                string path = Path.Combine(Application.persistentDataPath, "MyGameSave.data");
                FileStream file = File.Create(path);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, gameData);
                file.Close();

                Debug.Log("Game Saved at: " + path);
            }

            public static GameData Load
            {
                get
                {
                    string path = Path.Combine(Application.persistentDataPath, "MyGameSave.data");
                    if (File.Exists(Application.persistentDataPath + "/MyGameSave.data"))
                    {
                        FileStream file = File.Open(path, FileMode.Open);
                        BinaryFormatter bf = new BinaryFormatter();
                        GameData gd = bf.Deserialize(file) as GameData;
                        file.Close();
                        return gd;
                    }

                    return new GameData();
                }
            }
        }
    }
}
