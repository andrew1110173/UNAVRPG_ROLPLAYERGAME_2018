using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.MemorySystem;

public class MenuSaveData : MonoBehaviour
{
    [SerializeField]
    List<GameDataButton> gameButtons;

    void StartButtons()
    {
        foreach(GameDataButton gdb in gameButtons)
        {
            gdb.startButton();
        }
    }

    private void Start()
    {
        StartButtons();

        List<string> games = MemorySystem.LookForGames;

        for (int i = 0; i < games.Count; i++)
        {
            foreach(GameDataButton gdb in gameButtons)
            {
                if (gdb.buttonDefaultGameName == games[i])
                {
                    gdb.setGameName = games[i];
                }
            }

            //gameButtons[i].setGameName = games[i];
        }
    }
}
