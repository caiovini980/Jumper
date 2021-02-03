using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int scoreAmount;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "" + 00;      
    }

    // Update is called once per frame
    public void UpdateScore(int score)
    {
        scoreAmount += score;
        scoreText.text = "" + scoreAmount.ToString();
    }
}
