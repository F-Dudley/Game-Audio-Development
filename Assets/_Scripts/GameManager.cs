using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Timer Settings")]
    [SerializeField] private float currentTime = 60f;
    [SerializeField] private float jukeBoxCollectionTime = 30f;

    [Header("Ambience Sounds")]
    [SerializeField] private FMODUnity.StudioEventEmitter ambienceEmitter;

    [Header("Scene References")]
    [SerializeField] private TextMeshProUGUI timeUI;

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
        currentTime -= (1 * Time.deltaTime) * Time.timeScale;

        // Update FMOD Variable HEre
    }

    public void AddJukeboxTime()
    {
        currentTime += jukeBoxCollectionTime;
        UpdateGameUI();
    }
    #endregion

    #region UI
    private void UpdateGameUI()
    {
        timeUI.text = "Time Remaining:\n" + Mathf.RoundToInt(currentTime).ToString();
    }
    #endregion
    
    #region Ambience Sounds
    public void TriggerSandstormSounds(float newParameterValue)
    {
        ambienceEmitter.SetParameter("Sandstorm", newParameterValue);
    }

    public void TriggerBridgeSounds(float newParameterValue)
    {
        ambienceEmitter.SetParameter("Bridge", newParameterValue);
    }
    #endregion
}