using System;
using UnityEngine;

namespace Core.GameManagerSystem
{
    public abstract class GameManagerSystem : MonoBehaviour
    {
        public static GameManagerSystem instance;

        void Start()
        {
            if (!instance)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
            else if (instance != this)
            {
                Destroy(this);
            }
        }
    }
}
