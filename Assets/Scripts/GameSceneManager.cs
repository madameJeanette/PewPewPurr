using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public Camera mainCamera;
    public Text scoreText;
    public Text gameOverText;
    public PlayerController player;

    int score;
    float gameTimer;
    bool gameOver;

    void Start()
    {
        Time.timeScale = 1; //game time starts at 1

        player.OnHitGoomba += OnHitGoomba; //When player hits enemy
        player.OnHitSpike += OnHitSpike; //When player hits spikes
        player.OnHitOrb += OnGameWin; //When player touches orb = win.

        scoreText.enabled = true; //show game score 
        gameOverText.enabled = false; //do not show game over text yet.
    }


    void Update()
    {
        mainCamera.transform.position = new Vector3(
            Mathf.Lerp(mainCamera.transform.position.x, player.transform.position.y, Time.deltaTime * 10),
            Mathf.Lerp(mainCamera.transform.position.y, player.transform.position.y, Time.deltaTime * 10),
            mainCamera.transform.position.z //main camera update
            );

        if (gameOver)
        {
            if (Input.GetKeyDown("r"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);//load last scene b4 game over on r
            }

            return;
        }

        scoreText.text = " Score: " + score; //get score
        if (player.transform.position.y < -40) OnGameOver();
        
        // when player position falls below -40 game over
    }

    void OnHitGoomba()
    {
        this.score += 100;
    }

    void OnGameOver()
    {
        gameOver = true;

        scoreText.enabled = false;
        gameOverText.enabled = true;

        gameOverText.text = "Oh NO! Game over  \n Press R to restart";

        Time.timeScale = 0;
    }

    void OnGaneWin()
    {
        gameOver = true;

        scoreText.enabled = false;
        gameOverText.enabled = true;

        gameOverText.text = "HOORAAAAAY YOU WIN! \n Press R to restart";

        Time.timeScale = 0;
    }

}
