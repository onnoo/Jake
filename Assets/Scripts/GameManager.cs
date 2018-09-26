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

    public Canvas menuCanvas;
    public Canvas inGameCanvas;
    public Canvas gameOverCanvas;

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
        LevelGenerator.instance.StartGame();
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
            menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.inGame)
        {
            //setup Unity scene for inGame state
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
        }
        else if (newGameState == GameState.gameOver)
        {
            //setup Unity scene for gameOver state
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
        }

        currentGameState = newGameState;
    }
}
