using UnityEngine;

namespace MyProject.OldScripts.Scripts.Player.PlayerMovement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody _rigidbody;

        private Vector3 _moveDirection;
        private Quaternion _rotation;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            _rotation = _rigidbody.rotation;
        }

        void Start()
        {

        }

        void Update()
        {
            PlayerMover();
        }

        private void PlayerMover()
        {
            _moveDirection.z = Input.GetAxis("Horizontal");
            _moveDirection.x = Input.GetAxis("Vertical");

            _moveDirection.y = 0;
            _moveDirection.x = Mathf.Clamp(_moveDirection.x, -1f, 1f);
            _moveDirection.z = Mathf.Clamp(_moveDirection.z, -1f, 1f);

            _rotation.x = 0;
            _rotation.y = 0;
            _rotation.z = 0;

            Vector3 directionVector = new Vector3(_moveDirection.x, 0, -_moveDirection.z);

            _rigidbody.MovePosition(_rigidbody.position + directionVector * Time.deltaTime * _speed);

            RotateToDirection(directionVector, 10f);
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
