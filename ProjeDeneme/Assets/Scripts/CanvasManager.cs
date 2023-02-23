using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject stopPanel;
    [SerializeField] GameObject hpPngs;
    [SerializeField] GameObject partsPanel;
    [SerializeField] AudioSource bgMusic;
    
    bool isGamePaused;
    bool isMuted;
    
 
    void Start()
    { 
        isMuted = false;
        isGamePaused = false;     
    }

    
    void Update()
    {
        
    }

    public void PlayGame()
    {
        partsPanel.SetActive(true);
    }

    public void PlayPart1()
    {
        Time.timeScale = 1.0f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1); //Saçma bir hata aldýðým için böyle yaptým
    }

    public void PlayPart2()
    {
        Time.timeScale = 1.0f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void PlayPart3()
    {
        Time.timeScale = 1.0f;
        UnityEngine.SceneManagement.SceneManager.LoadScene( 3);
    }

    public void ClosePartsPanel()
    {
        partsPanel.SetActive(false);
    }

    

    public void SetAudio(float soundValue)
    {
        AudioListener.volume = soundValue;
    }

    public void StopGame()
    {

        if (!isGamePaused)
        {
            stopPanel.SetActive(true);
            hpPngs.SetActive(false);
            Time.timeScale = 0f;
            isGamePaused = true;
        }
        else
        {
            stopPanel.SetActive(false);
            hpPngs.SetActive(true);
            Time.timeScale = 1f;
            isGamePaused = false;
        }
    }

    public void MuteAudio()
    {
        if (isMuted==false)
        {
            AudioListener.volume = 0f;
            isMuted= true;
        }
        else
        {
            AudioListener.volume = 0.5f;
            isMuted= false;
        }
    }

    public void ReturnMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {      
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex+1);
        Time.timeScale = 1f;
    }
}
