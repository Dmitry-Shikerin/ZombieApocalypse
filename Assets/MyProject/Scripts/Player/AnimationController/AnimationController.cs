using System.Collections;
using System.Collections.Generic;
using MyProject.Scripts.Player;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Animator _animator;

    private readonly string _noGunState = "NoGunState";
    private readonly string _gunNoScopeState = "GunNoScopeState";
    private readonly string _gunScopeState = "GunScopeState";

    private readonly string _zoom = "Zoom";
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        ChangeAnimation();
    }

    private void ChangeAnimation()
    {
        SetNoGunState();
        SetGunScopeState();
        SetGunNoScopeState();
    }
    
    private void SetNoGunState()
    {
        if(_player.CurrentWeapon == null)
            _animator.Play(_noGunState);
    }

    private void SetGunNoScopeState()
    {
        if(_player.CurrentWeapon != null && Input.GetButton(_zoom) == false)
            _animator.Play(_gunNoScopeState);
    }

    private void SetGunScopeState()
    {
        if(_player.CurrentWeapon != null && Input.GetButton(_zoom))
            _animator.Play(_gunScopeState);
    }
}
