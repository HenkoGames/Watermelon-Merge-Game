using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI t;
    void Update()
    {
        t.text = Core.score + "";
    }
}
