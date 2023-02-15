using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public float speed;
    public GameObject Explosion;
    public int maxHealth = 2;
    int currenthealth;
    GameObject scoretext;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxHealth;
        speed = 2f;
        scoretext = GameObject.FindGameObjectWithTag("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            currenthealth--;

            if (currenthealth <= 0)
            {
                SceneManager.LoadScene("Win");
            }
        }

    }

    public void playExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        explosion.transform.position = transform.position;
    }
}
