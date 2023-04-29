using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif


namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		private Vector2 _move;
		private Vector2 _look;
		private bool _jump;
		private bool _sprint;
		private bool _fire;

		[Header("Movement Settings"), SerializeField]
		private bool _analogMovement;

		[Header("Mouse Cursor Settings"), SerializeField]
		private bool _cursorLocked = true;
		[SerializeField]
		private bool _cursorInputForLook = true;

		private PlayerInput _playerInput;

		public Vector2 GetMove { get { return _move; } }
		public Vector2 GetLook { get { return _look; } }
		public bool GetSetJumpState { get { return _jump; } set { _jump = value; } }
		public bool GetSprintState { get { return _sprint; } }
		public bool GetFireState { get { return _fire; } }
		public bool GetAnalogMovement { get { return _analogMovement; } }

#if ENABLE_INPUT_SYSTEM

		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(_cursorInputForLook)
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

		public void OnFire(InputValue value)
        {
			FireInput(value.isPressed);
			Debug.Log("FIre");
        }
#endif

		private void MoveInput(Vector2 newMoveDirection)
		{
			_move = newMoveDirection;
		}

		private void LookInput(Vector2 newLookDirection)
		{
			_look = newLookDirection;
		}

		private void JumpInput(bool newJumpState)
		{
			_jump = newJumpState;
		}

		private void SprintInput(bool newSprintState)
		{
			_sprint = newSprintState;
		}

		private void FireInput(bool newFireState)
        {
			_fire = newFireState;
        }

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(_cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}

}