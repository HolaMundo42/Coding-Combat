using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boooooom : MonoBehaviour
{
    double offset;
    public int plyNum=0;
    [SerializeField] float timeToDie;
    [SerializeField] int dmg;
    PlayerStats plrSts;

    void Start()
    {
        offset = Time.time;
    }

    void Update()
    {
        if (Time.time-offset > timeToDie)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (plyNum == 1)
        {
            try {
                plrSts = coll.gameObject.GetComponent<PlayerStats>();
            }catch{ Destroy(gameObject); }

            if (plrSts.playerNum == 2)
            {
                plrSts.TakeDamage(dmg);
                Destroy(gameObject);
            }
        }
        else if (plyNum == 2)
        {
            try {
                plrSts = coll.gameObject.GetComponent<PlayerStats>();
            }catch{ Destroy(gameObject); }

            if (plrSts.playerNum == 1)
            {
                plrSts.TakeDamage(dmg);
                Destroy(gameObject);
            }
        }
    }
}
