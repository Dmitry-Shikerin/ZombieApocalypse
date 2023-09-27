using System.Collections.Generic;
using MyProject.Scripts.Players.StateMachine.Transitions;
using UnityEngine;

namespace MyProject.Scripts.Players.StateMachine.States
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