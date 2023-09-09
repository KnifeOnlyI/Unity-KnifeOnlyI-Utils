using System;
using UnityEngine;

namespace KnifeOnlyI.Utils.Players.FpsPlayerFreeCamera
{
    /// <summary>
    /// A component to manage an FPS Player with free camera movements/look.
    /// </summary>
    public class FpsPlayerFreeCameraMoveLook : MonoBehaviour
    {
        #region Static values

        /// <summary>
        /// The look sensitivity internal multiplier
        /// </summary>
        private const float SensitivityMultiplier = 3.0f;

        /// <summary>
        /// The minimum look sensitivity value
        /// </summary>
        private const float MinSensitivity = 0.1f;

        /// <summary>
        /// The maximum look sensitivity value
        /// </summary>
        private const float MaxSensitivity = 20.0f;

        /// <summary>
        /// The minimum movements speed value
        /// </summary>
        private const float MinMovementsSpeed = 1.0f;

        /// <summary>
        /// The maximum movements speed value
        /// </summary>
        private const float MaxMovementsSpeed = 50.0f;

        /// <summary>
        /// The maximum FOV value
        /// </summary>
        private const float MaxFov = 360.0f;

        /// <summary>
        /// The minimum FOV value
        /// </summary>
        private const float MinFov = 1.0f;

        #endregion

        #region Editor properties

        /// <summary>
        /// The camera used as player eyes
        /// </summary>
        [SerializeField]
        private Camera eyes;

        /// <summary>
        /// The default look sensitivity
        /// </summary>
        [SerializeField]
        [Range(MinSensitivity, MaxSensitivity)]
        private float defaultLookSensitivity = 10.0f;

        /// <summary>
        /// The default movements speed
        /// </summary>
        [SerializeField]
        [Range(MinMovementsSpeed, MaxMovementsSpeed)]
        private float defaultMovementsSpeed = 2.0f;

        /// <summary>
        /// The default FOV
        /// </summary>
        [SerializeField]
        [Range(MinFov, MaxFov)]
        private float defaultFov = 90.0f;

        #endregion

        #region Private properties

        /// <summary>
        /// The sensitivity value
        /// </summary>
        private float _lookSensitivity;

        /// <summary>
        /// The current movements speed
        /// </summary>
        private float _movementsSpeed;

        /// <summary>
        /// The input actions
        /// </summary>
        private FpsPlayerFreeCameraInputActions _inputActions;

        /// <summary>
        /// The current X rotation
        /// </summary>
        private float _xRotation;

        /// <summary>
        /// The transform
        /// </summary>
        private Transform _transform;

        /// <summary>
        /// The transform of eyes camera
        /// </summary>
        private Transform _eyesTransform;

        #endregion

        #region Unity Events

        private void Awake()
        {
            _transform = transform;
            _eyesTransform = eyes.transform;

            _inputActions = new FpsPlayerFreeCameraInputActions();

            SetSensitivity(defaultLookSensitivity);
            SetSpeed(defaultMovementsSpeed);
            SetFov(defaultFov);
        }

        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _inputActions.Movements.Enable();
        }

