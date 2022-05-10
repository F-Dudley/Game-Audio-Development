using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerTeleportation;
using FMOD.Studio;
using FMODUnity;

public class KillBox : MonoBehaviour
{
    public string PlayDeathAudio;
    public FMODUnity.EventReference DeathVO;
    [SerializeField] private bool deathRunning = false;

    private WaitForSeconds waitTime = new WaitForSeconds(2f);

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !deathRunning)
        {
            deathRunning = true;
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

        deathRunning = false;
    }
}
