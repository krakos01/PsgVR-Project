using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerHP = 3;

    [SerializeField]
    private CharacterController characterController;

    public float lowBound = 3;
    public float highBound = 100;

    /// <summary>
    // Start is called before the first frame update
    /// </summary>
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    /// Update is called once per frame
    void Update()
    {
        
    }



    /// Inform GameManager that player hit obstacle
    public void TakeDamage(int dmg)
    {
        playerHP -= dmg;

        if (playerHP <= 0)
            GameManager.Instance.PlayerDied(gameObject);

    }
}