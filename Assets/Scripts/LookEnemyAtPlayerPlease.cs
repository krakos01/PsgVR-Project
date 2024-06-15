using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookEnemyAtPlayerPlease : MonoBehaviour
{ 
    public float rotationSpeed = 1f;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(SetDirectionAtPlayer());
    }

    void Update()
    {
        StartCoroutine(SetDirectionAtPlayer());
    }

    private IEnumerator SetDirectionAtPlayer()
    {

         LookAtPlayer();
         yield return new WaitForSeconds(0.2f);
    }


    void LookAtPlayer()
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.y = 0;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}