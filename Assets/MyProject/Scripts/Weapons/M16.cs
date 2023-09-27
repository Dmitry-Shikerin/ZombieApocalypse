namespace MyProject.Scripts.Weapons
{
    public class M16 : Weapon
    {
        public override void Shoot()
        {
            _raycastAttack.PerformAttack();
        }
    }
}