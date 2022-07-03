using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;

    [SerializeField] float bulletSpeed;
    [SerializeField] float recoilTime;

    [SerializeField] Transform BulletSpawnPoint;

    Rigidbody2D rb;
    GameObject blt;

    bool canShoot;
    float offset;
    string prefix;

    private void Start()
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
        if(Time.time - offset > recoilTime){ canShoot = true; }
        if(Input.GetButtonDown(prefix+"Fire1") && canShoot)
        {
            canShoot = false;
            offset = Time.time;
            blt = Instantiate(bullet, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
            blt.SetActive(true);
            blt.GetComponent<boooooom>().plyNum = GetComponent<PlayerStats>().playerNum;
            rb = blt.GetComponent<Rigidbody2D>();
            rb.velocity =  transform.right*bulletSpeed+transform.up*1.2f;
        }
    }
}
