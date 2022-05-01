using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuManager : MonoBehaviour
{
    public static GameMenuManager instance;

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
    public bool GetCurrentViability() => menuRoot.activeSelf;

    public void TriggerGameMenuVisability(bool isTriggered)
    {
        switch(menuRoot.activeSelf)
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
        menuRoot.SetActive(!menuRoot.activeSelf);
    }

    public void ResetGameMenu()
    {
        homeMenu.SetActive(true);
        settingsMenu.SetActive(false);
        teleportMenu.SetActive(false);
    }
    #endregion
}
