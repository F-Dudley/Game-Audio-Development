﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Audio : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string PlayButtonEvent;
    public string SelectButtonEvent;
    public string BackButtonEvent;
    public string HoverButtonEvent;

    public bool PlayOnAwake;

    public void PlayStart()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(PlayButtonEvent,gameObject);
    }

    public void PlaySelect() // Triggers the Menu Select audio
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(SelectButtonEvent,gameObject);
    }

    public void PlayBack() // Triggers the Menu Select audio
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(BackButtonEvent,gameObject);
    }

    public void PlayHover() // Triggers the Menu Select audio
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(HoverButtonEvent,gameObject);
    }
}
