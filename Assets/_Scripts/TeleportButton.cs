using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PlayerTeleportation
{
    public class TeleportButton : MonoBehaviour
    {
        [SerializeField] private Transform teleportLocation;
        [SerializeField] private TeleportManager teleportManager;

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
            Debug.Log("Teleporting Player");
            teleportManager.TeleportPlayer(teleportLocation);
        }

        public void SetButtonVariables(TeleportManager manager, Transform location, string buttonTitle)
        {
            teleportManager = manager;
            teleportLocation = location;
            buttonText.text = buttonTitle;
        }
        #endregion
    } 
}