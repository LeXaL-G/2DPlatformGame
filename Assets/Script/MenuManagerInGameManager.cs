using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore;

public class MenuManagerInGameManager : MonoBehaviour
{
    public GameObject CanvasObject,pauseMenu,WinPanel,LosePanel;
    public void pauseButton()
    {
        Time.timeScale = 0;
        CanvasObject.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void mainMenuButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
    public void continueButton()
    {
        pauseMenu.SetActive(false);
        CanvasObject.SetActive(true);
        Time.timeScale = 1;
    }
    
    public void replaceButton()
    {
        Time.timeScale = 1;
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void replaceButtonWin()
    {
        Time.timeScale = 1;
        WinPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }
    public void replaceButtonLose()
    {
        Time.timeScale = 1;
        LosePanel.SetActive(false);
        SceneManager.LoadScene(1);
    }
    

}