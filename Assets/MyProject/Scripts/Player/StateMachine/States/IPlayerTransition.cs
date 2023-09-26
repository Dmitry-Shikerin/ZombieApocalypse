using System;
using MyProject.Scripts.Player.StateMachine.States.Contexts;

namespace MyProject.Scripts.Player.StateMachine.States
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