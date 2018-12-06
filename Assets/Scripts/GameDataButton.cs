using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.MemorySystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDataButton : MonoBehaviour
{
    Button btn_loadGame;
    [SerializeField]
    Text buttonNameText;

    [SerializeField]
    int order;

    public void startButton()
    {
        btn_loadGame = GetComponent<Button>();
        btn_loadGame.onClick.AddListener(OnClickButton);
    }

    public string buttonDefaultGameName
    {
        get
        {
            return "GameSaved" + order.ToString();
        }
    }

    public string setGameName
    {
        set
        {
            buttonNameText.text = value;
        }
    }

    void OnClickButton()
    {
        if (buttonNameText.text != "Empty")
        {
            GameManager.instance.CurrentGameData = MemorySystem.Load("GameSaved" + order.ToString());
        }
        else if(buttonNameText.text == "Empty")
        {
            GameManager.instance.CurrentGameData = MemorySystem.NewGame("GameSaved" + order.ToString(), buttonNameText);
        }
        SceneManager.LoadScene(1);
    }
}
