using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

public class GameMenuManager : MonoBehaviour
{
    public static GameMenuManager instance;

    [SerializeField] private bool isVisable = false;

    [Header("Scene References")]
    [SerializeField] private GameObject menuRoot;
    [SerializeField] private GameObject homeMenu;
    [SerializeField] private GameObject settingsMenu;    
    [SerializeField] private GameObject teleportMenu;
    [SerializeField] private GameObject returnButton;

    [Space]

    [SerializeField] private GameObject winTitle;

    [Header("Death Screen")]
    [SerializeField] private GameObject deathUIRoot;
    [SerializeField] private GameObject deathTitle;
    [SerializeField] private GameObject deathUIButtons;    
    [SerializeField] private Image deathScreenBackground;

    [SerializeField] private float deathFadeTime;
    [SerializeField] private float killboxFadeTime;

    #region Unity Functions
    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        GameManager.instance.allJukeboxesCollected += ShowWinUIButtons;
    }

    private void OnDisable()
    {
        GameManager.instance.allJukeboxesCollected -= ShowWinUIButtons;
    }

    private void Update()
    {

    }
    #endregion

    #region Menu Interaction Functions
    public bool GetCurrentVisability() => isVisable;

    public void TriggerGameMenuVisability()
    {
        switch(isVisable)
        {
            case true:
                Time.timeScale = 1;
                isVisable = false;
                Cursor.lockState = CursorLockMode.Locked;
                break;

            case false:
                Time.timeScale = 0;
                isVisable = true;
                Cursor.lockState = CursorLockMode.Confined;
                break;

        }

        menuRoot.SetActive(isVisable);
        ResetGameMenu();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void ResetGameMenu()
    {
        homeMenu.SetActive(true);
        settingsMenu.SetActive(false);
        teleportMenu.SetActive(false);
        returnButton.SetActive(false);
    }

    public void DisplayDeathMenu()
    {
        deathUIRoot.SetActive(true);
        StartCoroutine(DeathFadeIn());
    }

    private void ShowFullDeathUIButtons()
    {
        deathTitle.SetActive(true);
        deathUIButtons.SetActive(true);
    }

    private void ShowWinUIButtons()
    {
        deathUIRoot.SetActive(true);
        winTitle.SetActive(true);
        deathUIButtons.SetActive(true);

        deathTitle.SetActive(false);
    }

    private void HideFullDeathUIButtons()
    {
        deathTitle.SetActive(false);
        deathUIButtons.SetActive(false);
    }
    #endregion

    #region Death Functions

    public void PerformInOutFade()
    {
        deathUIRoot.SetActive(true);
        StartCoroutine(FadeInOut());
    }

    private IEnumerator DeathFadeIn()
    {
        deathScreenBackground.color = new Color(deathScreenBackground.color.r, 
                                                deathScreenBackground.color.g,
                                                deathScreenBackground.color.b, 0);

        deathScreenBackground.DOFade(255, deathFadeTime * 100);
 
        yield return new WaitForSeconds(2f);

        Cursor.lockState = CursorLockMode.Confined;
        ShowFullDeathUIButtons();

        yield return null;
    }

    private IEnumerator FadeInOut()
    {
        deathScreenBackground.color = new Color(deathScreenBackground.color.r, 
                                                deathScreenBackground.color.g,
                                                deathScreenBackground.color.b, 0);

        deathScreenBackground.DOFade(255, killboxFadeTime * 100);
 
        yield return new WaitForSeconds(killboxFadeTime * 0.75f);

        deathTitle.SetActive(true);

        deathScreenBackground.DOFade(0, killboxFadeTime * 100);

        yield return new WaitForSeconds(killboxFadeTime * 0.75f);

        deathUIRoot.SetActive(false);
        deathTitle.SetActive(false);
        
    }
    #endregion
}
