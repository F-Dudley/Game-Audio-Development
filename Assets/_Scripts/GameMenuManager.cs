using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuManager : MonoBehaviour
{
    public static GameMenuManager instance;

    [SerializeField] private bool isVisable = false;

    [Header("Scene References")]
    [SerializeField] private GameObject menuRoot;
    [SerializeField] private GameObject homeMenu;
    [SerializeField] private GameObject settingsMenu;    
    [SerializeField] private GameObject teleportMenu;

    #region Unity Functions
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {

    }
    #endregion

    #region Menu Interaction Functions
    public bool GetCurrentVisability() => isVisable;

    public void TriggerGameMenuVisability()
    {
        isVisable = !isVisable;

        switch(isVisable)
        {
            case true:
                Time.timeScale = 1.0f;
                Cursor.lockState = CursorLockMode.Locked;
                break;

            case false:
                Time.timeScale = 0.0f;
                Cursor.lockState = CursorLockMode.Confined;
                break;
        }
        menuRoot.SetActive(isVisable); 
    }

    public void ResetGameMenu()
    {
        homeMenu.SetActive(true);
        settingsMenu.SetActive(false);
        teleportMenu.SetActive(false);
    }
    #endregion
}