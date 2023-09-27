using MyProject.Scripts.Players.StateMachine.States;
using MyProject.Scripts.Players.StateMachine.States.Contexts;

namespace MyProject.Scripts.Players.StateMachine.Transitions
{
    public class TransitionToNoGunPlayerState : PlayerTransitionBase<NoGunPlayerState, ContextChangeWeapon>
    {
        public override bool CanTransit(ContextChangeWeapon context)
        {
            return context.Weapon == null;
        }
    }
}