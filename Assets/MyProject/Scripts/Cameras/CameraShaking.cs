using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MyProject.Scripts.Cameras
{
    public class CameraShaking : MonoBehaviour
    {
        [SerializeField] private float _recoveryRate = 0.2f;
        [SerializeField] private float _valueWaitForSeconds;
        [SerializeField] private float _shakeAmplitude = 1f;

        private WaitForSeconds _waitForSeconds;
        private Vector3 _currentOffset;
        private Vector3 _startPosition;
        private Vector3 _destination;

        private void Start()
        {
            _waitForSeconds = new WaitForSeconds(_valueWaitForSeconds);

            _startPosition = transform.position;

            _destination = _startPosition;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.R))
                Shake();

            ShakeCamera();
        }

        public void Shake()
        {
            float angle = Random.Range(0, 360);
        
            Vector3 direction = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.up;
        
            Debug.Log(direction);

            _destination = _startPosition + _shakeAmplitude * direction;
        }

        private void ShakeCamera()
        {
            transform.position = Vector3.Lerp
                (transform.position, _destination, _recoveryRate * Time.deltaTime);

            if (Vector3.Distance(transform.position, _destination) < 0.01f)
            {
                _destination = _startPosition;
            }
        }

        private IEnumerator ChangeCameraPosition(Vector3 targetPosition)
        {
            while (transform.position != targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, _recoveryRate);

                yield return _waitForSeconds;
            }
        }
    }
}