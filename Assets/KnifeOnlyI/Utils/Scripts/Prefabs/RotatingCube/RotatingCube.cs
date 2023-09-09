using UnityEngine;

namespace KnifeOnlyI.Utils.KnifeOnlyI.Utils.Scripts.Prefabs.RotatingCube
{
    public class RotatingCube : MonoBehaviour
    {
        [SerializeField]
        private Transform cube;

        private float _timer;
        private bool _up = true;

        private void Update()
        {
            var acc = Time.deltaTime * 0.10f;

            _timer += acc;
            
            if (_timer > 0.25)
            {
                _timer = 0.0f;
                _up = !_up;
            }

            cube.Translate(_up ? new Vector3(0, acc, 0) : new Vector3(0, -acc, 0));
            cube.Rotate(new Vector3(0, Time.deltaTime * 10, 0));
        }
    }
}