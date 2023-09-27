using System;
using MyProject.Scripts.Players.StateMachine.States.Contexts;

namespace MyProject.Scripts.Players.StateMachine.Transitions
{
    public interface IPlayerTransition
    {
        
    }

    public interface IPlayerTransition<in T> : IPlayerTransition where T : IContext
    {
        public Type NextState { get; }

        public bool CanTransit(T context);
    }
}