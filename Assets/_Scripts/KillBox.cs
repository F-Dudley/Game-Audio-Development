using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerTeleportation;
using FMOD.Studio;
using FMODUnity;

public class KillBox : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string PlayDeathAudio;
 
    public FMODUnity.EventReference DeathVO;

    private Vector3 SpawnPoint = new Vector3(865.0f,100.0f,885.0f);
    //Moves this GameObject 2 units a second in the forward direction
    
    private WaitForSeconds waitTime = new WaitForSeconds(2f);

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FMODUnity.RuntimeManager.PlayOneShotAttached(PlayDeathAudio,gameObject);
            StartCoroutine(DeathTime());
            // Trigger Sounds Here
        }
    }
    
    private IEnumerator DeathTime()
    {
        yield return waitTime;
        FMODUnity.RuntimeManager.PlayOneShot(DeathVO);
        TeleportManager.instance.TeleportToClosestLocation();

    }
}