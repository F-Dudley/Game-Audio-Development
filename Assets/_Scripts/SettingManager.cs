using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FMOD;
using FMODUnity;

namespace GameSettings
{
    public class SettingManager : MonoBehaviour
    {
            [Header("Audio Busses")]
            [SerializeField] private string masterVCARoute;
            [SerializeField] private Slider masterVolumeSlider;
            private FMOD.Studio.VCA masterVCA;

            [Space]

            [SerializeField] private string musicVCARoute;
            [SerializeField] private Slider musicVolumeSlider;
            private FMOD.Studio.VCA musicVCA;

            [Space]

            [SerializeField] private string sfxVCARoute;
            [SerializeField] private Slider sfxVolumeSlider;
            private FMOD.Studio.VCA sfxVCA;

            [Space]

            [SerializeField] private string dialogueVCARoute;
            [SerializeField] private Slider dialogueVolumeSlider;
            private FMOD.Studio.VCA dialogueVCA;

            #region Unity Functions
            private void Start()
            {
                masterVCA = FMODUnity.RuntimeManager.GetVCA(masterVCARoute);
                musicVCA = FMODUnity.RuntimeManager.GetVCA(musicVCARoute);
                sfxVCA = FMODUnity.RuntimeManager.GetVCA(sfxVCARoute);
                dialogueVCA = FMODUnity.RuntimeManager.GetVCA(dialogueVCARoute);

                float volume;

                if (masterVCA.isValid())
                {
                    masterVCA.getVolume(out volume);
                    masterVolumeSlider.value = volume;
                }
            
                if (musicVCA.isValid())
                {
                    musicVCA.getVolume(out volume);
                    musicVolumeSlider.value = volume;
                }

                if (sfxVCA.isValid())
                {
                    sfxVCA.getVolume(out volume);
                    sfxVolumeSlider.value = volume;
                }

                if (dialogueVCA.isValid())
                {
                    dialogueVCA.getVolume(out volume);
                    dialogueVolumeSlider.value = volume;
                }
            }

            private void Update()
            {

            }
            #endregion

            #region Audio Functions
            public void SetMasterVCA(float _newBusValue)
            {
                if (masterVCA.isValid())
                {
                    UnityEngine.Debug.Log("New Value: " + _newBusValue);
                    masterVCA.setVolume(_newBusValue);
                }
            }

            public void SetMusicVCA(float _newBusValue)
            {
                if (musicVCA.isValid())
                {
                    UnityEngine.Debug.Log("New Value: " + _newBusValue);                    
                    musicVCA.setVolume(_newBusValue);                    
                }
            }

            public void SetSFXVCA(float _newBusValue)
            {
                if (sfxVCA.isValid())
                {
                    UnityEngine.Debug.Log("New Value: " + _newBusValue);
                    sfxVCA.setVolume(_newBusValue);                                        
                }
            }

            public void SetDialogueVCA(float _newBusValue)
            {
                if (dialogueVCA.isValid())
                {
                    UnityEngine.Debug.Log("New Value: " + _newBusValue);
                    dialogueVCA.setVolume(_newBusValue);
                }
            }
 
            public void SetVocalGender(Int32 newGender)
            {
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName("VocalGender", newGender);
                UnityEngine.Debug.Log("New Vocal Gender " + newGender);
            }
            #endregion
    }
}