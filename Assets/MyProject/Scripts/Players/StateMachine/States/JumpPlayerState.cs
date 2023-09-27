using System.Collections.Generic;
using JetBrains.Annotations;
using MyProject.Scripts.Players.AnimationControllers;
using MyProject.Scripts.Players.StateMachine.Transitions;

namespace MyProject.Scripts.Players.StateMachine.States
{
    public class JumpPlayerState : PlayerStateBase
    {
        private readonly AnimationControllerSecond _animationControllerSecond;

        public JumpPlayerState(IEnumerable<IPlayerTransition> transitions, 
            AnimationControllerSecond animationControllerSecond) : base(transitions)
        {
            _animationControllerSecond = animationControllerSecond;
        }

        public override void Enter()
        {
            _animationControllerSecond.PlayJump();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}