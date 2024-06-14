using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeartUI : MonoBehaviour
{
    public GameObject player;
    private playerHP playerHP;

    public int maxHeath;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int health = player.GetComponent<playerHP>();
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i<health)
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
