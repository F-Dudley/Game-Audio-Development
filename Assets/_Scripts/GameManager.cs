using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private float currentTime = 60;

    [Header("Ambience Sounds")]
    [SerializeField] private FMODUnity.StudioEventEmitter ambienceEmitter;

    [Header("Scene References")]
    [SerializeField] private TextMeshProUGUI timeUI;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateGameUI();
        SetGameUI();
    }

    #region UI
    private void UpdateGameUI()
    {
        currentTime -= (1 * Time.deltaTime) * Time.timeScale;
    }

    private void SetGameUI()
    {
        timeUI.text = "Time: " + Mathf.RoundToInt(currentTime).ToString();
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