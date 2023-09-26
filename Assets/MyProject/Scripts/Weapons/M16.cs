using System.Collections;
using System.Collections.Generic;
using MyProject.Scripts.Bullets;
using MyProject.Scripts.Weapons;
using UnityEngine;

public class M16 : Weapon
{
    public override void Shoot()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;

        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 dirtWithouSpread = targetPoint - _shootPoint.position;

        float x = Random.Range(-_spred, _spred);
        float y = Random.Range(-_spred, _spred);

        Vector3 directionSpread = dirtWithouSpread + new Vector3(x, y, 0);

        Bullet bullet = Instantiate(_bullet, _shootPoint.position, Quaternion.identity);

        bullet.transform.forward = directionSpread.normalized;

        bullet.GetComponent<Rigidbody>().AddForce
            (directionSpread.normalized * _shootForce * Time.deltaTime, ForceMode.Impulse);
    }
}
