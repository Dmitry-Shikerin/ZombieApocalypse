using UnityEngine;

namespace MyProject.OldScripts.Scripts.Player.PlayerCamera
{
    [RequireComponent(typeof(Camera))]
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Transform _targetPlayer;

        private Transform _targetLookAt;
        private Vector3 _currentTargetPosition;
        private Vector3 _offSet;

        private float _defaultDistans;
        private float _defaultHeight;
        private float _mouseY;
        private float _mouseX;
        private float _smoothFollow;
        public float _xMouseSensitivity;
        public float _yMouseSensitivity;

        private Camera _camera;

        private void Awake()
        {
            _camera = GetComponent<Camera>();

            _defaultDistans = 2.5f;
            _defaultHeight = 2.5f;
            _mouseX = 0f;
            _mouseX = 0f;
            _smoothFollow = 10f;
            _xMouseSensitivity = 3f;
            _yMouseSensitivity = 3f;
            _offSet = new Vector3(-_defaultDistans, -_defaultDistans, -_defaultDistans);
        }

        void Start()
        {

        }

        void Update()
        {
        }

        private void FixedUpdate()
        {
            var Y = Input.GetAxis("Mouse Y");
            var X = Input.GetAxis("Mouse X");

            Vector3 rotateDirection = new Vector3(X, Y, 0);

            RotateToDirection(rotateDirection, 5f);

        }

        private Vector3 SetCameraPosition()
        {
            Vector3 startPosition = _targetPlayer.position - _offSet;

            return startPosition;
        }

        public void RotateToDirection(Vector3 direction, float rotationSpeed)
        {
            direction.y = 0f;

            Vector3 desiredForward = Vector3.RotateTowards(transform.forward,
                direction.normalized, rotationSpeed * Time.deltaTime, .1f);

            Quaternion newRotation = Quaternion.LookRotation(desiredForward);

            transform.rotation = newRotation;
        }
    }
}
