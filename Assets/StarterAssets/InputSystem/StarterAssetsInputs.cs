using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		// Player Locomotion
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		// Player Actions
		public bool interact;

		// Menu Actions
		public bool menu;

		[Header("Movement Settings")]
		public bool analogMovement;

#if ENABLE_INPUT_SYSTEM 
	private PlayerInput playerInput;
#endif

#if !UNITY_IOS || !UNITY_ANDROID
		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
#endif

#if ENABLE_INPUT_SYSTEM
	private void Awake()
	{
		playerInput = GetComponent<PlayerInput>();
	}

	private void OnEnable()
	{
		GameManager.instance.allJukeboxesCollected += ChangeToMenuInput;
	}

	private void OnDisable()
	{
		GameManager.instance.allJukeboxesCollected -= ChangeToMenuInput;
	}
#endif

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnChangeMenu(InputValue value)
		{
			GameMenuManager.instance.TriggerGameMenuVisability();
			switch (GameMenuManager.instance.GetCurrentVisability())
			{
				case true:
					playerInput.SwitchCurrentActionMap("Menu");
					break;

				case false:
					playerInput.SwitchCurrentActionMap("Player");
					break;
			}
		}

		public void OnInteract(InputValue value)
		{
			InteractInput(value.isPressed);
		}

		public void OnAddTime(InputValue value)
		{
			GameManager.instance?.AddClockTime();
		}

		public void OnRemoveTime(InputValue value)
		{
			GameManager.instance?.RemoveClockTime();
		}
#else
	// old input sys if we do decide to have it (most likely wont)...
#endif

		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void InteractInput(bool newInteractState)
		{
			interact = newInteractState;
		}

		private void ChangeToMenuInput()
		{
			playerInput.SwitchCurrentActionMap("Menu");
		}

#if !UNITY_IOS || !UNITY_ANDROID

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

#endif

	}
	
}