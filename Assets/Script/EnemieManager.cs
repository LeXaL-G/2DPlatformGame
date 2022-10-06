using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class EnemieManager : MonoBehaviour
{
    public float damage, health, speed, startTime;
    private float waitTime;
    private bool colliderBusy = false, facingRight;
    Transform power;
    public Transform[] spotPoint;

    public Slider slide;

    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        slide.maxValue = health;
        slide.value = health;
    }

    private void Update()
    {
        if (facingRight)
        {
            if (waitTime <= 0)
            {
                transform.position =
                    Vector2.MoveTowards(transform.position, spotPoint[1].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, spotPoint[1].position) < .5f)
                {
                    facingRight = false;
                    waitTime = startTime;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else
        {
            if (waitTime <= 0)
            {
                transform.position =
                    Vector2.MoveTowards(transform.position, spotPoint[0].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, spotPoint[0].position) < .5f)
                {
                    facingRight = true;
                    waitTime = startTime;
                }
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && !colliderBusy)
        {
            colliderBusy = true;
            col.GetComponent<PlayerManager>().GetDamage(damage);
        }
        else if (col.gameObject.tag == "Bullet")
        {
            GetDamage(col.GetComponent<BulletManager>().bulletDamage);
        }

        if (col.gameObject.tag == "Player")
        {
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            colliderBusy = false;
    }

    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
            health -= damage;
        else
        {
            health = 0;
        }

        slide.value = health;
        AmIDeath();
    }

    void AmIDeath()
    {
        if (health <= 0)
        {
            DataManager.Instance.EnemieKilled++;
            DataManager.Instance.totalEnemieKilled++;
            PlayerPrefs.SetInt("enemieKilled", DataManager.Instance.totalEnemieKilled);
            Destroy(this.gameObject);
        }
    }
}