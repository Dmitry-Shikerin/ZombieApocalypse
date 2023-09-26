using UnityEngine;

namespace MyProject.Scripts.Player.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] [Range(1f, 5f)] private float _angularSpeed;
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _shiftPosition;

        private float _angleY;

        void Start()
        {
            _angleY = transform.rotation.y;
        }

        void Update()
        {
            if(Input.GetKey(KeyCode.Q))
                _angleY -= _angularSpeed;

            if (Input.GetKey(KeyCode.E))
                _angleY += _angularSpeed;

            transform.position = _target.transform.position + _shiftPosition;
            transform.rotation = Quaternion.Euler(0, _angleY, 0);
        }
    }
}
