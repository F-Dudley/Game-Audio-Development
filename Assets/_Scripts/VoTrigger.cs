using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class VoTrigger : MonoBehaviour
{    
    [Space]
    [SerializeField] private EventReference eventReference;

    private FMOD.Studio.EventInstance sound;

    public GameObject TriggerBox;
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
        Debug.Log("hello");
        if (other.gameObject.CompareTag("Player"))
        {
            sound.start();
            TriggerBox.SetActive(false);
        }
    }
    #endregion

}