using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int hp = 1;
    public int playerNum;

    void Start()
    {
        
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if(hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (playerNum == 1) { PlayerPrefs.SetInt("Winner", 2); }
        else{ PlayerPrefs.SetInt("Winner", 1); }
        SceneManager.LoadScene("EndOfGame");

    }
}
