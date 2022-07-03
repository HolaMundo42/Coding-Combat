using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee_attacks : MonoBehaviour
{
    [SerializeField] GameObject[] Attacks;

    float[] lifeTimes = {0,0,0};
    bool[] canDoIt = {true,true,true};

    string prefix;

    void Start()
    {
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

        if (Input.GetButtonDown(prefix + "Fire2") && GetComponent<movement_script>().isDashing && canDoIt[1])
        {
            HitboxAttackThing(1);
        }

        else if (Input.GetButtonDown(prefix + "Fire2") && GetComponent<movement_script>().isJumping && canDoIt[2])
        {
            HitboxAttackThing(2);
        }

        else if (Input.GetButtonDown(prefix + "Fire2") && canDoIt[0])
        {
            HitboxAttackThing(0);
        }
    }

    void HitboxAttackThing(int idx)
    {
        Attacks[idx].SetActive(true);
        canDoIt[idx] = false;
        Attacks[idx].GetComponent<hitbox_attacks>().plyNum = GetComponent<PlayerStats>().playerNum;
        lifeTimes[idx] = Attacks[idx].GetComponent<hitbox_attacks>().lifeTime;
    }

    void FixedUpdate()
    {
        for (int i = 0; i <= 2; ++i)
        if (lifeTimes[i] >= 0)
        {
            lifeTimes[i] -= Time.deltaTime;
        }
        else
        {
            canDoIt[i] = true;
        }
    }


}
