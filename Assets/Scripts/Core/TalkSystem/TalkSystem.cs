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
        static List<string> NpcDialog = new List<string>();
        static List<string> HeroDialog = new List<string>();
        static Text textContent;

        static bool conversationStarted = false;

        static int index = 0;
        static bool NPCTurn = true;

        public static void StartConversation(List<Character> characters, Text text)
        {
            textContent = text;

            /*
            foreach (Character c in characters)
            {
                foreach(string s in c.Lines.DialogLines)
                {
                    conversation.Add(s);
                }
            }
            */

            /*
            foreach (Character c in characters)
            {
                foreach (string s in c.Lines.DialogLines)
                {
                    conversation.Add(s);
                }
            }
            */
            foreach(Character c in characters)
            {
                if (NPCTurn)
                {
                    foreach (string s in c.Lines.DialogLines)
                    {
                        NpcDialog.Add(s);
                    }
                    NPCTurn = false;
                }else
                {
                    foreach (string s in c.Lines.DialogLines)
                    {
                        HeroDialog.Add(s);
                    }
                }     
            }

            int dialogSize = NpcDialog.Count + HeroDialog.Count/2;
            for(int index = 0;index < dialogSize -1;index++ )
            {
                if(NpcDialog[index]!="")
                conversation.Add(NpcDialog[index]);
                if (HeroDialog[index] != "")
                conversation.Add(HeroDialog[index]);
            }

            conversationStarted = true;
        }

        public static void Talking(GameObject container)
        {
            if (conversationStarted)
            {
                textContent.text = conversation[index];

                if (ControlSystem.SpaceBar)
                {
                    if (index + 1 < conversation.Count-1)
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
                        Debug.Log("End Chat");
                    }
                }
            }
        }
    }
}
