using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ViewGameOver : MonoBehaviour
{
    public static ViewGameOver instance;
    public Text coinsLabel;
    public Text score;

    void Awake()
    {
        instance = this;
    }

    public void RefreshResult()
    {
        coinsLabel.text = PlayerController.instance.collectedCoins.ToString();
        score.text = PlayerController.instance.GetDistance().ToString("f0");
    }
}
