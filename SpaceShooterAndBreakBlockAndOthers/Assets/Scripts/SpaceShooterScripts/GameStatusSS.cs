﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatusSS : MonoBehaviour
{
    // Singleton : only one can exist (ex: score system)
    // Children inherit singleton pattern

    // config param
    // For time manaagement Unscale Time can help for normal speed animation or player
    //Range add a slider in Unity Inspector
    [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayOn;
    // cache

    // state variable
    [SerializeField] int currentScore = 0;

    // Singleton to keep game statue in all level
    private void Awake() {
        SetUpSingleton();

    }

    private void SetUpSingleton(){
        int numberGameSessions = FindObjectsOfType<GameStatusSS>().Length;
        if(numberGameSessions > 1){
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    // addToScore : count and add score to text
    public void addToScore(int scoreValue){
        currentScore += scoreValue;
        scoreText.text = currentScore.ToString();
    }

    // ResetGame : for replay game -> reset score
    public void ResetGame(){
        Destroy(gameObject);
    }

    // IsAutoPlayOn : verify bool autoplay
    public bool IsAutoPlayOn(){
        return isAutoPlayOn;
    }
}
