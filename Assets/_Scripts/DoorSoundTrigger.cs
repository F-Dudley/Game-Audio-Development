using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundTrigger : MonoBehaviour
{
    private FMOD.Studio.EventInstance sound;
    [SerializeField] private bool isPlaying;

    #region Unity Functions
    private void Awake()
    {

    }

    private void Update()
    {
        sound = FMODUnity.RuntimeManager.CreateInstance("event:/Character Foley/Footsteps/Footsteps");
    }

    private void OnTriggerEnter(Collider other)
    {
        isPlaying = other.gameObject.CompareTag("Player");
    }
    #endregion

    public void PlayFootstep()
    {
        sound.setParameterByName("Terrain", (int) currentTerrain);
        sound.start();
        sound.release();
    }
}
