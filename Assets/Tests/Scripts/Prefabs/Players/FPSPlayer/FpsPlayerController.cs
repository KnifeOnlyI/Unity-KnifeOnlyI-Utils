using UnityEngine;

namespace Tests.Scripts.Prefabs.Players.FPSPlayer
{
    public class FpsPlayerController : MonoBehaviour
    {
        private void Start()
        {
            var inputActions = new FPSPlayerInputActions();

            inputActions.Enable();
        }
    }
}