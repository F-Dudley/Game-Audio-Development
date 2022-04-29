using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class DoorSoundTrigger : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private bool isPlaying;
    [SerializeField] private string eventName;

    private FMOD.Studio.EventInstance sound;

    #region Unity Functions
    private void Awake()
    {

    }

    private void Update()
    {
        sound = FMODUnity.RuntimeManager.CreateInstance(eventName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlaying = !isPlaying;

            if (isPlaying)
            {
                PlaySound();
            }
            else if (!isPlaying)
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
        sound.stop(STOP_MODE.IMMEDIATE);
        sound.release();
    }
}