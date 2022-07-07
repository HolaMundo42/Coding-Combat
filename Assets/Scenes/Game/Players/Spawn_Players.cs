using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Players : MonoBehaviour
{
    public GameObject[] Players;
    [SerializeField] Transform spawnPoint1;
    [SerializeField] Transform spawnPoint2;

    GameObject p1;
    GameObject p2;

    void Start()
    {
        p1 = Instantiate(Players[PlayerPrefs.GetInt("p1")], spawnPoint1.position, Quaternion.identity);
        p1.layer = LayerMask.NameToLayer("Player1");
        p1.GetComponent<PlayerStats>().playerNum = 1;

        p2 = Instantiate(Players[PlayerPrefs.GetInt("p2")], spawnPoint2.position, Quaternion.identity);
        p2.layer = LayerMask.NameToLayer("Player2");
        p2.GetComponent<PlayerStats>().playerNum = 2;
    }

    void Update()
    {
        
    }
}
