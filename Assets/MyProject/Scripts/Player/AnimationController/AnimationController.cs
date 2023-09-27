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
        ChangeAnimation();
    }

    private void ChangeAnimation()
    {
        SetNoGunState();
        SetGunScopeState();
        SetGunNoScopeState();
        SetShootState();
    }
    
    private void SetNoGunState()
    {
        if(_player.CurrentWeapon == null)
            _animator.Play(_noGunState);
    }

    private void SetGunNoScopeState()
    {
        // if(_player.CurrentWeapon != null && Input.GetButton(_zoom) == false && Input.GetButton(_shooting) ==false)
        //     _animator.Play(_gunNoScopeState);
        
        if(_player.CurrentWeapon != null && Input.GetButtonUp(_zoom) && Input.GetButton(_shooting) ==false)
            _animator.Play(_gunNoScopeState);

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
