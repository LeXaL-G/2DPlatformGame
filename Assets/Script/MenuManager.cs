using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject ScoreBoard;
    public void playButton()
    {
        SceneManager.LoadScene(1);
    }

    public void quitButton()
    {
        Application.Quit();
    }

    public void scoreButton()
    {
        ScoreBoard.transform.GetChild(1).GetComponent<Text>().text = PlayerPrefs.GetInt("shotBullet", DataManager.Instance.totalShotBullet).ToString();
        ScoreBoard.transform.GetChild(2).GetComponent<Text>().text = PlayerPrefs.GetInt("enemieKilled", DataManager.Instance.totalEnemieKilled).ToString();
        ScoreBoard.SetActive(true);
    }

    public void XButon()
    {
        ScoreBoard.SetActive(false);
    }




}
