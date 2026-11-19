using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool menu = false;



    public void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }


    public void Update()
    {
        GetPause();
    }

    private void GetPause()
    {
        if (Keyboard.current == null)
            return;
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (menu)
                Resume();
            else
                Pause();
        }
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Debug.Log("its on pause");
        menu = true;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        menu = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

    }

    public void BackToMain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScreen");

    }
}
