using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerTeleportation;

public class KillBox : MonoBehaviour
{
    [FMODUnity.EventRef]

    private Vector3 SpawnPoint = new Vector3(865.0f,100.0f,885.0f);
    //Moves this GameObject 2 units a second in the forward direction
    
    private WaitForSeconds waitTime = new WaitForSeconds(2f);

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DeathTime());
            // Trigger Sounds Here
            
        }
    }
    
    private IEnumerator DeathTime()
    {
        yield return waitTime;
        
        TeleportManager.instance.TeleportToClosestLocation();
    }
}
