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
    }

    public class Sandstorm : MonoBehaviour
    {
        [Header("Storm Behaviour")]
        public StormStates state;

        [Header("Sound Sources")]
        [SerializeField] private GameObject staticSoundSource;
        [SerializeField] private GameObject movingSoundSource;
    
        [Header("References")]
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
                Debug.Log("Player Entered Trigger");
                EnableStorm();     
            }
        }

        private void OnTriggerStay(Collider other)
        {

        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                DisableStorm();
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(movingSoundSource.transform.position, 0.5f);

            Gizmos.DrawSphere(staticSoundSource.transform.position, 0.5f);
        }
        #endregion

        #region Custom Functions
        private void EnableStorm()
        {
            staticParticles.Play();
            directionalParticles.Play();

            staticSoundSource.SetActive(true);

            state = StormStates.Active;
        }

        private void DisableStorm()
        {
            staticParticles.Stop();
            directionalParticles.Stop();
            staticSoundSource.SetActive(false);

            if (movingSoundSource.activeSelf)
            {
                movingSoundSource.SetActive(false);
            }

            state = StormStates.Idle;
        }

        private void MoveSoundSource()
        {
            movingSoundSource.transform.DOMove(transform.position, 1.0f).SetEase(Ease.Linear)
            .OnStart(() => {
                movingSoundSource.SetActive(true);
            })
            .OnComplete(() => {
                movingSoundSource.SetActive(false);
            });
        }
        #endregion
    }    
}