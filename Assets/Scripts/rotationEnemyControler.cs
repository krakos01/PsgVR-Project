using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationEnemyControler : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5f;

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}