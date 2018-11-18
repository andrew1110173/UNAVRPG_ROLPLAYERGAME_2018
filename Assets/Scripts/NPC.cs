using System;
using System.Collections.Generic;
using UnityEngine;


public class NPC : Character
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Hero>())
        {
            Character currentHero = other.GetComponent<Character>();

            GameManager.instance.TextBoxManager.CharactersConversation.Add(this);
            GameManager.instance.TextBoxManager.CharactersConversation.Add(currentHero);
            GameManager.instance.TextBoxManager.gameObject.SetActive(true);
        }
    }
}

