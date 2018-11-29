using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core.TalkSystem
{

    using Core.ControlSystem;

    public class TalkSystem
    {

        static List<string> conversation = new List<string>();
        static Text textContent;

        static bool conversationStarted = false;

        static int index = 0;

        public static void StartConversation(List<Character> characters, Text text)
        {
            textContent = text;
            bool NPCturn = true;
            Character data = null;
            
            foreach (Character c in characters)
            {
                data = c;
                foreach(string s in c.Lines.DialogLines)
                {
                    conversation.Add(s);
                    Debug.Log(s);
                }
            }
            
            Debug.Log(data);

            conversationStarted = true;
        }

        public static void Talking(GameObject container)
        {
            if (conversationStarted)
            {
                textContent.text = conversation[index];

                if (ControlSystem.SpaceBar)
                {
                    if (index + 1 < conversation.Count - 1)
                    {
                        index++;
                    }
                    else
                    {
                        conversationStarted = false;
                        conversation.Clear();
                        textContent.text = "";
                        textContent.text = null;
                        container.SetActive(false);
                    }
                }
            }
        }
    }
}
