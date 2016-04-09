﻿/*
 * Source File Name: HeroController.cs
 * Author: Lovepreet Ralh
 * Last Modified by: Lovepreet ralh
 * Date Last Modified: 29 Feb,2016
 * Program Description: Controls the speed of player, jump force, moving force as well as the direction of running 
 * Revision History:version 1.6
 * 
 */


using UnityEngine;
using System.Collections;

//Velocity range utility class#######
[System.Serializable]
public class VelocityRange
{
    //Public Instance Variable
    public float minimum;
    public float maximum;

    //Constructor#####
    public VelocityRange(float minimum, float maximum)
    {
        this.minimum = minimum;
        this.maximum = maximum;
    }
}

public class HeroControllerScript : MonoBehaviour
{

    //Public Instance variables
    public VelocityRange velocityRange;
    public float moveForce;
    public float jumpForce;
    public Transform groundCheck;
    public Transform camera;

    public GameController gameController;
    Vector3 currentPosition;

    //Private Instance Variables
    private Animator _animator;
    private float _move;
    private float _jump;
    private bool _facingRight;
    private Transform _transform;
    private Rigidbody2D _rigidBody2D;
    private bool _isGrounded;
    private AudioSource[] _audioSources;
    private AudioSource _starSound;
    private AudioSource _jumpSound;
    private AudioSource _themeSound,_gameOverSound,_hurtSound;
    // Use this for initialization
    void Start()
    {
        //Initialize Public Variables
        this.velocityRange = new VelocityRange(300f, 500f);
        //Initialize Private Varibles 
        this._transform = gameObject.GetComponent<Transform>();
        this._animator = gameObject.GetComponent<Animator>();
        this._rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        this._move = 0f;
        this._jump = 0f;
        
        this._facingRight = true;

        //setup AudioSources
        this._audioSources = gameObject.GetComponents<AudioSource>();
        this._starSound = this._audioSources[0];
        this._jumpSound = this._audioSources[1];
        this._themeSound = this._audioSources[2];
        this._gameOverSound = this._audioSources[3];
        this._hurtSound = this._audioSources[4];
        // place the hero in the starting position
        this._spawn();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
         currentPosition = new Vector3(-1.5f, this._transform.position.y, -10f);
        this.camera.position = currentPosition;
        
        this._isGrounded = Physics2D.Linecast(this._transform.position, this.groundCheck.position, 1<< LayerMask.NameToLayer("Ground"));
        Debug.DrawLine(this._transform.position, this.groundCheck.position);

      // Debug.Log(_isGrounded);

        float forceX = 0f;
        float forceY = 0f;

        //ge absolute value of velocity for our gameobject
        float absVelX = Mathf.Abs(this._rigidBody2D.velocity.x);
        float absVelY = Mathf.Abs(this._rigidBody2D.velocity.y);
       // Debug.Log(_isGrounded);
        //check if the player is grounded
		if (this._isGrounded)
        {
            //gets a number between -1 to 1 for both horizontaland vertical axis
            this._move = Input.GetAxis("Horizontal");
            this._jump = Input.GetAxis("Vertical");
            if (this._move != 0)
            {
                if (this._move > 0)
                {
                    //movement force
                    if (absVelX < this.velocityRange.maximum)
                    {
                        forceX = this.moveForce;
                    }
                    this._facingRight = true;
                    this._flip();
                }
                if (this._move < 0)
                {
                    //movement force
                    if (absVelX < this.velocityRange.maximum)
                    {
                        forceX = -this.moveForce;
                    }
                    this._facingRight = false;
                    this._flip();
                }
                //call the walk animation
                this._animator.SetInteger("AnimState", 1);
            }
            else
            {
                //set to idle
                this._animator.SetInteger("AnimState", 0);
            }
            if (this._jump > 0)
            {
                //jump force
                if (absVelY < this.velocityRange.maximum)
                {
                    this._jumpSound.Play();
                    forceY = this.jumpForce;

                    
                }
                this._animator.SetInteger("AnimState", 2);
                this._isGrounded = false;

            }
        }
        else
        {

            //call the jump animation
            this._animator.SetInteger("AnimState", 2);

            //call jump sound;
            
        }
        //Apply forces to the player
        this._rigidBody2D.AddForce(new Vector2(forceX, forceY));
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("StarLevel1"))
        {
            this._starSound.Play();
            Destroy(other.gameObject);
            this.gameController.ScoreValue += 100;
        }

        if (other.gameObject.CompareTag("EnemyLevel1"))
        {
            this._hurtSound.Play();
            Destroy(other.gameObject);
            this.gameController.LivesValue--;
        }

        //if (other.gameObject.CompareTag("Death"))
        //{
        //    this._spawn();
        //    this._hurtSound.Play();
        //   this.gameController.LivesValue--;
        //}

        if (other.gameObject.CompareTag("HouseLevel1")|| this.gameController.LivesValue<=0)
        {
            
            Destroy(other.gameObject);
            this._themeSound.Stop();
            this._gameOverSound.Play();
            this.gameController._endGame();
        }
    }

    //Private Methods
    private void _flip()
    {
        if (this._facingRight)
        {
            this._transform.localScale = new Vector2(1.8f, 1f);
        }
        else
        {
            this._transform.localScale = new Vector2(-1.8f, 1f);
        }
    }

    private void _spawn()
    {
        this._transform.position = new Vector3(-200f, -185f, 0);        //180f, 1090f   //
    }
}
