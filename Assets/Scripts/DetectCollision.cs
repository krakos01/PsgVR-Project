using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Destroy both object on collision
    private void OnTriggerEnter(Collider other)
    {
        switch (gameObject.tag) {
            case "Enemy":
                // Destroy enemy and projectile if a projectile hit an enemy
                if (other.gameObject.CompareTag("Projectile"))
                {
                    EnemyController enemyController = gameObject.GetComponent<EnemyController>();
                    enemyController.DestroyImmediately();

                    Destroy(other.gameObject);
                }
                // Take 1 HP only from the Player if the player hit an enemy
                else if (other.gameObject.CompareTag("Player"))
                {
                    PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
                    if (playerController != null)
                    {
                        playerController.TakeDamage(1);
                        Debug.Log($"Player hp: {playerController.playerHP}");
                    }
                }
                break;

            // Floor, walls and ceiling should have "Arena" tag
            case "Arena":
                if (other.gameObject.CompareTag("Player"))
                {
                    // Take 1 Hp from the Player
                    PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
                    if (playerController != null)
                    {
                        playerController.TakeDamage(1);
                        Debug.Log($"Player hp: {playerController.playerHP}");
                    }
                }
                break;

            default:
                Debug.Log("Uknown GameObject hit");
                break;
        }
    }
}
