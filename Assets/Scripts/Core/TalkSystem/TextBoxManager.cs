using System;
using System.Collections.Generic;
using UnityEngine;
using Core.TalkSystem;
using UnityEngine.UI;

namespace Core.TalkSystem.TextBoxManager
{

    public class TextBoxManager : MonoBehaviour
    {
        List<Character> charactersConversation = new List<Character>();

        [SerializeField]
        Text textContent;

        public List<Character> CharactersConversation
        {
            get
            {
                return charactersConversation;
            }
        }

        private void OnEnable()
        {
            TalkSystem.StartConversation(charactersConversation, textContent);
        }

    }
}
