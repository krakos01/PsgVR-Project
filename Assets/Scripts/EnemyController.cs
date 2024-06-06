using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int healthPoints = 2;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int dmg)
    {
        healthPoints -= dmg;

        if (healthPoints <= 0)
            GameManager.Instance.EnemyDies(gameObject);
    }


    public void DestroyImmediately()
    {
        GameManager.Instance.EnemyDies(gameObject);
    }
}
