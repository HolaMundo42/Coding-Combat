using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_character : MonoBehaviour
{
    [SerializeField] Image[] Characters;
    [SerializeField] Image p1;
    [SerializeField] Image p2;
    int maxPlayers = 2;
    int index = 0;
    int index2 = 0;
    
    void Start()
    {
        PlayerPrefs.SetInt("p1", 0);
        PlayerPrefs.SetInt("p2", 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (index == maxPlayers-1) { return; }
            index++;
            PlayerPrefs.SetInt("p1", index);
            p1.color = Characters[index].color;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (index == 0) { return; }
            index--;
            PlayerPrefs.SetInt("p1", index);
            p1.color = Characters[index].color;
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (index2 == maxPlayers-1) { return; }
            index2++;
            PlayerPrefs.SetInt("p2", index2);
            p2.color = Characters[index2].color;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (index2 == 0) { return; }
            index2--;
            PlayerPrefs.SetInt("p2", index2);
            p2.color = Characters[index2].color;
        }
    }

    void changeCharacter(bool next)
    {

    }
}
