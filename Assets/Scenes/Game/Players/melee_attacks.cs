using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee_attacks : MonoBehaviour
{
    public Animator animator;

    [SerializeField] Transform dashslashPos;
    [SerializeField] Transform swingdingPos;
    [SerializeField] Transform uphitPos;

    [SerializeField] float dashslashWidth;
    [SerializeField] float dashslashHeight;
    [SerializeField] float swingdingWidth;
    [SerializeField] float uphitWidth;

    [SerializeField]  int Ddmg;
    [SerializeField]  int Udmg;
    [SerializeField]  int Sdmg;

    float timeBtwAtk;
    [SerializeField] float startTimeBtwAtk;

    [SerializeField] LayerMask OpLayer;
    string prefix;

    Collider2D[] Enemies;

    void Start()
    {
        animator = GetComponent<Animator>();
        getPlayerNum();
    }

    void getPlayerNum()
    {
        if (gameObject.GetComponent<PlayerStats>().playerNum == 1)
        {
            prefix = "p1";
        }
        else if (gameObject.GetComponent<PlayerStats>().playerNum == 2)
        {
            prefix = "p2";
        }
        else
        {
            Debug.Log("u lpm");
        }
    }

    void Update()
    {
        if (timeBtwAtk <= 0)
        {
            if (Input.GetButtonDown(prefix + "Fire2") && GetComponent<movement_script>().isDashing)
            {
                HitboxAttackThing(1);
                animator.SetTrigger("isDashlash");
            }

            else if (Input.GetButtonDown(prefix + "Fire2") && GetComponent<movement_script>().isJumping)
            {
                HitboxAttackThing(2);
            }

            else if (Input.GetButtonDown(prefix + "Fire2"))
            {
                HitboxAttackThing(0);
            }

            timeBtwAtk = startTimeBtwAtk;
        } 
        else
        {
            timeBtwAtk -= Time.deltaTime;
        }
    }

    void HitboxAttackThing(int idx)
    {
        switch (idx)
        {
            case 1:
                Enemies = Physics2D.OverlapBoxAll(dashslashPos.position, new Vector2(dashslashWidth, dashslashHeight), OpLayer);
                recieveDMG(Ddmg, Enemies);
                break;
            case 2:
                Enemies = Physics2D.OverlapCircleAll(uphitPos.position, uphitWidth, OpLayer);
                recieveDMG(Udmg, Enemies);
                break;
            case 3:
                Enemies = Physics2D.OverlapCircleAll(swingdingPos.position, swingdingWidth, OpLayer);
                recieveDMG(Sdmg, Enemies);
                break;
        }
    }

    void recieveDMG(int dmg, Collider2D[] Enemiess)
    {
        foreach(Collider2D Enemy in Enemiess)
        {
            Enemy.GetComponent<PlayerStats>().TakeDamage(dmg);
        }
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(dashslashPos.position, new Vector2(dashslashWidth, dashslashHeight));
        Gizmos.DrawWireSphere(uphitPos.position, uphitWidth);
        Gizmos.DrawWireSphere(swingdingPos.position, swingdingWidth);
    }
}
