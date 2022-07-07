using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Players : MonoBehaviour
{
    public GameObject[] Players;
    [SerializeField] Transform spawnPoint1;
    [SerializeField] Transform spawnPoint2;

    [SerializeField] Image realBG;
    int bgID;

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

        bgID = PlayerPrefs.GetInt("Background");
        switch(bgID)
        {
            case 0:
                realBG.color = Color.cyan;
                break;
            case 1:
                realBG.color = Color.blue;
                break;
            case 2:
                realBG.color = Color.grey;
                break;
        }
    }
}
