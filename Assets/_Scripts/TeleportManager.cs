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
        public static TeleportManager instance;

        [Header("Locations")]
        [SerializeField] private List<TeleportLocation> locations = new List<TeleportLocation>();

        [Header("Map References")]
        [SerializeField] private Transform indicatorPosition;        

        [Header("Scene Referenes")]
        [SerializeField] private Transform player;
        [SerializeField] private Transform cam;
        [SerializeField] private CharacterController playerController;
        [SerializeField] private Transform buttonContainer;

        [Space]

        [SerializeField] private GameObject teleportButtonPrefab;

        #region Unity Functions
        private void Awake()
        {
            instance = this;
            CreateLocationButtons();

            playerController = player.GetComponent<CharacterController>();

            indicatorPosition.gameObject.SetActive(false);
        }

        private void Update()
        {
            
        }

        private void OnDrawGizmos()
        {
            foreach(TeleportLocation location in locations)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(location.teleportLocation.position, 1.0f);
            }
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

                buttonScript.SetButtonVariables(teleLocation.teleportLocation, teleLocation.locationName);
            }
        }
        #endregion

        #region Teleport Functionality
        public void TeleportPlayer(Transform teleportLocation)
        {
            playerController.enabled = false;
            player.SetPositionAndRotation(teleportLocation.position, teleportLocation.rotation);

            cam.position = teleportLocation.position;
            // cam.LookAt(teleportLocation.position + Vector3.up);
            playerController.enabled = true;
        }
        
        public void TeleportToClosestLocation()
        {
            Transform nearestLocation = null;
            float distance = float.MaxValue;
            float distanceCheck;
            
            foreach(TeleportLocation location in locations)
            {
                distanceCheck = Vector3.Distance(player.position, location.teleportLocation.position);
                if (distanceCheck < distance || nearestLocation == null)
                {
                    nearestLocation = location.teleportLocation;
                    distance = distanceCheck;
                }
            }
            
            TeleportPlayer(nearestLocation);
        }

        public void ChangeMenuIndicator(Vector3 worldPosition)
        {
            indicatorPosition.gameObject.SetActive(true);

            worldPosition.x = (worldPosition.x / 1000) * 450;
            worldPosition.y = (worldPosition.z / 1000) * 450;
            worldPosition.z = 0;

            indicatorPosition.localPosition = -worldPosition;
        }

        public void ResetIndicator()
        {
            indicatorPosition.gameObject.SetActive(false);
        }
        #endregion
    }
}