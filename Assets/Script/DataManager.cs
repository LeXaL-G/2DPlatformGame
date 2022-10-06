using System;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    private int shotBullet;
    public int totalShotBullet = 0;
    private int enemieKilled;
    public int totalEnemieKilled = 0;
    public static DataManager Instance;
    private void Start()
    {
        totalShotBullet = PlayerPrefs.GetInt("shotBullet", DataManager.Instance.totalShotBullet);
        totalEnemieKilled = PlayerPrefs.GetInt("enemieKilled", DataManager.Instance.totalEnemieKilled);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }        
        else
        {
            Destroy(gameObject);
        }     
        DontDestroyOnLoad(gameObject);
    }

    public int ShotBullet
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            GameObject.Find("ShotBullet").GetComponent<Text>().text = $"Shot Bullet: {shotBullet.ToString()}";
        }
    }
    public int EnemieKilled {    
        get
        {
            return enemieKilled;
        }
        set
        {
            enemieKilled = value;
            GameObject.Find("EnemieKilled").GetComponent<Text>().text = $"Enemie Killed: {enemieKilled.ToString()}";
        }
    }
}

    
