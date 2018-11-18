using UnityEngine;
using Core.PartySystem;
using Core.TalkSystem.TextBoxManager;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    PartySystem partySystem;

    [SerializeField]
    TextBoxManager textBoxManager;

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

        partySystem.StartParty();
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
}

