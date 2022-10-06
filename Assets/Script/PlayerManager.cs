using System;
using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health, bulletSpeed;
    Transform muzzle;
    public Transform bullet, bloodParticle;
    public Slider slide;
    public GameObject floatingText;
    public GameObject WinPanel, LosePanel;
    private bool bloodDestroyed = false;
    Coroutine test;
    IEnumerator testEnumarator;

    void Start()
    {
        muzzle = transform.GetChild(1);
        slide.maxValue = health;
        slide.value = health;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShotBullet();
        }
    
        AmIWinner();
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Obstruct")
        {
            Time.timeScale = 0;
            health = 0;
            AmIDeath();
            LosePanel.SetActive(true);
        }
    }

    public void GetDamage(float damage)
    {
        Instantiate(floatingText, transform.position, quaternion.identity).GetComponent<TMP_Text>().text =
            damage.ToString();
        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
            health = 0;

        slide.value = health;
        AmIDeath();
    }

    void AmIDeath()
    {
        if (health <= 0)
        {
            StartCoroutine(BloodWait());
            LosePanel.SetActive(true);
        }
    }

    void ShotBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
        DataManager.Instance.ShotBullet++;
        DataManager.Instance.totalShotBullet++;
        PlayerPrefs.SetInt("shotBullet", DataManager.Instance.totalShotBullet);
    }

    public void AmIWinner()
    {
        if (DataManager.Instance.EnemieKilled >= 4)
        {
            Time.timeScale = 0;
            DataManager.Instance.EnemieKilled = 0;
            WinPanel.SetActive(true);
        }
    }

    IEnumerator BloodWait()
    {
        Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 3);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
    }
    
}