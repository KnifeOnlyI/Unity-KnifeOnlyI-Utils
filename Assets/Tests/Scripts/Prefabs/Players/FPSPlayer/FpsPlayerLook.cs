using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tests.Scripts.Prefabs.Players.FPSPlayer
{
    /// <summary>
    /// The component to manage FPS player look
    /// </summary>
    public class FpsPlayerLook : MonoBehaviour
    {
        /// <summary>
        /// The sensitivity internal multiplier
        /// </summary>
        private const float SensitivityMultiplier = 3.0f;

        /// <summary>
        /// The minimum sensitivity value
        /// </summary>
        private const float MinSensitivity = 0.1f;

        /// <summary>
        /// The maximum sensitivity value
        /// </summary>
        private const float MaxSensitivity = 20.0f;

        /// <summary>
        /// The transform that can be used as player root component
        /// </summary>
        [SerializeField]
        private Transform root;

        /// <summary>
        /// The camera that can be used as player eyes
        /// </summary>
        [SerializeField]
        private Camera eyes;

        /// <summary>
        /// The default look sensitivity
        /// </summary>
        [SerializeField]
        [Range(MinSensitivity, MaxSensitivity)]
        private float defaultSensitivity = 10.0f;

        /// <summary>
        /// The transform
        /// </summary>
        private Transform _transform;

        /// <summary>
        /// The transform of eyes camera
        /// </summary>
        private Transform _eyesTransform;

        /// <summary>
        /// The input actions
        /// </summary>
        private FPSPlayerInputActions _inputActions;

        /// <summary>
        /// The mouse input values
        /// </summary>
        private Vector2 _mouseInput;

        /// <summary>
        /// The current X rotation
        /// </summary>
        private float _xRotation;

        /// <summary>
        /// The sensitivity value
        /// </summary>
        private float _sensitivity;

        private void Awake()
        {
            _transform = transform;
            _eyesTransform = eyes.transform;

            SetSensitivity(defaultSensitivity);

            _inputActions = new FPSPlayerInputActions();

            _inputActions.Movements.LookHorizontal.performed += OnLookHorizontalPerformed;
            _inputActions.Movements.LookVertical.performed += OnLookVerticalPerformed;

            Enable();
        }

        private void Update()
        {
            ApplyHorizontalRotation();
            ApplyVerticalRotation();
        }

        /// <summary>
        /// Enable the player ability to look
        /// </summary>
        public void Enable()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            _inputActions.Movements.Enable();
        }

        /// <summary>
        /// Disable the player ability to look
        /// </summary>
        public void Disable()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            _inputActions.Movements.Disable();
        }

        /// <summary>
        /// Executed when a vertical look input event is emitted
        /// </summary>
        /// <param name="ctx">The input action context</param>
        private void OnLookVerticalPerformed(InputAction.CallbackContext ctx)
        {
            _mouseInput.y = ctx.ReadValue<float>() * _sensitivity;
        }

        /// <summary>
        /// Executed when an horizontal look input event is emitted
        /// </summary>
        /// <param name="ctx">The input action context</param>
        private void OnLookHorizontalPerformed(InputAction.CallbackContext ctx)
        {
            _mouseInput.x = ctx.ReadValue<float>() * _sensitivity;
        }

        /// <summary>
        /// Apply the horizontal rotation
        /// </summary>
        private void ApplyHorizontalRotation()
        {
            root.Rotate(Vector3.up, _mouseInput.x * Time.deltaTime);
        }

        /// <summary>
        /// Apply the vertical rotation
        /// </summary>
        private void ApplyVerticalRotation()
        {
            _xRotation -= _mouseInput.y * Time.deltaTime;

            _xRotation = Mathf.Clamp(_xRotation, -90, 90);

            var targetRotation = _transform.eulerAngles;
            targetRotation.x = _xRotation;

            _eyesTransform.eulerAngles = targetRotation;
        }

        /// <summary>
        /// Set the new sensitivity value
        /// </summary>
        /// <param name="value">The new sensitivity value</param>
        public void SetSensitivity(float value)
        {
            _sensitivity = Math.Clamp(value, MinSensitivity, MaxSensitivity) * SensitivityMultiplier;
        }

        /// <summary>
        /// Get the sensitivity
        /// </summary>
        /// <returns>The sensitivity</returns>
        public float GetSensitivity()
        {
            return _sensitivity;
        }
    }
}