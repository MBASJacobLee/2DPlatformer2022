using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public bool clicked;
    public void QuitGame ()
    {
        Application.Quit();
    }

//new game changed varible name for testing
    public void Game2() 
    {
        //creates new game, and sets new scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }   

    public void LoadGame() 
    {
        clicked = true;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
