using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    
    bool gameOver;
    public bool pause;

    public Button[] buttonsDeath;
    public Button[] buttonsMenu;
    public Button buttonPause;
    public Button Lose;
    public Button Victory;

    // Use this for initialization
    void Start () {
        gameOver = false;
        pause = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Exit()
    {
        Application.Quit();
    }

    //Your scene name
    public void StartGame()
    {
        Application.LoadLevel("Scene 1");
    }

    public void Settings()
    {

        Application.LoadLevel("Settings");
    }

    public void Credits()
    {

        Application.LoadLevel("Credits");
    }

    public void Help()
    {

        Application.LoadLevel("Help");
    }

    public void Back()
    {
        Application.LoadLevel("Menu");
    }

    public void Menu()
    {

        Application.LoadLevel("Menu");
    }

    public void Replay()
    {
        Application.LoadLevel("Menu");
    }

    public void Loser()
    {
        Application.LoadLevel(Application.loadedLevel);
        
    }

    public void Win()
    {
        Application.LoadLevel("Menu");
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pause = true;
        foreach (Button button in buttonsMenu)
        {
            button.gameObject.SetActive(true);
        }
        buttonPause.gameObject.SetActive(false);
    }

    public void Continue()
    {
        pause = false;
        Time.timeScale = 1;
        foreach (Button button in buttonsMenu)
        {
            button.gameObject.SetActive(false);
        }
        buttonPause.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        
        gameOver = true;
        Lose.gameObject.SetActive(true);
        buttonPause.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void Victor()
    {
        Victory.gameObject.SetActive(true);
        buttonPause.gameObject.SetActive(false);
    }

   
}
