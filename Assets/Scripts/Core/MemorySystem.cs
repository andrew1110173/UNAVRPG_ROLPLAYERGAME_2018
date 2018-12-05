using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

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

            public static GameData NewGame(string gameName, Text textButton)
            {
                string path = Path.Combine(Application.persistentDataPath, gameName + ".data");
                FileStream file = File.Create(path);
                BinaryFormatter bf = new BinaryFormatter();

                Dictionary<string, string> data = new Dictionary<string, string>();
                data["PosX"] = "250";
                data["PosZ"] = "32";
                data["Hero"] = "El, cacas";

                GameData newGameData = new GameData(data);
                bf.Serialize(file, newGameData);
                file.Close();

                textButton.text = gameName;

                return newGameData;
            }

            public static GameData Load(string gameName)
            {
                string path = Path.Combine(Application.persistentDataPath, gameName + ".data");

                if (File.Exists(path))
                {
                    FileStream file = File.Open(path, FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    GameData gd = bf.Deserialize(file) as GameData;
                    file.Close();
                    return gd;
                }

                return new GameData();                
            }

            public static List<string> LookForGames
            {
                get
                {
                    //string path = Path.Combine();

                    List<string> games = new List<string>();
                    foreach(string game in Directory.GetFiles(Application.persistentDataPath + "/", "*.data"))
                    {
                        games.Add(Path.GetFileNameWithoutExtension(game));
                    }
                    return games;
                }
            }
        }
    }
}
