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


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerHP = 3;
    }


    // Inform GameManager that player hit something
    public void TakeDamage(int dmg)
    {
        playerHP -= dmg;

        if (playerHP <= 0)
            GameManager.Instance.EndGame();

    }
}