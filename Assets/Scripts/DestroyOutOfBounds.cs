using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 100;
    public float bottomBound = 0;
    public float horizontalVerticalBound = 50;
    public GameObject hitPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > topBound || transform.position.y < bottomBound
            || transform.position.x > horizontalVerticalBound || transform.position.x < -horizontalVerticalBound
            || transform.position.z > horizontalVerticalBound || transform.position.z < -horizontalVerticalBound
        )
        {

            Vector3 posContact = transform.position;
            if (hitPrefab != null)
            {
                var hitVFX = Instantiate(hitPrefab, posContact, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
