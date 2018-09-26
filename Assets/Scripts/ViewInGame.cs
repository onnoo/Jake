using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ViewInGame : MonoBehaviour
{
    public Text coinLabel;
    public Text scoreLabel;
    public Text highscoreLabel;

    void Update()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            coinLabel.text = PlayerPrefs.GetInt("coins", 0).ToString();
            scoreLabel.text = PlayerController.instance.GetDistance().ToString("f0");
            highscoreLabel.text = PlayerPrefs.GetFloat("highscore", 0).ToString("f0");
        }
    }
}
