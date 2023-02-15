using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScore : MonoBehaviour
{
    TextMeshProUGUI text;
    int score;
    public GameObject enemy;

    public int Score
    {
        get 
        { 
            return this.score; 
        }
        set
        {
            this.score = value;
            UpdateScore();
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= 11000)
        {
            SceneManager.LoadScene("Win");
        }
    }

    void UpdateScore()
    {
        string Score = string.Format("{0:00000}", score);
        text.text = Score;
    }

}
