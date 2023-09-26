using MyProject.Scripts.Weapons;

namespace MyProject.Scripts.Player.StateMachine.States.Contexts
{
    public class ContextChangeWeapon : IContext
    {
        public ContextChangeWeapon(Weapon weapon)
        {
            Weapon = weapon;
        }
        
        public Weapon Weapon { get; }
    }
}