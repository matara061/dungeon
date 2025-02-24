﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // variavel que verifica se o jogo está pausado ou não
    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject DeathUi;
    public GameObject Player;

    public static PauseMenu instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            FindObjectOfType<AudioManager>().Play("Click");
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
       Player.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        // Realiza o processo abaixo caso o botão de pause seja ativado.
        PauseMenuUI.SetActive(true);
        Player.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        // é possivel inserir o save game ou uma tela de carregamento nessa função quando tiver uma
        Time.timeScale = 1f;
        DeathUi.SetActive(false);
        PauseMenuUI.SetActive(false);
        Player.SetActive(true);
        GameIsPaused = false;
        Debug.Log("Menu");
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        // é possivel configurar um LoadScene nessa função. Assim o jogo atual é encerrado e volta para a tela inicial
        Application.Quit();
        Debug.Log("Saindo do jogo");
    }

    public void LoadGuild()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        // é possivel inserir o save game ou uma tela de carregamento nessa função quando tiver uma
        Time.timeScale = 1f;
        DeathUi.SetActive(false);
        Player.SetActive(true);
        GameIsPaused = false;
        Debug.Log("Guild");
        SceneManager.LoadScene("Guild");
    }

}
