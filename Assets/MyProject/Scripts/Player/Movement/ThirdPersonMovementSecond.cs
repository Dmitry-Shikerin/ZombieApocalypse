using UnityEngine;

namespace MyProject.Scripts.Player.Movement
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Animator))]
    public class ThirdPersonMovementSecond : MonoBehaviour
    {
        [SerializeField] private Transform _camera;
        [SerializeField] private MovementCharacteristics _characteristics;

        private const float _distanseOffsetCamera = 5f;

        private float _verticalInput;
        private float _horizontalInput;
        private float _runInput;

        private readonly string _vertical = "Vertical";
        private readonly string _horizontal = "Horizontal";
        
        private readonly string _speed = "Speed";

        private readonly string _run = "Run";
        private readonly string _jump = "Jump";
        private readonly string _scope = "Zoom";

        private CharacterController _characterController;
        private Animator _animator;

        private Vector3 _direction;
        private Quaternion _look;

        private Vector3 TargetRotate => _direction;
        private Vector3 TargetRotateScope => _camera.forward * _distanseOffsetCamera;
        private bool Idle => _horizontalInput == 0.0f && _verticalInput == 0.0f;

        void Start()
        {
            _characterController = GetComponent<CharacterController>();
            _animator = GetComponent<Animator>();

            Cursor.visible = _characteristics.VisibleCursor;
        }

        void Update()
        {
            if (Input.GetButton(_scope))
            {
                ScopeMovement();
                ScopeRotate();
            }
            
            Movement();
            Rotate();
        }

        #region NoScopeMovement
        private void Movement()
        {
            if (_characterController.isGrounded)
            {
                _horizontalInput = Input.GetAxis(_horizontal);
                _verticalInput = Input.GetAxis(_vertical);
                _runInput = Input.GetAxis(_run);

                _direction = _camera.TransformDirection(_horizontalInput, 0, _verticalInput).normalized;

                PlayAnimation();
                Jump();
            }

            _direction.y -= _characteristics.Gravity * Time.deltaTime;

            float speed = _runInput * _characteristics.RunSpeed + _characteristics.MovementSpeed;
            Vector3 direction = _direction * speed * Time.deltaTime;

            direction.y = _direction.y;

            _characterController.Move(direction);
        }

        private void Rotate()
        {
            //не поворачивает игрока если стоим на месте
            if (Idle)
                return;

            Vector3 target = TargetRotate;
            target.y = 0;

            _look = Quaternion.LookRotation(target);

            float speed = _characteristics.AngularSpeed * Time.deltaTime;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, _look, speed);
        }

        private void Jump()
        {
            if (Input.GetButtonDown(_jump))
            {
                _animator.SetTrigger(_jump);
                _direction.y += _characteristics.JumpForce;
            }
        }

        private void PlayAnimation()
        {
            float maxMovementValue = Mathf.Max(Mathf.Abs(_horizontalInput), Mathf.Abs(_verticalInput));
            float speedInput = _runInput * maxMovementValue + maxMovementValue;

            _animator.SetFloat(_speed, speedInput);
        }
        #endregion

        #region ScopeMovement
        private void ScopeMovement()
        {
            if (_characterController.isGrounded)
            {
                _horizontalInput = Input.GetAxis(_horizontal);
                _verticalInput = Input.GetAxis(_vertical);
                _runInput = Input.GetAxis(_run);

                _direction = transform.TransformDirection(_horizontalInput, 0, _verticalInput).normalized;
            
                ScopePlayAnimation();
                ScopeJump();
            }

            _direction.y -= _characteristics.Gravity * Time.deltaTime;
        
            float speed = _runInput * _characteristics.RunSpeed + _characteristics.MovementSpeed;
            Vector3 direction = _direction * speed * Time.deltaTime;

            direction.y = _direction.y;
        
            _characterController.Move(direction);
        }

        private void ScopeRotate()
        {
            Vector3 target = TargetRotateScope;
            target.y = 0;
        
            _look = Quaternion.LookRotation(target);

            float speed = _characteristics.AngularSpeed * Time.deltaTime;
        
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _look, speed);

            transform.rotation = _camera.rotation;
        }

        private void ScopeJump()
        {
            if (Input.GetButtonDown(_jump))
            {
                _animator.SetTrigger(_jump);
                _direction.y += _characteristics.JumpForce;
            }
        }

        private void ScopePlayAnimation()
        {
            float horizontalInput = _runInput * _horizontalInput + _horizontalInput;
            float verticalInput = _runInput * _verticalInput + _verticalInput;
        
            _animator.SetFloat(_vertical, verticalInput);
            _animator.SetFloat(_horizontal, horizontalInput);
        }
        #endregion
    }
}
