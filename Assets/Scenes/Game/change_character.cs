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
        p1.color = Characters[index].color;
        p2.color = Characters[index2].color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            p1ChangeRight();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            p1ChangeLeft();
        }


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            p2ChangeRight();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            p2ChangeLeft();
        }
    }

    public void p1ChangeRight()
    {
        if (index == maxPlayers - 1) { return; }
        index++;
        PlayerPrefs.SetInt("p1", index);
        p1.color = Characters[index].color;
    }

    public void p1ChangeLeft()
    {
        if (index == 0) { return; }
        index--;
        PlayerPrefs.SetInt("p1", index);
        p1.color = Characters[index].color;
    }

    public void p2ChangeRight()
    {
        if (index2 == maxPlayers - 1) { return; }
        index2++;
        PlayerPrefs.SetInt("p2", index2);
        p2.color = Characters[index2].color;
    }

    public void p2ChangeLeft()
    {
        if (index2 == 0) { return; }
        index2--;
        PlayerPrefs.SetInt("p2", index2);
        p2.color = Characters[index2].color;
    }
}
