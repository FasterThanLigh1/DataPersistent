using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    Text scoreText;
    int score;
    void Awake()
    {
        score = ManagerScript.Instance.GetScore();
    }
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "High score: " + score + " || Name: " + ManagerScript.Instance.GetName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
