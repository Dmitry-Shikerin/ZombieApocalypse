using System.Collections.Generic;
using UnityEngine;

namespace MyProject.Scripts.Player.StateMachine.States
{
    public class NoGunPlayerState : PlayerStateBase
    {
        public NoGunPlayerState(List<IPlayerTransition> transitions) : base(transitions)
        {
            
        }

        public override void Enter()
        {
            Debug.Log("NoGanState Activity");
        }

        public override void Exit()
        {
            
        }
    }
}