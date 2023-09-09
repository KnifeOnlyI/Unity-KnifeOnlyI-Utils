using UnityEngine;
using UnityEngine.InputSystem;

namespace Tests.Scripts.Prefabs.Players.FPSPlayer
{
    /// <summary>
    /// The component to manage FPS player movements
    /// </summary>
    public class FpsPlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private CharacterController characterController;

        [SerializeField]
        private float initialWalkSlowSpeed = 0.5f;

        [SerializeField]
        private float initialWalkSpeed = 1.0f;

        [SerializeField]
        private float initialRunSpeed = 3.0f;

        [SerializeField]
        private float initialCrouchSpeed = 0.3f;

        [SerializeField]
        private float initialGravity = 9.81f;

        /// <summary>
        /// The input actions
        /// </summary>
        private FPSPlayerInputActions _inputActions;

        private Vector2 _horizontalInput;

        private float _gravity;

        private float _speed;

        private Transform _transform;

        private Vector3 _verticalVelocity = Vector3.zero;

        private bool _isGrounded;

        private void Awake()
        {
            _inputActions = new FPSPlayerInputActions();

            _inputActions.Movements.HorizontalMovement.performed += OnHorizontalMovementPerformed;

            _speed = initialWalkSpeed;
            _gravity = initialGravity;

            _transform = transform;

            Enable();
        }

        /// <summary>
        /// Enable the player ability to move
        /// </summary>
        public void Enable()
        {
            _inputActions.Movements.Enable();
            _inputActions.Actions.Enable();
        }

        /// <summary>
        /// Disable the player ability to move
        /// </summary>
        public void Disable()
        {
            _inputActions.Movements.Disable();
            _inputActions.Actions.Disable();
        }

        private void Update()
        {
            var horizontalVelocity =
                (transform.right * _horizontalInput.x + _transform.forward * _horizontalInput.y) * _speed;

            _verticalVelocity.y += -_gravity * (3.058f / 2) * Time.deltaTime;

            characterController.Move(horizontalVelocity * Time.deltaTime);
            characterController.Move(_verticalVelocity * Time.deltaTime);

            if (_inputActions.Actions.Crouch.WasPressedThisFrame())
            {
                OnCrouchButtonPressed();
            }
            else if (_inputActions.Actions.Crouch.WasReleasedThisFrame())
            {
                OnCrouchButtonReleased();
            }

            if (_inputActions.Actions.Run.WasPressedThisFrame())
            {
                OnRunButtonPressed();
            }
            else if (_inputActions.Actions.Run.WasReleasedThisFrame())
            {
                OnRunButtonReleased();
            }

            if (_inputActions.Actions.WalkSlow.WasPressedThisFrame())
            {
                OnWalkSlowButtonPressed();
            }
            else if (_inputActions.Actions.WalkSlow.WasReleasedThisFrame())
            {
                OnWalkSlowButtonReleased();
            }
        }

        private void OnHorizontalMovementPerformed(InputAction.CallbackContext ctx)
        {
            _horizontalInput = ctx.ReadValue<Vector2>();
        }

        private void OnWalkSlowButtonPressed()
        {
            _speed = initialWalkSlowSpeed;
        }

        private void OnWalkSlowButtonReleased()
        {
            _speed = initialWalkSpeed;
        }

        private void OnRunButtonPressed()
        {
            _speed = initialRunSpeed;
        }

        private void OnRunButtonReleased()
        {
            _speed = initialWalkSpeed;
        }

        private void OnCrouchButtonPressed()
        {
            _speed = initialCrouchSpeed;
        }

        private void OnCrouchButtonReleased()
        {
            _speed = initialWalkSpeed;
        }
    }
}