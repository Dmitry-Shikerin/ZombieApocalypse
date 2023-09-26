using System.Collections;
using System.Collections.Generic;
using MyProject.Scripts.Player;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Transform _noScopePosition;
    [SerializeField] private Transform _scopePosition;

    private readonly string _zoom = "Zoom";
    
    private float _currentPosition;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButton(_zoom))
        {
            transform.position = _scopePosition.position;
        }
        else
        {
            transform.position = _noScopePosition.position;
        }
    }
}
