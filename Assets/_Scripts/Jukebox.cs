using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : MonoBehaviour
{

    [SerializeField] private bool interactedWith = false;
    [SerializeField] private FMODUnity.StudioEventEmitter emitter;

    private void Start()
    {
        emitter.SetParameter("ON_OFF", 0);

        // This can be deleted later just for testing.
        emitter.SetParameter("Size", 200);
    }

    public void SetOn()
    {
        if (!interactedWith)
        {
            emitter.SetParameter("ON_OFF", 1);
            GameManager.instance.AddJukeboxTime();

            interactedWith = true;
        }
    }
}