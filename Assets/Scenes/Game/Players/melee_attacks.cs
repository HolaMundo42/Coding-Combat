using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee_attacks : MonoBehaviour
{
    [SerializeField] GameObject[] Attacks;
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            Attacks[0].SetActive(true);
        }

        else if (Input.GetButtonDown("Fire2") && GetComponent<movement_script>().isDashing)
        {
            Attacks[1].SetActive(true);
        }

        else if (Input.GetButtonDown("Fire2") && GetComponent<movement_script>().isJumping)
        {
            Attacks[2].SetActive(true);
        }
    }
}
