using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Gun : MonoBehaviour
{
    public GameObject EnemyBullets;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireEnemyBullet", 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find("Player");

        if (playerShip != null)
        {
            GameObject bullet = (GameObject)Instantiate(EnemyBullets);

            bullet.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullet>().setDirection(direction);
        }
    }
}
