using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox_attacks : MonoBehaviour
{
    double offset = 0;
    public float lifeTime=0.3f;
    [SerializeField] int dmg;
    public int plyNum;

    void Start()
    {
        offset = Time.time;
    }

    void Update()
    {
        if(Time.time - offset > lifeTime)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        
    }
}
