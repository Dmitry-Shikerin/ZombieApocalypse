using MyProject.Scripts.Bullets;
using UnityEngine;
using UnityEngine.Serialization;

namespace MyProject.Scripts.Weapons
{
    public abstract class Weapon : MonoBehaviour
    {
        [Header("View")] [SerializeField] protected string _label;
        [SerializeField] protected Sprite _icon;

        [Header("IsActive")] [SerializeField] protected bool _isActive;

        [Header("Characteristics")] [SerializeField]
        protected float _shootForce;

        [SerializeField] protected float _fireRate;
        [SerializeField] protected float _speed;
        [SerializeField] protected float _spred;

        [Header("Positions")] [SerializeField] protected Transform _shootPoint;
        [SerializeField] protected Camera _camera;

        [Header("RaycastAttack")] [SerializeField]
        protected RaycastAttack _raycastAttack;

        private float _nextShoot = 0;
        private Vector3 _spawnPoint;

        public string Label => _label;
        public Sprite Icon => _icon;
        public bool IsActive => gameObject.activeSelf == true;

        private void Start()
        {
            _spawnPoint = _shootPoint.transform.position;
        }

        private void Update()
        {
            if (Input.GetButton("Fire1") && Time.time > _nextShoot)
            {
                _nextShoot = Time.time + 1f / _fireRate;
                Shoot();
            }
            // if (Input.GetButton("Fire1"))
        }

        public abstract void Shoot();
    }
}