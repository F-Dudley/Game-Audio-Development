using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactible : MonoBehaviour
{
    [SerializeField] private UnityEvent onInteract;

    #region Unity Functions
    private void Start()
    {

    }

    private void Update()
    {

    }
    #endregion

    #region Interaction
    public void Interact()
    {
        onInteract.Invoke();
    }
    #endregion
}
