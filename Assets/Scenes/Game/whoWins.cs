using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class whoWins : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI theWinner;
    void Start()
    {
        theWinner.text = "Player " + PlayerPrefs.GetInt("Winner") + " Wins!";
    }
}
