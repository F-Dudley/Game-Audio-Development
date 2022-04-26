using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Storms
{
    public enum StormStates
    {
        Idle,
        Active,
        Inactive
    }

    public class Sandstorm : MonoBehaviour
    {
        [Header("Storm Behaviour")]
        public StormStates state;
        public LayerMask triggerLayer;

        [SerializeField] private Vector3 triggerStartLocation;
        [SerializeField] private Vector3 triggerEndLocation;

        [Header("Sound Sources")]
        [SerializeField] private GameObject staticSoundSource;
        [SerializeField] private GameObject movingSoundSource;
    
        [Header("References")]
        [SerializeField] private GameObject triggerObject;
        [SerializeField] private ParticleSystem staticParticles;
        [SerializeField] private ParticleSystem directionalParticles;

        #region Unity Functions
        private void Start()
        {
            state = StormStates.Idle;

            movingSoundSource.SetActive(false);
        }

        private void Update()
        {
            if (state == StormStates.Active && !movingSoundSource.activeSelf)
            {
                MoveSoundSource();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player Entered Storm Trigger");

                switch (state)
                {
                    case StormStates.Idle:
                            EnableStorm();                    
                        break;

                    case StormStates.Active:
                            DisableStorm();
                        break;

                    case StormStates.Inactive:
                        break;

                    default:
                        break;
                }                
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(GetTriggerEndLocation(), 0.5f);

            Gizmos.color = Color.green;
            Gizmos.DrawSphere(movingSoundSource.transform.position, 0.5f);
        }
        #endregion

        #region Custom Functions
        private Vector3 GetTriggerEndLocation() => transform.position + triggerEndLocation;

        private void EnableStorm()
        {
            staticParticles.Play();
            directionalParticles.Play();

            staticSoundSource.SetActive(true);

            triggerObject.transform.position = GetTriggerEndLocation();
            state = StormStates.Active;
        }

        private void DisableStorm()
        {
            staticParticles.Stop();
            directionalParticles.Stop();
            staticSoundSource.SetActive(false);

            triggerObject.SetActive(false);
            state = StormStates.Inactive;
        }

        private void MoveSoundSource()
        {
            movingSoundSource.transform.DOMove(transform.position, 1.0f).SetEase(Ease.Linear)
            .OnComplete(() => {
                movingSoundSource.SetActive(false);
            });
        }
        #endregion
    }    
}