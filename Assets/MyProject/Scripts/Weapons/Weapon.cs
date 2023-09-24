using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _shootForce;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _speed;
    [SerializeField] private float _spred;
    [SerializeField] private Transform _spownPointBullet;
    [SerializeField] private Camera _camera;
    [SerializeField] private Bullet _bullet;

    private float _nextShoot = 0;
    private Vector3 _spownPoint;

    private void Start()
    {
        _spownPoint = _spownPointBullet.transform.position;
    }

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > _nextShoot)
        {
            _nextShoot = Time.time + 1f / _fireRate;

            Shoot();
        }
    }

    private void Shoot()
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

        Vector3 dirtWithouSpread = targetPoint - _spownPointBullet.position;

        float x = Random.Range(-_spred, _spred);
        float y = Random.Range(-_spred, _spred);

        Vector3 directionSpread = dirtWithouSpread + new Vector3(x, y, 0);

        Bullet bullet = Instantiate(_bullet, _spownPointBullet.position, Quaternion.identity);

        bullet.transform.forward = directionSpread.normalized;

        bullet.GetComponent<Rigidbody>().AddForce(directionSpread.normalized * _shootForce, ForceMode.Impulse);
        //bullet.transform.Rotate(0, -90, -90);
    }
}
