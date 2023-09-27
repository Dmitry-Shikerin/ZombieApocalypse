using UnityEngine;

namespace MyProject.Scripts.Players.AnimationControllers
{
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
                // _animator.SetBool(_gunNoScopeState, true);
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

            if (Input.GetButton("Jump"))
            {
                _animator.SetBool(_gunNoScopeState, false);
            }
            else
            {
                _animator.SetBool(_gunNoScopeState, true);
            }
        }
        
        //Полностью решать логику какое оружие в руках
        public void PlayNoScope()
        {
            _animator.SetBool(_gunNoScopeState, true);
        }

        public void PlayIdle()
        {
            // _animator.SetBool("Idle");
        }

        public void PlayRun()
        {
            
        }

        public void PlayJump()
        {
            
        }
    }
}
