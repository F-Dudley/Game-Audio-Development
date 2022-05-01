using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour {

    private enum CURRENT_TERRAIN { 
        STONE = 0,
        WOOD = 1,
        METAL = 2,
        EARTH = 3,
        GRAVEL = 4,
        WATER = 5
    };

    [SerializeField]
    private CURRENT_TERRAIN currentTerrain;
    [SerializeField] private LayerMask hitMask;

    private FMOD.Studio.EventInstance foosteps;

    private void Awake()
    {
        foosteps = FMODUnity.RuntimeManager.CreateInstance("event:/Character Foley/Footsteps/Footsteps");
        foosteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
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

    }

    public void PlayFootstep()
    {
        foosteps.setParameterByName("Terrain", (int) currentTerrain);
        foosteps.start();
        foosteps.release();
    }
}