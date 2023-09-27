using System.Collections.Generic;
using MyProject.Scripts.Players.AnimationControllers;
using MyProject.Scripts.Players.StateMachine.Transitions;
using UnityEngine;

namespace MyProject.Scripts.Players.StateMachine.States
{
    public class NoScopePlayerState : PlayerStateBase
    {
        private readonly AnimationControllerSecond _animationControllerSecond;

        public NoScopePlayerState(List<IPlayerTransition> transitions, 
            AnimationControllerSecond animationControllerSecond) : base(transitions)
        {
            _animationControllerSecond = animationControllerSecond;
        }
        
        public override void Enter()
        {
            _animationControllerSecond.PlayNoScope();
        }

        public override void Exit()
        {
            
        }
    }
}