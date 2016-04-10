﻿/*
 * Source File Name: GameController.cs
 * Author: Lovepreet Ralh
 * Last Modified by: Bhanu Kaplish
 * Date Last Modified: 8th Apr,2016
 * Program Description: Controls the score, lives and restart the game
 * Revision History:version 1.4
 * 
 */
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // PRIVATE INSTANCE VARIABLES
    private int _scoreValue;
    private int _livesValue;
    //[SerializeField]
    //private AudioSource _gameoverSound;


    // PUBLIC ACCESS METHODS
    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            this.ScoreLabel.text = "Score: " + this._scoreValue;
        }
    }

    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }

        set
        {
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
                this._endGame();
            }
            else
            {
                this.LivesLabel.text = "Lives: " + this._livesValue;
            }
        }
    }

    // PUBLIC INSTANCE VARIABLES
    public Text LivesLabel;
    public Text ScoreLabel;
    public Text GameOverLabel;
    public Text HighScoreLabel;
    public HeroControllerScript hero;
    public Button RestartButton, NextLevelButton;

    // Use this for initialization
    void Start()
    {
        this._initialize();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //PRIVATE METHODS ++++++++++++++++++

    //Initial Method
    private void _initialize()
    {
        this.ScoreValue = 0;
        this.LivesValue = 3;
        this.GameOverLabel.gameObject.SetActive (false);
        this.HighScoreLabel.gameObject.SetActive (false);
        this.RestartButton.gameObject.SetActive(false);
		this.NextLevelButton.gameObject.SetActive(false);
    }
    
    // PUBLIC METHODS
    public void _endGame()
    {
        this.HighScoreLabel.text = "High Score: " + this._scoreValue;
        this.GameOverLabel.gameObject.SetActive(true);
        this.HighScoreLabel.gameObject.SetActive(true);
        this.LivesLabel.gameObject.SetActive(false);
        this.ScoreLabel.gameObject.SetActive(false);
        this.hero.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(true);
        //this._gameoverSound.Play();
    }
	public void nextLevel(){
		this.HighScoreLabel.text = "High Score: " + this._scoreValue;
		//this.GameOverLabel.gameObject.SetActive(true);
		this.HighScoreLabel.gameObject.SetActive(true);
		this.LivesLabel.gameObject.SetActive(false);
		this.ScoreLabel.gameObject.SetActive(false);
		this.hero.gameObject.SetActive(false);
		this.NextLevelButton.gameObject.SetActive(true);
	}
		

    public void RestartButtonClick()
    {
        Application.LoadLevel("Level1");
    }
	public void NextLevelButtonClick()
	{
		Application.LoadLevel("Level3");
	}
}