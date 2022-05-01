using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }
    #endregion

    public void PlaySound()
    {
        //sound.setParameterByName("Terrain", (int) currentTerrain);
        sound.start();
        sound.release();
    }
}