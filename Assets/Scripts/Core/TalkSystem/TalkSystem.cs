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
        static int dialogSize = 0;

        public static void StartConversation(List<Character> characters, Text text)
        {
            List<string> NpcDialog = new List<string>();
            List<string> HeroDialog = new List<string>();

            textContent = text;
            bool NPCTurn = true;

            /*
            foreach (Character c in characters)
            {
                foreach(string s in c.Lines.DialogLines)
                {
                    conversation.Add(s);
                }
            }
            */

            foreach (Character c in characters)
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
                        NPCTurn = true;
                    }
                }     
            }

            DialogSize = (NpcDialog.Count + HeroDialog.Count) / 2;

            for (int index = 0;index < DialogSize;index++ )
            {
                    if (NpcDialog[index] != "")
                    {
                        conversation.Add(NpcDialog[index]);
                    }
                    if (HeroDialog[index] != "")
                    {
                        conversation.Add(HeroDialog[index]);
                    }
            }

            conversationStarted = true;
            Index = 1;
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
                        Debug.Log((index + 1)+" "+(conversation.Count));
                    }
                    else
                    {
                        conversationStarted = false;
                        conversation.Clear();
                        conversation.TrimExcess();
                        textContent.text = "";
                        textContent.text = null;
                        container.SetActive(false);
                        Debug.Log("\nCount: {0}" + conversation.Count);
                        Debug.Log("Capacity: {0}"+ conversation.Capacity);
                    }
                }
            }
        }

        public static int Index
        {
            get
            {
                return index;
            }

            set
            {
                index = value;
            }
        }

        public static int DialogSize
        {
            get
            {
                return dialogSize;
            }

            set
            {
                dialogSize = value;
            }
        }
    }
}
