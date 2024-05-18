using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{

    public static bool isPaused;
    
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject controlsMenu;

    AudioScript audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioScript>();
    }


    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                audioManager.PlaySFX(audioManager.openMenuSound);
                PauseGame();

            }
        }

        // Check if the game is paused before handling UI events
        if (isPaused)
        {
            Debug.Log("game paused");
            // Process UI events while paused
            ProcessUIEvents();
        }
        else
        {
            Debug.Log("game unpaused");
        }
    }

    void ProcessUIEvents()
    {
        // Ensure that UI events are processed even when the game is paused
        EventSystem.current.SetSelectedGameObject(null); 
        EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject); 
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(false);
        optionsMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
        audioManager.PlaySFX(audioManager.closeMenuSound);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Title");
        audioManager.PlaySFX(audioManager.closeMenuSound);

    }

    public void QuitGame()
    {
        Application.Quit();
        audioManager.PlaySFX(audioManager.closeMenuSound);
    }

    public void ActivateOption()
    {
        optionsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        audioManager.PlaySFX(audioManager.switchMenus);
    }


    public void ReturnToPauseScreen()
    {

        optionsMenu.SetActive(false);
        pauseMenu.SetActive(true);
        controlsMenu.SetActive(false);
        audioManager.PlaySFX(audioManager.switchMenus);
    }

    public void ActivateControls()
    {
        controlsMenu.SetActive(true);
        pauseMenu.SetActive(false);
        audioManager.PlaySFX(audioManager.switchMenus);
    }

}
