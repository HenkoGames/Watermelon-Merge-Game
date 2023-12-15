using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RestartWindow : MonoBehaviour
{
    public Button restartButton;
    public Button removeAdsButton;
    public Button rateButton;

    public TextMeshProUGUI score;
    public TextMeshProUGUI fruits;


    public void SetScore()
    {
        score.text = Core.score.ToString();
        fruits.text = Core.fruits.ToString();
    }
}
