using UnityEngine;

namespace Tests.Scripts.Interactable
{
    /// <summary>
    /// Represent an interactable component
    /// </summary>
    public abstract class Interactable : MonoBehaviour
    {
        /// <summary>
        /// Get the flag value to indicate if the interactable is enabled
        /// </summary>
        /// <returns>TRUE if the interactable is enabled, FALSE otherwise</returns>
        public abstract bool IsEnabled();

        /// <summary>
        /// Try to interact with the interactable
        /// </summary>
        public abstract void Interact();
    }
}