using System;
using System.Collections.Generic;
using UnityEngine;
using Core.GameManagerSystem;


public class NPC : Character
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hola w :v");
        if (other.GetComponent<Hero>())
        {
            Character currentHero = other.GetComponent<Character>();
            if(currentHero.ImLeader)
            {
                GameManager.instance.TextBoxManager.CharactersConversation.Add(this);
                GameManager.instance.TextBoxManager.CharactersConversation.Add(currentHero);
                GameManager.instance.TextBoxManager.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {        
        GameManager.instance.TextBoxManager.gameObject.SetActive(false);
    }
}

