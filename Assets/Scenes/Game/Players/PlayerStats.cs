using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int hp;

    void Start()
    {
        
    }

    void TakeDamage(int dmg)
    {
        hp -= dmg;
        if(hp < 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("EndOfGame");
    }
}