        private void OnDisable()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            _inputActions.Movements.Disable();
        }

        private void Update()
        {
            UpdateMovementsSpeed(GetSetMovementsSpeedDirection());

            ApplyLookRotations(GetLookRotationInputVector());

            ApplyMovements(GetHorizontalMovementsVector(), GetVerticalMovementsVector());
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Get the look rotation input vector.
        /// </summary>
        /// <returns>The value</returns>
        private Vector2 GetLookRotationInputVector()
        {
            return new Vector2
            {
                x = _inputActions.Movements.LookHorizontal.ReadValue<float>() * _lookSensitivity * Time.deltaTime,
                y = _inputActions.Movements.LookVertical.ReadValue<float>() * _lookSensitivity * Time.deltaTime
            };
        }

        /// <summary>
        /// Get the horizontal movements input vector.
        /// </summary>
        /// <returns>The value</returns>
        private Vector2 GetHorizontalMovementsVector()
        {
            return _movementsSpeed * Time.deltaTime * _inputActions.Movements.HorizontalMovements.ReadValue<Vector2>();
        }

        /// <summary>
        /// Get the vertical movements input vector.
        /// </summary>
        /// <returns>The value</returns>
        private float GetVerticalMovementsVector()
        {
            return _inputActions.Movements.VerticalMovements.ReadValue<float>();
        }

        /// <summary>
        /// Get the update movements speed direction value.
        /// </summary>
        /// <returns>The value</returns>
        private float GetSetMovementsSpeedDirection()
        {
            return _inputActions.Movements.SetMovementsSpeed.ReadValue<Vector2>().y;
        }

        /// <summary>
        /// Update the movements speed according to the specified direction.
        /// If the direction is greater than 0, increase movements speed of 1.0f. 
        /// If the direction is lower than 0, decrease movements speed of 1.0f.
        /// Else do not update the movements speed.
        /// </summary>
        /// <param name="direction">The speed movements update direction</param>
        private void UpdateMovementsSpeed(float direction)
        {
            switch (direction)
            {
                case > 0:
                    SetSpeed(_movementsSpeed + 1.0f);
                    break;
                case < 0:
                    SetSpeed(_movementsSpeed - 1.0f);
                    break;
            }
        }

        /// <summary>
        /// Apply the movements
        /// </summary>
        /// <param name="horizontalMovements">The horizontal movements value</param>
        /// <param name="verticalMovements">The vertical movements value</param>
        private void ApplyMovements(Vector2 horizontalMovements, float verticalMovements)
        {
            ApplyHorizontalMovements(horizontalMovements);
            ApplyVerticalMovements(verticalMovements);
        }

        /// <summary>
        /// Apply the horizontal movement
        /// </summary>
        /// <param name="movement">The horizontal movement value</param>
        private void ApplyHorizontalMovements(Vector2 movement)
        {
            var forwardBackwardVector = movement.y * _eyesTransform.forward;
            var leftRightVector = movement.x * Vector3.right;

            _transform.position += forwardBackwardVector;

            _transform.Translate(leftRightVector);
        }

        /// <summary>
        /// Apply the vertical movement
        /// </summary>
        /// <param name="movement">The vertical movement value</param>
        private void ApplyVerticalMovements(float movement)
        {
            _transform.Translate(movement * _movementsSpeed * Time.deltaTime * Vector3.up);
        }

        /// <summary>
        /// Apply look rotations
        /// </summary>
        /// <param name="rotation">The rotations values</param>
        private void ApplyLookRotations(Vector2 rotation)
        {
            ApplyHorizontalRotation(rotation);
            ApplyVerticalRotation(rotation);
        }

        /// <summary>
        /// Apply the horizontal rotation
        /// </summary>
        private void ApplyHorizontalRotation(Vector2 rotation)
        {
            _transform.Rotate(Vector3.up, rotation.x);
        }

        /// <summary>
        /// Apply the vertical rotation
        /// </summary>
        private void ApplyVerticalRotation(Vector2 rotation)
        {
            _xRotation -= rotation.y;
            _xRotation = Mathf.Clamp(_xRotation, -90, 90);

            _eyesTransform.eulerAngles = new Vector3
            {
                x = _xRotation,
                y = _transform.eulerAngles.y,
                z = 0
            };
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Set the new sensitivity value
        /// </summary>
        /// <param name="value">The new value</param>
        public void SetSensitivity(float value)
        {
            _lookSensitivity = Math.Clamp(value, MinSensitivity, MaxSensitivity) * SensitivityMultiplier;
        }

        /// <summary>
        /// Set the new movements speed value
        /// </summary>
        /// <param name="value">The new value</param>
        public void SetSpeed(float value)
        {
            _movementsSpeed = Math.Clamp(value, MinMovementsSpeed, MaxMovementsSpeed);
        }

        /// <summary>
        /// Set the new FOV value
        /// </summary>
        /// <param name="value">The new value</param>
        public void SetFov(float value)
        {
            eyes.fieldOfView = Math.Clamp(value, MinFov, MaxFov);
        }

        #endregion
    }
}