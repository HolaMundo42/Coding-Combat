using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox_attacks : MonoBehaviour
{
    double offset = 0;
    public float lifeTime = 0.3f;
    [SerializeField] int dmg;
    public int plyNum;
    PlayerStats player_stats;

    int whichMask()
    {
        if (plyNum == 1)
        {
            return LayerMask.NameToLayer("Player2");
        }
        else
        {
            return LayerMask.NameToLayer("Player1");
        }
    }

    void Start()
    {
        CheckColl();
        gameObject.SetActive(false);
    }

    void CheckColl()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(gameObject.transform.position, new Vector2(gameObject.transform.localScale.x, gameObject.transform.localScale.y), whichMask());
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<PlayerStats>().TakeDamage(dmg);
        }
    }
}