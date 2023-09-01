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
        private float defaultSpeed = 1.0f;

        [SerializeField]
        private float gravity = 9.81f; // -9.81

        /// <summary>
        /// The input actions
        /// </summary>
        private FPSPlayerInputActions _inputActions;

        private Vector2 _horizontalInput;

        private float _speed;

        private Transform _transform;

        private Vector3 _verticalVelocity = Vector3.zero;

        private bool _isGrounded;

        private void Awake()
        {
            _inputActions = new FPSPlayerInputActions();

            _inputActions.Movements.HorizontalMovement.performed += OnHorizontalMovementPerformed;

            _speed = defaultSpeed;

            _transform = transform;

            Enable();
        }

        /// <summary>
        /// Enable the player ability to move
        /// </summary>
        public void Enable()
        {
            _inputActions.Movements.Enable();
        }

        /// <summary>
        /// Disable the player ability to move
        /// </summary>
        public void Disable()
        {
            _inputActions.Movements.Disable();
        }

        private void Update()
        {
            var horizontalVelocity =
                (transform.right * _horizontalInput.x + _transform.forward * _horizontalInput.y) * _speed;

            _verticalVelocity.y += gravity * (3.058f / 2) * Time.deltaTime;

            characterController.Move(horizontalVelocity * Time.deltaTime);
            characterController.Move(_verticalVelocity * Time.deltaTime);
        }

        private void OnHorizontalMovementPerformed(InputAction.CallbackContext ctx)
        {
            _horizontalInput = ctx.ReadValue<Vector2>();
        }
    }
}