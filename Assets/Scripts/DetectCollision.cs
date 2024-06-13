using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{


    // Destroy both object on collision
    private void OnTriggerEnter(Collider other)
    {
        switch (gameObject.tag) {
            case "Player":
                // Take 1 HP and destroy projectile
                if (other.gameObject.CompareTag("EnemyProjectile"))
                {
                    PlayerController playerController = gameObject.GetComponent<PlayerController>();
                    if (playerController != null)
                    {
                        playerController.TakeDamage(1);
                        Debug.Log($"Player hp: {playerController.playerHP}");

                        Destroy(other.gameObject);
                    }
                }
                break;
            case "Enemy":
                // Destroy enemy and projectile if a projectile hit an enemy
                if (other.gameObject.CompareTag("Projectile"))
                {
                    EnemyController enemyController = gameObject.GetComponent<EnemyController>();
                    enemyController.TakeDamage(1);

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
                        Debug.Log("Kolizcja z ziemią");
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
