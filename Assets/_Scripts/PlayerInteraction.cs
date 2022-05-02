using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] private bool objectFound = false;
    [SerializeField] private Interactible foundScript;

    [Header("Raycast Settings")]
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float interactDistance = 1.5f;
    [SerializeField] private LayerMask interactLayerMask;
    private RaycastHit hit;

    [Header("Scene References")]
    [SerializeField] private StarterAssets.StarterAssetsInputs input;

    #region Unity Functions
    private void Awake()
    {
        input = GetComponent<StarterAssets.StarterAssetsInputs>();
    }

    private void Update()
    {
        DetectObject();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = objectFound ? Color.yellow : Color.gray;
        Gizmos.DrawRay(cameraTransform.position, cameraTransform.forward * interactDistance);
    }
    #endregion

    #region Interaction Functions
    private void DetectObject()
    {
        objectFound = Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, interactDistance, interactLayerMask);
        if (objectFound)
        {
            if (input.interact)
            {
                Interact(hit.collider.gameObject);
            }
        }
    }

    private void Interact(GameObject interactableObject)
    {
        Debug.Log("Interact with " + interactableObject.name);
        if (interactableObject.TryGetComponent<Interactible>(out foundScript))
        {
            foundScript.Interact();
            foundScript = null;
        }
    }

    private void PerformInteractAnimation()
    {

    }
    #endregion
}
