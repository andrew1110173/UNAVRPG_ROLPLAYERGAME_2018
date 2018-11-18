using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.TalkSystem.TextBoxManager;
using Core.TalkSystem;

public class TalkingBox : TextBoxManager
{

    private void Update()
    {
        TalkSystem.Talking(gameObject);
    }
}
