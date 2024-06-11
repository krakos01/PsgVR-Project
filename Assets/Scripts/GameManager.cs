using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    protected int enemiesDestroyed = 0;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); return; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    /// <summary>
    /// Destroy player object when hp <= 0
    /// </summary>
    public void PlayerDied(GameObject player)
    {
        Destroy(player);
        Debug.Log("Game Over");
    }

    public void EnemyDies(GameObject enemy)
    {
        Destroy(enemy);
        enemiesDestroyed++;
    }
}
