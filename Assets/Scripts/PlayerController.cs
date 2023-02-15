using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject playerBullet;
    public GameObject bulletPosition;
    public GameObject Explosion;
    public TextMeshProUGUI text;
    int maxHealth = 10;
    int currenthealth;
    AudioManager bulletsound;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxHealth;
        text.text = currenthealth.ToString();

        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FindObjectOfType<AudioManager>().Play("Bullet");
            GameObject bullet = (GameObject)Instantiate(playerBullet);
            bullet.transform.position = bulletPosition.transform.position;

        }

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);
    }

    private void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1));

        max.x = max.x - 0.225f;
        min.x = min.x + 0.225F;

        max.y = max.y - 0.225f;
        min.y = min.y + 0.285f;

        Vector2 pos = transform.position;

        pos += direction * speed * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "EnemyBullet")
        {
            currenthealth--;
            text.text = currenthealth.ToString();
            playExplosion();

            if (currenthealth <= 0)
            {
                SceneManager.LoadScene("Fail");
            }
        }

    }

    public void playExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        explosion.transform.position = transform.position;
    }
}
