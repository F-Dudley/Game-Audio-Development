using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jukebox : MonoBehaviour
{

    [SerializeField] private bool interactedWith = false;
    [SerializeField] private Occlusion occlusionEmitter;

    private void Start()
    {
        occlusionEmitter = GetComponentInChildren<Occlusion>();

        occlusionEmitter.SetParameter("ON_OFF", 0);
        occlusionEmitter.SetParameter("Size", 1);
    }

    public void SetOn()
    {
        if (!interactedWith)
        {
            occlusionEmitter.SetParameter("ON_OFF", 1);
            GameManager.instance.AddJukeboxTime();  

            interactedWith = true;
        }
    }
}
