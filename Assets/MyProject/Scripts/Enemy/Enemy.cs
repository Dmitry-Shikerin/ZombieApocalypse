using MyProject.Scripts.Players;
using UnityEngine;
using UnityEngine.Events;

namespace MyProject.Scripts.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _health;
        [SerializeField] private int _revard = 0;

        [SerializeField] private Player _target;

        public event UnityAction Dying;
    
        public void TakeDamage(float damage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Dye();
            }
        
            Debug.Log($"Damage {damage} is applied!");
        }

        private void Dye()
        {
        
        }
    }
}
