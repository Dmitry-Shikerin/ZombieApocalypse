using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RaycastAttack : MonoBehaviour
{
    [Header("Damage")] 
    [SerializeField, Min(0f)] private float _damage = 10f;

    [Header("Ray")] 
    [SerializeField] private LayerMask _layerMask;
    [SerializeField, Min(0f)] private float _distance = Mathf.Infinity;
    [SerializeField, Min(0f)] private int _shotCount = 1;
    [SerializeField] private Transform _startRayPosition;

    [Header("Spread")] 
    [SerializeField] private bool _useSpread = false;
    [SerializeField, Min(0f)] private float _spreadFactor = 1f;

    public void PerformAttack()
    {
        for (int i = 0; i < _shotCount; i++)
        {
            PerformRaycast();
        }
    }

    private void PerformRaycast()
    {
        //Задаем напрвление луча
        Vector3 direction;
        
        //Применяем разброс или нет(в зависимости от флажка в инспекторе)
        if (_useSpread == true)
        {
            direction = _startRayPosition.transform.forward + CalculateSpread();
        }
        else
        {
            direction = _startRayPosition.transform.forward;
        }

        //Сосдаем луч и задаем точку из которой он происходит и в каком направлении
        Ray ray = new Ray(_startRayPosition.transform.position, direction);

        //запускаем луч и проверяем попадание с помощью Physics.Raycast
        //если поставить перед _layerMask "~" то она инвертирует логику
        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance, _layerMask))
        {
            Collider hitCollider = hitInfo.collider;

            //Получаем компонетнт по которому хотим нанести урон
            //Можно объединить тех кто может получать урон под один интерфейс и вызывать метод для получения урона
            if (hitCollider.TryGetComponent(out Enemy enemy))
            {
                enemy.ApplyDamage(2);
            }
            else
            {
                //если противник не найден то выполняем другую логику
            }
        }
    }

    private Vector3 CalculateSpread()
    {
        return new Vector3
        {
             x = Random.Range(-_spreadFactor, _spreadFactor),
             y = Random.Range(-_spreadFactor, _spreadFactor),
             z = Random.Range(-_spreadFactor, _spreadFactor),
        };
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        // Рисовать всегда
        return;
    }

    private void OnDrawGizmosSelected()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _distance, _layerMask))
        {
            DrawRay(ray, hitInfo.point, hitInfo.distance, Color.red);
        }
        else
        {
            Vector3 hitPosition = ray.origin + ray.direction * _distance;
            
            DrawRay(ray, hitPosition, _distance, Color.green);
        }
    }

    private static void DrawRay(Ray ray, Vector3 hitPosition, float distance, Color color)
    {
        const float hitPointRadius = 0.15f;
        
        Debug.DrawRay(ray.origin, ray.direction * distance, color);

        Gizmos.color = color;
        Gizmos.DrawSphere(hitPosition, hitPointRadius);
    }
#endif
} 