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
                // Destroy projectile
                if (other.gameObject.CompareTag("Projectile"))
                {
                    Destroy(gameObject);
                    Destroy(other.gameObject);
                }
                // Take 1 HP from the Player
                else if (other.gameObject.CompareTag("Player"))
                {
                    PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
                    if (playerController != null)
                    {
                        playerController.TakeDamage(1);
                    }
                }
                break;
            case "Arena":
                if (other.gameObject.CompareTag("Player"))
                {
                    // Take 1 Hp from the Player
                    PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
                    if (playerController != null)
                    {
                        //Debug.Log("Take 1 HP");
                        //playerController.TakeDamage(1);
                    }
                }
                break;

            default:
                Debug.Log("Uknown GameObject hit");
                break;
        }
    }
}
