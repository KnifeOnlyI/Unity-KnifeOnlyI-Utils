using UnityEngine;
using UnityEngine.InputSystem;

namespace Tests.Scripts.Prefabs.Players.FPSPlayer
{
    /// <summary>
    /// The component to manage FPS player interactions
    /// </summary>
    public class FpsPlayerInteraction : MonoBehaviour
    {
        /// <summary>
        /// The origin position of interaction raycast.
        /// </summary>
        [SerializeField]
        private Transform raycastOrigin;

        /// <summary>
        /// The maximum distance of interaction raycast.
        /// </summary>
        [SerializeField]
        [Range(
            FpsPlayerConstants.Interactions.MinInteractionDistance,
            FpsPlayerConstants.Interactions.MaxInteractionDistance
        )]
        private float maxInteractionDistance = FpsPlayerConstants.Interactions.DefaultInteractionDistance;

        /// <summary>
        /// The raycast hit.
        /// </summary>
        private RaycastHit _hit;

        /// <summary>
        /// The player's input actions.
        /// </summary>
        private FPSPlayerInputActions _inputActions;

        private bool _hasTarget;

        private Interactable.Interactable _interactable;

        private void Awake()
        {
            _inputActions = new FPSPlayerInputActions();

            _inputActions.Actions.Interact.performed += OnInteractPerformed;

            Enable();
        }

        /// <summary>
        /// Enable the player ability to move
        /// </summary>
        public void Enable()
        {
            _inputActions.Actions.Enable();
        }

        /// <summary>
        /// Disable the player ability to move
        /// </summary>
        public void Disable()
        {
            _inputActions.Actions.Disable();
        }

        private void OnInteractPerformed(InputAction.CallbackContext ctx)
        {
            if (!_hasTarget || !_interactable.IsEnabled()) return;
            
            _interactable.Interact();
        }

        private void Update()
        {
            if (raycastOrigin == null || !_inputActions.Actions.enabled) return;

            var interactable = GetInteractable();

            _hasTarget = interactable;

            if (!_hasTarget) return;

            _interactable = interactable;

            Debug.DrawLine(raycastOrigin.position, _hit.point, Color.green);
        }

        /// <summary>
        /// Get the interactable object (null if not touched by the raycast)
        /// </summary>
        /// <returns>The nullable interactable object</returns>
        private Interactable.Interactable GetInteractable()
        {
            var raycastOriginPosition = raycastOrigin.position;
            var raycastOriginForward = raycastOrigin.forward;

            Debug.DrawRay(raycastOriginPosition, raycastOriginForward * maxInteractionDistance, Color.red);

            var hitTouched = Physics.Raycast(
                raycastOriginPosition,
                raycastOriginForward,
                out _hit,
                maxInteractionDistance
            );

            if (!hitTouched) return null;

            var interactable = _hit.collider.GetComponent<Interactable.Interactable>();

            if (interactable == null || !interactable.IsEnabled()) return null;

            return interactable;
        }
    }
}