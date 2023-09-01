using UnityEngine;

namespace Tests.Scripts.Prefabs.RotatingCube
{
    public class RotatingCube : Interactable.Interactable
    {
        [SerializeField]
        private bool rotate = true;

        private float _timer;
        private bool _up = true;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            if (!rotate) return;

            var acc = Time.deltaTime * 0.10f;

            _timer += acc;

            if (_timer > 0.25)
            {
                _timer = 0.0f;
                _up = !_up;
            }

            _transform.Translate(_up ? new Vector3(0, acc, 0) : new Vector3(0, -acc, 0));
            _transform.Rotate(new Vector3(0, Time.deltaTime * 10, 0));
        }

        public override bool IsEnabled()
        {
            return true;
        }

        public override void Interact()
        {
            Debug.Log("Interact with rotating cube");
        }
    }
}