using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;
using FMODUnity;

namespace GameSettings
{
    public class SettingManager : MonoBehaviour
    {
            [Header("Audio Busses")]
            FMOD.Studio.VCA masterVCA;
            FMOD.Studio.Bus musicBus;
            FMOD.Studio.Bus sfxBus;
            FMOD.Studio.Bus dialogueBus;

            #region Unity Functions
            private void Start()
            {
                masterVCA = FMODUnity.RuntimeManager.GetVCA("vca:/MasterVCA");
                musicBus = FMODUnity.RuntimeManager.GetBus("bus:/MusicBus");
                sfxBus = FMODUnity.RuntimeManager.GetBus("bus:/sfxBus");
                dialogueBus = FMODUnity.RuntimeManager.GetBus("bus:/dialogueBus");
            }

            private void Update()
            {

            }
            #endregion

            #region Audio Functions
            public void SetMasterBus(float _newBusValue)
            {
                UnityEngine.Debug.Log("New Value: " + _newBusValue);
                masterVCA.setVolume(_newBusValue);
            }

            public void SetMusicBus(float _newBusValue)
            {
                musicBus.setVolume(_newBusValue);
            }

            public void SetSFXBus(float _newBusValue)
            {
                sfxBus.setVolume(_newBusValue);
            }

            public void SetDialogueBus(float _newBusValue)
            {
                dialogueBus.setVolume(_newBusValue);
            }
 
            public void SetGender(int Gender) //Needs to be int32
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("VocalGender", Gender);
                UnityEngine.Debug.Log(Gender);
            }
            #endregion
    }
}