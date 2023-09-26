using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public void ApplyDamage(float damage)
    {
        Debug.Log($"Damage {damage} is applied!");
    }
}
