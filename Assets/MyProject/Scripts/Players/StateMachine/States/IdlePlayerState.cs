using System.Collections.Generic;
using MyProject.Scripts.Players.AnimationControllers;
using MyProject.Scripts.Players.StateMachine.Transitions;

namespace MyProject.Scripts.Players.StateMachine.States
{
    public class IdlePlayerState : PlayerStateBase
    {
        private readonly AnimationControllerSecond _animationControllerSecond;

        public IdlePlayerState(IEnumerable<IPlayerTransition> transitions, 
            AnimationControllerSecond animationControllerSecond) : base(transitions)
        {
            _animationControllerSecond = animationControllerSecond;
        }
        
        public override void Enter()
        {
            _animationControllerSecond.PlayIdle();
        }

        public override void Exit()
        {
            
        }
    }
}