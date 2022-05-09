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

    [Space]

    [SerializeField] private float countdownStartTime = 45f;

    [Header("Ambience Sounds")]
    [SerializeField] private FMODUnity.StudioEventEmitter countdownMusicEmitter;
    [SerializeField] private FMODUnity.StudioEventEmitter deathMusic;

    [Header("Scene References")]
    [SerializeField] private TextMeshProUGUI timeUI;

    [Header("Debug")]
    [SerializeField] private float debugAddTime = 20f;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;

        UpdateGameUI();
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
        UpdateGameUI();
    }

    private void TimeRanOut()
    {
        countdownMusicEmitter.Stop();        
        gameActive = false;

        deathMusic.Play();

        // GameFinished Screen;
    }

    private void AllJukeboxesCollected()
    {

    }
    #endregion

    #region UI
    private void UpdateGameUI()
    {
        timeUI.text = "Time Remaining:\n" + Mathf.RoundToInt(currentTime).ToString();
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