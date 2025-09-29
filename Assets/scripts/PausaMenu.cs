using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausaMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject botonAbrirMenu; 
    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
    }

    public void Pausa()
    {
        TogglePause();
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(true);
            botonAbrirMenu.SetActive(false); 
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            botonAbrirMenu.SetActive(true); 
        }
    }

    public void ResetGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void ContinueGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        botonAbrirMenu.SetActive(true); 
    }

    public void QuiteGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

