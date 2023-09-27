using System.Collections;
using System.Collections.Generic;
using MyProject.Scripts.Player;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Animator))]
public class AnimationControllerSecond : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Animator _animator;

    private readonly string _noGunState = "NoGunState";
    private readonly string _gunNoScopeState = "GunNoScopeState";
    private readonly string _gunScopeState = "GunScopeState";
    private readonly string _shootState = "ShootState";
    private readonly string _rifleDownToAim = "RifleDownToAim";
    

    private readonly string _zoom = "Zoom";
    private readonly string _shooting = "Fire1";
    
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        SetBoolValue();
    }

    private void ChangeAnimation()
    {
    }

    private void SetBoolValue()
    {
        if (_player.CurrentWeapon != null)
        {
            _animator.SetBool(_gunNoScopeState, true);
        }

        if (Input.GetButton(_zoom))
        {
            _animator.SetBool(_gunScopeState, true);
        }
        else
        {
            _animator.SetBool(_gunScopeState, false);
        }

        if (Input.GetButton(_shooting))
        {
            _animator.SetBool(_shootState, true);
        }
        else
        {
            _animator.SetBool(_shootState, false);
        }
    }
    
    
    private void SetNoGunState()
    {
        if (_player.CurrentWeapon == null)
        {
            
        }
    }

    private void SetGunNoScopeState()
    {
        if(_player.CurrentWeapon != null && Input.GetButton(_zoom) && Input.GetButton(_shooting) ==false)
            _animator.SetBool(_gunNoScopeState, true);
    }

    private void SetGunScopeState()
    {
        // if (_player.CurrentWeapon != null && Input.GetButton(_zoom) && Input.GetButton(_shooting) == false)
        //     _animator.Play(_gunScopeState);

        if (_player.CurrentWeapon != null && Input.GetButton(_zoom) && Input.GetButton(_shooting) == false)
        {
                _animator.Play(_rifleDownToAim);
              
            // _animator.Play(_gunScopeState);
        }

    }

    private void SetShootState()
    {
        if (_player.CurrentWeapon != null && Input.GetButton(_zoom) && Input.GetButton(_shooting))
        {
            _animator.Play(_shootState);
        }
    }
}
