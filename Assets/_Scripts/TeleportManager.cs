using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerTeleportation
{
    [System.Serializable]
    public struct TeleportLocation
    {
        public string locationName;
        public Transform teleportLocation;
    }

    public class TeleportManager : MonoBehaviour
    {
        [Header("Locations")]
        [SerializeField] private List<TeleportLocation> locations = new List<TeleportLocation>();

        [Header("Scene Referenes")]
        [SerializeField] private GameObject player;
        [SerializeField] private Transform buttonContainer;

        [Space]

        [SerializeField] private GameObject teleportButtonPrefab;

        #region Unity Functions
        private void Awake()
        {
            CreateLocationButtons();
        }

        private void Update()
        {
            
        }
        #endregion

        #region Initialization Functions
        private void CreateLocationButtons()
        {
            foreach(TeleportLocation teleLocation in locations)
            {
                GameObject buttonInstance = Instantiate(teleportButtonPrefab, transform.position, Quaternion.identity, buttonContainer);
                buttonInstance.name = teleLocation.locationName + " Button";
                TeleportButton buttonScript = buttonInstance.GetComponent<TeleportButton>();

                buttonScript.SetButtonVariables(this, teleLocation.teleportLocation, teleLocation.locationName);
            }
        }
        #endregion

        public void TeleportPlayer(Transform teleportLocation)
        {
            player.transform.position = teleportLocation.position;
            player.transform.rotation = teleportLocation.rotation;
        }
    }
}