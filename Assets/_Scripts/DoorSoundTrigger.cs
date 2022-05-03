using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class DoorSoundTrigger : MonoBehaviour
{    
    [Space]
    
    [SerializeField] private EventReference eventReference;

    [Header("Settings")]
    [SerializeField] private bool isPlaying;
    [SerializeField] private bool allowFadeOut;

    private FMOD.Studio.EventInstance sound;

    #region Unity Functions
    private void Awake()
    {
        sound = FMODUnity.RuntimeManager.CreateInstance(eventReference);
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object Entered");
        if (other.gameObject.CompareTag("Player"))
        {
            isPlaying = !isPlaying; 

            if (isPlaying)
            {
                PlaySound();
            }
            else
            {
                StopSound();
            }
        }
    }
    #endregion

    private void PlaySound()
    {
        sound.start();
    }

    private void StopSound()
    {
        if (sound.isValid())
        {
            sound.stop(allowFadeOut ? FMOD.Studio.STOP_MODE.ALLOWFADEOUT : FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
    }
}