using System;
using UnityEngine;

namespace Tests.Scripts.Prefabs.Players.FPSPlayer
{
    /// <summary>
    /// The component to manage FPS player FOV
    /// </summary>
    public class FpsPlayerPov : MonoBehaviour
    {
        /// <summary>
        /// The default FOV value
        /// </summary>
        [SerializeField]
        [Range(FpsPlayerConstants.Fov.Min, FpsPlayerConstants.Fov.Max)]
        private float defaultFov = FpsPlayerConstants.Fov.Default;

        [field: SerializeField]
        public bool Editable { get; set; } = true;

        /// <summary>
        /// The camera that can be used as player eyes
        /// </summary>
        [SerializeField]
        private Camera eyes;

        private void Start()
        {
            SetFov(defaultFov);

            var inputActions = new FPSPlayerInputActions();

            inputActions.Enable();
        }

        /// <summary>
        /// Get the current FOV value
        /// </summary>
        /// <returns>The current FOV value</returns>
        public float GetFov()
        {
            return eyes.fieldOfView;
        }

        /// <summary>
        /// Set the new FOV value
        /// </summary>
        /// <param name="value">The new FOV value</param>
        public void SetFov(float value)
        {
            if (!Editable) return;

            eyes.fieldOfView = Math.Clamp(value, FpsPlayerConstants.Fov.Min, FpsPlayerConstants.Fov.Max);
        }
    }
}