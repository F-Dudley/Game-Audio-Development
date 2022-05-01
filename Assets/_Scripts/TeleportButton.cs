using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PlayerTeleportation
{
    public class TeleportButton : MonoBehaviour
    {
        [SerializeField] private Transform teleportLocation;

        [Header("Button References")]
        [SerializeField] private TextMeshProUGUI buttonText;

        #region Unity Functions
        private void Start()
        {

        }
        #endregion

        #region Button Functions
        public void OnClickButton()
        {
            TeleportManager.instance.TeleportPlayer(teleportLocation);
        }

        public void SetButtonVariables(Transform location, string buttonTitle)
        {
            teleportLocation = location;
            buttonText.text = buttonTitle;
        }
        #endregion
    } 
}