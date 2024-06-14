using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeartUI : MonoBehaviour
{
    public PlayerController playerController;
    //private playerHP playerHP;

    public int maxHeath;
    private int playerHP;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController != null)
        {
            // Odczytaj playerHP
            playerHP = playerController.playerHP;
            Debug.Log("Player HP: " + playerHP);
        }
        else
        {
            Debug.LogWarning("PlayerController not found!");
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i<playerHP)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHeath)
            {
                hearts[i].enabled = true;
            }

            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
