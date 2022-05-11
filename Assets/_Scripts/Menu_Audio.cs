using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Audio : MonoBehaviour
{
    public string PlayButtonEvent;
    public string SelectButtonEvent;
    public string BackButtonEvent;
    public string HoverButtonEvent;
    public string Teleport;

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

    public void TeleP() // Triggers the Menu Select audio
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(Teleport,gameObject);
    }

}
