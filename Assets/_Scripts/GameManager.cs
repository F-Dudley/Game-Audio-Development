using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static bool gameActive = true;

    [Header("Timer Settings")]
    [SerializeField] private float currentTime = 60f;
    [SerializeField] private float jukeBoxCollectionTime = 30f;

    [Header("Jukebox Settings")]
    [SerializeField] private int jukeboxAmount = 8;
    public System.Action allJukeboxesCollected;

    [Space]

    [SerializeField] private float countdownStartTime = 45f;

    [Header("Ambience Sounds")]
    [SerializeField] private FMODUnity.StudioEventEmitter countdownMusicEmitter;
    [SerializeField] private FMODUnity.StudioEventEmitter deathMusic;

    [Header("Scene References")]
    [SerializeField] private TextMeshProUGUI timeUI;
    [SerializeField] private TextMeshProUGUI jukeboxRemainingUI;

    [Header("Debug")]
    [SerializeField] private float debugAddTime = 20f;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        gameActive = true;

        Cursor.lockState = CursorLockMode.Locked;

        UpdateGameUI();
    }

    private void OnEnable()
    {
        allJukeboxesCollected += AllJukeboxesCollected;
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateTimer();
        UpdateGameUI();            
    }

    #region Main Game Functions
    private void UpdateTimer()
    {
        if (gameActive)
        {
            currentTime -= (1 * Time.deltaTime) * Time.timeScale;

            // Update FMOD Variable Here
            if (currentTime < countdownStartTime && !countdownMusicEmitter.IsPlaying())
            {
                countdownMusicEmitter.Play();
            }
            else if (currentTime > countdownStartTime && countdownMusicEmitter.IsPlaying())
            {
                countdownMusicEmitter.Stop();
            }

            if (currentTime <= 0)
            {
                TimeRanOut();
            }
        }
    }

    public void AddJukeboxTime()
    {
        currentTime += jukeBoxCollectionTime;
        jukeboxAmount -= 1;

        if (jukeboxAmount <= 0)
        {
            allJukeboxesCollected.Invoke();
        }

        UpdateGameUI();
    }

    private void TimeRanOut()
    {
        countdownMusicEmitter.Stop();        
        gameActive = false;

        deathMusic.Play();

        // GameFinished Screen;
        GameMenuManager.instance.DisplayDeathMenu();
    }

    private void AllJukeboxesCollected()
    {
        // Win Screen trigger
    }
    #endregion

    #region UI
    private void UpdateGameUI()
    {
        timeUI.text = "Time Remaining:\n" + Mathf.RoundToInt(currentTime).ToString();
        jukeboxRemainingUI.text = "Jukeboxes Remaining - " + jukeboxAmount;
    }
    #endregion

    #region Debug
    public void AddClockTime()
    {
        currentTime += debugAddTime;
    }

    public void RemoveClockTime()
    {
        currentTime -= debugAddTime;
    }
    #endregion
}