using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] GameObject gameover;


    public void loss()
    {
        //if the player dies the this is called
        gameover.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TryAgain()
    {
        //if the player presses the game over button the last level is rest and played again
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}
