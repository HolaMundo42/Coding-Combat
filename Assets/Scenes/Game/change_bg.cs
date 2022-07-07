using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class change_bg : MonoBehaviour
{
    [SerializeField] Image bg;
    Color[] colors = {Color.cyan, Color.blue, Color.grey};
    int maxBGs = 2;
    int idx;

    void Start()
    {
        idx = 0;
        setBG(idx);
    }

    void setBG(int idx)
    {
        PlayerPrefs.SetInt("Background", idx);
        bg.color = colors[idx];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
    }

    public void MoveRight()
    {
        if(idx == maxBGs) { return; }
        else
        {
            idx++;
            setBG(idx);
        }
    }
    public void MoveLeft()
    {
        if (idx == 0) { return; }
        else {
            idx--;
            setBG(idx);
        }
            
    }
}
