using UnityEngine;
using Core.PartySystem;
using Core.ControlSystem;
using Core.TalkSystem.TextBoxManager;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    PartySystem partySystem;

    [SerializeField]
    TextBoxManager textBoxManager;

    [SerializeField]
    GameData currentGameData;

    private static bool startParty = false;

    void Awake()
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

    private void OnLevelWasLoaded(int level)
    {
        //Si entramos a la partida inicia el Party
        if (level == 1)
        {
            partySystem.StartParty();
        }
    }

    private void Update()
    {
        if (ControlSystem.ChangeHero)
        {
            ChangeHero();
        }
    }

    public PartySystem PartySystem
    {
        get
        {
            return partySystem;
        }
    }

    public TextBoxManager TextBoxManager
    {
        get
        {
            return textBoxManager;
        }
    }

    public GameData CurrentGameData
    {
        get
        {
            return currentGameData;
        }

        set
        {
            currentGameData = value;
        }
    }

    public void ChangeHero()
    {
        partySystem.ChangeHero();
    }
}

