using System.Collections;
using MyProject.Scripts.Players;
using UnityEngine;

namespace MyProject.Scripts.Cameras
{
    public class CameraController : MonoBehaviour
    {
        [Header("Follow")]
        [SerializeField] [Range(1f, 5f)] private float _angularSpeed;
        [SerializeField] private Transform _target;
        [SerializeField] private Vector3 _shiftPosition;

        [Header("Zoom")]
        [SerializeField] private Player _player;
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _noScopePosition;
        [SerializeField] private Transform _scopePosition;
        [SerializeField] private float _recoveryRate = 0.1f;
        [SerializeField] private float _meaningWaitForSeconds = 1f;

        [Header("Recoil")]
        [SerializeField] private float _recoilX = 0f;
        [SerializeField] private float _recoilY = 0f;
        [SerializeField] private float _recoilZ = 0.1f;

        [SerializeField] private float _snappiness;
        [SerializeField] private float _returnSpeed;
        [SerializeField] private Transform _fatherCamera;

        //Follow
        private float _angleY;

        //Zoom
        private WaitForSeconds _waitForSeconds;
        private readonly string _zoom = "Zoom";

        private Coroutine _coroutine;

        private Vector3 _currentPosition;
        private Vector3 _targetPosition;

        //Recoil
        private Vector3 _currentRotation;
        private Vector3 _targetRotation;

        void Start()
        {
            //Follow
            _angleY = transform.rotation.y;

            //Zoom
            _waitForSeconds = new WaitForSeconds(_meaningWaitForSeconds);
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.Q))
                _angleY -= _angularSpeed;

            if (Input.GetKey(KeyCode.E))
                _angleY += _angularSpeed;
        
            RotateCamera();
        
            //Shake logik
            _targetRotation = Vector3.Lerp(_targetRotation, Vector3.zero, _returnSpeed * Time.deltaTime);
            _currentRotation = Vector3.Slerp(_currentRotation, _targetRotation, _snappiness * Time.fixedDeltaTime);
            _camera.transform.localRotation = Quaternion.Euler(_currentRotation);
        
            if (Input.GetButton(_zoom))
            {
                _targetPosition = _scopePosition.position;
                ActivateZoom();
            
                if (Input.GetButton("Fire1"))
                {
                    Shake();
                }
            }
            else
            {
                _targetPosition = _noScopePosition.position;
                DeActivateZoom();
            }
        }

        #region FollowAndRotate

        private void RotateCamera()
        {
            transform.position = _target.transform.position;
            transform.rotation = Quaternion.Euler(0, _angleY, 0);
        }
        
        #endregion

        #region Zoom
        
        private void ActivateZoom()
        {
            StopCoroutine();
            _coroutine = StartCoroutine(ChangeCameraPosition(_targetPosition));
        }

        private void DeActivateZoom()
        {
            StopCoroutine();
            _coroutine = StartCoroutine(ChangeCameraPosition(_targetPosition));
        }

        private void StopCoroutine()
        {
            if (_coroutine == null)
            {
                return;
            }

            StopCoroutine(_coroutine);
        }

        private IEnumerator ChangeCameraPosition(Vector3 targetPosition)
        {
            while (_camera.transform.position != targetPosition)
            {
                _camera.transform.position = Vector3.MoveTowards(_camera.transform.position, targetPosition, _recoveryRate);

                yield return _waitForSeconds;
            }
        }

        #endregion

        #region Recoil

        private void Shake()
        {
            ShakeCamera();
        }

        private void ShakeCamera()
        {
            _targetRotation += new Vector3(_recoilX, Random.Range(-_recoilY, _recoilY), Random.Range(-_recoilZ, _recoilZ));
        }
        
        #endregion
    }
}