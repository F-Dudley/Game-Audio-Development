using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    [FMODUnity.EventRef]

    private Vector3 SpawnPoint = new Vector3(865.0f,100.0f,885.0f) ;
    //Moves this GameObject 2 units a second in the forward direction

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "KillBox")
        {
            transform.position = SpawnPoint;
            Debug.Log("DIE");
            // Trigger Fmod
        }
    }
}
