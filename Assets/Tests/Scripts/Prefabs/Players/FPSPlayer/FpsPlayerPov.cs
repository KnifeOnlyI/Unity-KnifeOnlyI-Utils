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
        /// The minimum FOV value
        /// </summary>
        private const float MinFov = 1.0f;

        /// <summary>
        /// The maximum FOV value
        /// </summary>
        private const float MaxFov = 360.0f;

        /// <summary>
        /// The default FOV value
        /// </summary>
        [SerializeField]
        [Range(MinFov, MaxFov)]
        private float defaultFov = 90;

        /// <summary>
        /// The camera that can be used as player eyes
        /// </summary>
        [SerializeField]
        private Camera eyes;

        private void Start()
        {
            SetFov(defaultFov);
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
            eyes.fieldOfView = Math.Clamp(value, MinFov, MaxFov);
        }
    }
}