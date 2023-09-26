using System;
using MyProject.Scripts.Player.StateMachine.States;
using MyProject.Scripts.Player.StateMachine.States.Contexts;

namespace MyProject.Scripts.Player.StateMachine.Transitions
{
    public abstract class PlayerTransitionBase<TState, TContext> : IPlayerTransition<TContext> 
        where TState : PlayerStateBase 
        where TContext : IContext
    {
        public Type NextState { get; } = typeof(TState);

        public abstract bool CanTransit(TContext context);
    }
}