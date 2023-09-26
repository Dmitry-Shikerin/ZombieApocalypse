using MyProject.Scripts.Player.StateMachine.States;
using MyProject.Scripts.Player.StateMachine.States.Contexts;

namespace MyProject.Scripts.Player.StateMachine.Transitions
{
    public class TransitionToNoGunPlayerState : PlayerTransitionBase<NoGunPlayerState, ContextChangeWeapon>
    {
        public override bool CanTransit(ContextChangeWeapon context)
        {
            return context.Weapon == null;
        }
    }
}