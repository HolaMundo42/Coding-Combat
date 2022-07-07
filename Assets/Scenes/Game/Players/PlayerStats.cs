using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int hp = 1;
    public int playerNum=-69;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if(hp <= 0)
        {
            Die();
        }
        else
        {
            animator.SetTrigger("hurt");
        }
    }

    void Die()
    {
        if (playerNum == 1) { PlayerPrefs.SetInt("Winner", 2); }
        else{ PlayerPrefs.SetInt("Winner", 1); }
        SceneManager.LoadScene("EndOfGame");

    }
}
