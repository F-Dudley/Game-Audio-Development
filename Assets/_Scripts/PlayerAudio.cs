using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

namespace PlayerSounds
{
    public enum CURRENT_TERRAIN 
    {
        STONE = 0,
        WOOD = 1,
        METAL = 2,
        EARTH = 3,
        GRAVEL = 4,
        WATER = 5
    }

    public class PlayerAudio : MonoBehaviour {

        [Header("Terrain Detection")]
        [SerializeField] private CURRENT_TERRAIN currentTerrain;
        [SerializeField] private LayerMask hitMask;

        [Header("Footsteps Sound")]
        [SerializeField] private StudioEventEmitter footstepEmitter;

        [Header("Jump Start")]
        [SerializeField] private StudioEventEmitter jumpStartEmitter;


        [Header("Jump Landing")]
        [SerializeField] private StudioEventEmitter jumpLandingEmitter;

        private void Awake()
        {

        }

        private void Update()
        {
            DetermineTerrain();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position + (Vector3.up * 0.05f), Vector3.down * 1f);
        }

        private void DetermineTerrain()
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position + (Vector3.up * 0.05f) , Vector3.down, out hit, 1f, hitMask))
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Gravel"))
                {
                    currentTerrain = CURRENT_TERRAIN.GRAVEL;
                }
                else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Wood"))
                {
                    currentTerrain = CURRENT_TERRAIN.WOOD;
                }
                else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Stone"))
                {
                    currentTerrain = CURRENT_TERRAIN.STONE;
                }
                else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Water"))
                {
                    currentTerrain = CURRENT_TERRAIN.WATER;
                }
                else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Metal"))
                {
                    currentTerrain = CURRENT_TERRAIN.METAL;
                }
                else if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Earth"))
                {
                    currentTerrain = CURRENT_TERRAIN.EARTH;
                }
            }

            footstepEmitter.SetParameter("Terrain", (int) currentTerrain);

            //jumpStartEmitter.SetParameter("Terrain", (int) currentTerrain);
            //jumpLandingEmitter.SetParameter("Terrain", (int) currentTerrain);
        }

        public void PlayFootstep()
        {
            footstepEmitter.Play();
        }

        public void PlayJumpStart()
        {
            jumpStartEmitter.Play();            
        }

        public void PlayJumpLanding()
        {
            jumpLandingEmitter.Play();
        }
    }    
}