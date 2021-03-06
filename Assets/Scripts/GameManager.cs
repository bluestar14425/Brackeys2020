﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    
    [SerializeField]
    private GameObject levelCompleteText = null;

    private float resetDelay = 1;

    public LevelChanger fade;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Win()
    {
        levelCompleteText.SetActive(true);
        Time.timeScale = .5f;
        fade.Fade();
        Invoke("Reset", resetDelay);
    }

    public void Reset()
    {
        Time.timeScale = 1f;
        switch (SceneManager.GetActiveScene().name)
        {
            case "LevelOne":
            SceneManager.LoadScene("LevelTwo");
            GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMainMusic();
            break;

            case "LevelTwo":
            SceneManager.LoadScene("LevelThree");
            GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMainMusic();
            break;

            default:
            SceneManager.LoadScene("Menu");
            GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMenuMusic();
            break;
            
        }
            
    }
}
