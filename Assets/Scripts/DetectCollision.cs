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
        // Destroy projectile
        if (other.gameObject.CompareTag("Projectile")) 
        { 
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        // Take 1 HP from player
        else if (other.gameObject.CompareTag("Player")) 
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            if (playerController != null) 
            {
                playerController.TakeDamage(1);
            }
        }
    }
}
