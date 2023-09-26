using System.Collections;
using System.Collections.Generic;
using MyProject.Scripts.Bullets;
using MyProject.Scripts.Weapons;
using UnityEngine;

public class M16 : Weapon
{
    public override void Shoot()
    {
        _raycastAttack.PerformAttack();
    }
}
