using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

namespace SunTemple
{
    public class Door : MonoBehaviour
    {
		public bool IsLocked = false;
        public bool DoorClosed = true;
        public float OpenRotationAmount = 90;
        public float RotationSpeed = 1f;
		private Collider DoorCollider;

		private GameObject Player;
		private Camera Cam;
		private CursorManager cursor;

        Vector3 StartRotation;
        float StartAngle = 0;
        float EndAngle = 0;
        float LerpTime = 1f;
        float CurrentLerpTime = 0;
        bool Rotating;

        [SerializeField] private StudioEventEmitter doorSoundOpen;
        [SerializeField] private StudioEventEmitter doorSoundClose;

		private bool scriptIsEnabled = true;

        void Start(){
            StartRotation = transform.localEulerAngles;
			DoorCollider = GetComponent<BoxCollider>();
        }

		void Update()
		{
			if (scriptIsEnabled) {
				if (Rotating) {
					Rotate ();
				}
			}
		} 

        public void Activate()
        {        
            if (DoorClosed)
            {
                Open();
                doorSoundOpen.Play();                
            }
            else
            {
                Close();
                doorSoundClose.Play();                
            }
        }

        void Rotate()
        {
            CurrentLerpTime += Time.deltaTime * RotationSpeed;
            if (CurrentLerpTime > LerpTime)
            {
                CurrentLerpTime = LerpTime;
            }

            float _Perc = CurrentLerpTime / LerpTime;

            float _Angle = CircularLerp.Clerp(StartAngle, EndAngle, _Perc);
            transform.localEulerAngles = new Vector3(transform.eulerAngles.x, _Angle, transform.eulerAngles.z);

			if (CurrentLerpTime == LerpTime) {
				Rotating = false;
				DoorCollider.enabled = true;
			}
        }

        void Open()
        {
			DoorCollider.enabled = false;
            DoorClosed = false;
            StartAngle = transform.localEulerAngles.y;
            EndAngle =  StartRotation.y + OpenRotationAmount;
            CurrentLerpTime = 0;
            Rotating = true;
        }

        void Close()
        {
			DoorCollider.enabled = false;
            DoorClosed = true;
            StartAngle = transform.localEulerAngles.y;
            EndAngle = transform.localEulerAngles.y - OpenRotationAmount;
            CurrentLerpTime = 0;
            Rotating = true;
        }
    }
}