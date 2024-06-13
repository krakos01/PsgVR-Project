using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private int healthPoints = 2;


    public void TakeDamage(int dmg) {
        healthPoints -= dmg;

        if (healthPoints <= 0)
        {
            GameManager.Instance.EnemyDies(gameObject);
            GameManager.Instance.AddPoints(10);
        }
    }
}
