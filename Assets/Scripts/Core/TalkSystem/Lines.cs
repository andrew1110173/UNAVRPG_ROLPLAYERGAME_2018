using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.TalkSystem.Lines
{
    [Serializable]
    public class Lines
    {
        [SerializeField, TextArea(3, 10)]
        string[] dialogLines;

        public string[] DialogLines
        {
            get
            {
                return dialogLines;
            }
        }
    }
}
