using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState currentGameState = GameState.menu;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentGameState = GameState.menu;
    }

    void Update()
    {
        if (Input.GetButtonDown("s"))
        {
            StartGame();
        }
    }

    //called to start the game
    public void StartGame()
    {
        SetGameState(GameState.inGame);
        PlayerController.instance.StartGame();
    }

    //called when player die
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    //called when player decide to go back to the menu
    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //setup Unity scene for menu state
        }
        else if (newGameState == GameState.inGame)
        {
            //setup Unity scene for inGame state
        }
        else if (newGameState == GameState.gameOver)
        {
            //setup Unity scene for gameOver state
        }

        currentGameState = newGameState;
    }
}
