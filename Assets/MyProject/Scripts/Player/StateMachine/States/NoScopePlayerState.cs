using System.Collections.Generic;
using UnityEngine;

namespace MyProject.Scripts.Player.StateMachine.States
{
    public class NoScopePlayerState : PlayerStateBase
    {
        public NoScopePlayerState(List<IPlayerTransition> transitions) : base(transitions)
        {
        }
        
        public override void Enter()
        {
            Debug.Log("NoScopeState Activity");
        }

        public override void Exit()
        {
            
        }
    }
}