using System;
using System.Collections.Generic;
using MyProject.Scripts.Player.StateMachine;
using MyProject.Scripts.Player.StateMachine.States;
using MyProject.Scripts.Player.StateMachine.States.Contexts;
using MyProject.Scripts.Player.StateMachine.Transitions;
using MyProject.Scripts.Weapons;
using UnityEngine;

namespace MyProject.Scripts.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private List<Weapon> _weapons;

        private readonly string _mouseScrollWheel = "Mouse ScrollWheel";

        private Weapon _currentWeapon;
        private int _currentWeaponNumber = 0;
        private int _currentHealth;
        private float _changeWeapon;
        private float _currentValueChangeWeapon;

        public Weapon CurrentWeapon => _currentWeapon;
        
        private void Start()
        {
            _currentWeapon = _weapons[_currentWeaponNumber];
            _currentHealth = _health;

            List<IPlayerTransition> noGunTransitions = new List<IPlayerTransition>()
            {
                new TransitionToNoScopePlayerState(),
                new PlayerTransition<NoScopePlayerState, ContextChangeWeapon>
                    (Condition),
                // new PlayerTransitionToJumpState
            };

            List<IPlayerTransition> noScopeTransitions = new List<IPlayerTransition>()
            {
                new TransitionToNoGunPlayerState(),
            };

            Dictionary<Type, PlayerStateBase> states = new Dictionary<Type, PlayerStateBase>()
            {
                [typeof(NoGunPlayerState)] = new NoGunPlayerState(noGunTransitions),
                [typeof(NoScopePlayerState)] = new NoScopePlayerState(noScopeTransitions),
            };

            PlayerStateMachine stateMachine = new PlayerStateMachine(states);

            stateMachine.Start<NoGunPlayerState>();
            //нужно передать оружие
            stateMachine.Update(new ContextChangeWeapon(_currentWeapon));
            stateMachine.Update(new ContextChangeWeapon(null));
        }

        private void Update()
        {
            ChangeWeapon();
        }
        
        private bool Condition(ContextChangeWeapon context)
        {
            return context.Weapon != null;
        }

        public void NextWeapon()
        {
            _currentWeapon.gameObject.SetActive(false);
            
            if (_currentWeaponNumber == _weapons.Count - 1)
            {
                _currentWeaponNumber = 0;
            }
            else
            {
                _currentWeaponNumber++;
            }

            _currentWeapon = _weapons[_currentWeaponNumber];
            
            _currentWeapon.gameObject.SetActive(true);
        }

        public void PreviousWeapon()
        {
            _currentWeapon.gameObject.SetActive(false);

            if (_currentWeaponNumber == 0)
            {
                _currentWeaponNumber = _weapons.Count - 1;
            }
            else
            {
                _currentWeaponNumber--;
            }
            
            _currentWeapon = _weapons[_currentWeaponNumber];

            _currentWeapon.gameObject.SetActive(true);
        }
        
        private void ChangeWeapon()
        {
            //отслеживать переключение оружия
            _changeWeapon = Input.GetAxis(_mouseScrollWheel);

            //Листаем оружие в верх
            if (_changeWeapon > _currentValueChangeWeapon)
            {
                NextWeapon();
            }

            //листаем оружие вниз
            if (_changeWeapon < _currentValueChangeWeapon)
            {
                PreviousWeapon();
            }
        }
    }
}