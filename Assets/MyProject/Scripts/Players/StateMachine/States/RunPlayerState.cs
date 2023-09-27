using System.Collections.Generic;
using MyProject.Scripts.Players.AnimationControllers;
using MyProject.Scripts.Players.StateMachine.Transitions;

namespace MyProject.Scripts.Players.StateMachine.States
{
    public class RunPlayerState : PlayerStateBase
    {
        private readonly AnimationControllerSecond _animationControllerSecond;

        public RunPlayerState(IEnumerable<IPlayerTransition> transitions,
            AnimationControllerSecond animationControllerSecond) : base(transitions)
        {
            _animationControllerSecond = animationControllerSecond;
        }

        public override void Enter()
        {
            _animationControllerSecond.PlayRun();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}