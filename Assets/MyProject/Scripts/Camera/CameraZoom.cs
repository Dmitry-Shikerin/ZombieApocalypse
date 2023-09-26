using System;
using System.Collections;
using System.Collections.Generic;
using MyProject.Scripts.Player;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _noScopePosition;
    [SerializeField] private Transform _scopePosition;
    [SerializeField] private float _recoveryRate = 0.1f;
    [SerializeField] private float _meaningWaitForSeconds = 1f;

    private WaitForSeconds _waitForSeconds;
    private readonly string _zoom = "Zoom";

    private Coroutine _coroutine;
    
    private Vector3 _currentPosition;
    private Vector3 _targetPosition;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_meaningWaitForSeconds);
    }

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

    private void Update()
    {
        if (Input.GetButton(_zoom))
        {
            _targetPosition = _scopePosition.position;
            ActivateZoom();
        }
        else
        {
            _targetPosition = _noScopePosition.position;
            DeActivateZoom();
        }
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
        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _recoveryRate);

            yield return _waitForSeconds;
        }
    }
}
