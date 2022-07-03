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

    void Update()
    {
        if(Time.time - offset > recoilTime){ canShoot = true; }
        if(Input.GetButtonDown("Fire1") && canShoot)
        {
            canShoot = false;
            offset = Time.time;
            blt = Instantiate(bullet, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
            blt.SetActive(true); 
            rb = blt.GetComponent<Rigidbody2D>();
            rb.velocity =  transform.right*bulletSpeed;
        }
    }
}
