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

        private void Awake()
        {
			TryGetComponent(out _playerInput);
        }

        private void OnEnable()
        {
			_playerInput.actions["Move"].performed += OnMove;
			_playerInput.actions["Move"].canceled += OnMoveStop;
			_playerInput.actions["Jump"].performed += OnJump;
			_playerInput.actions["Look"].performed += OnLook;
			_playerInput.actions["Sprint"].performed += OnSprint;
			_playerInput.actions["Sprint"].canceled += OnSprintStop;
			_playerInput.actions["Fire"].performed += OnFire;
			_playerInput.actions["Fire"].canceled += OnFireStop;
		}

        private void OnDisable()
        {
			_playerInput.actions["Move"].performed -= OnMove;
			_playerInput.actions["Move"].canceled -= OnMoveStop;
			_playerInput.actions["Jump"].started += OnJump;
			_playerInput.actions["Look"].performed -= OnLook;
			_playerInput.actions["Sprint"].performed += OnSprint;
			_playerInput.actions["Sprint"].canceled -= OnSprintStop;
			_playerInput.actions["Fire"].performed -= OnFire;
			_playerInput.actions["Fire"].canceled -= OnFireStop;
		}

        public void OnMove(InputAction.CallbackContext context)
		{
			MoveInput(context.ReadValue<Vector2>());
		}

		public void OnLook(InputAction.CallbackContext context)
		{
			if(_cursorInputForLook)
			{
				LookInput(context.ReadValue<Vector2>());
			}
		}

		public void OnJump(InputAction.CallbackContext context)
		{
			JumpInput(context.ReadValueAsButton());
		}

		public void OnSprint(InputAction.CallbackContext context)
		{
			SprintInput(context.ReadValueAsButton());
		}

		public void OnFire(InputAction.CallbackContext context)
        {
			FireInput(context.ReadValueAsButton());
        }

		public void OnMoveStop(InputAction.CallbackContext context)
		{
			_move = Vector2.zero;
		}

		public void OnSprintStop(InputAction.CallbackContext context)
        {
			_sprint = false;
        }

		public void OnFireStop(InputAction.CallbackContext context)
        {
			_fire = false;
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