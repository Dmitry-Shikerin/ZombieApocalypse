using MyProject.Scripts.Bullets;
using UnityEngine;

namespace MyProject.Scripts.Weapons
{
    public class AK47 : Weapon
    {
        public override void Shoot()
        {
            _raycastAttack.PerformAttack();
        }
    }
}
