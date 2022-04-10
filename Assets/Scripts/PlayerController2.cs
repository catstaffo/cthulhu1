using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using TMPro;

public class PlayerController2 : MonoBehaviour
{
	

	public static event Action OnPlayerDeath;
    public int maxHealth = 100;
	public int currentHealth;
	public HealthBar healthBar;

	public TextMeshProUGUI scoreGT;
	private int fishTotal;

	public AudioClip collectSound;
	private AudioSource audioPlayer;

	public float speed = 15.0F;
	public float gravity = 20.0F;

	
	
	private Vector3 moveDirection = Vector3.zero;
	public CharacterController controller;

	void Start(){


		GameObject[] fishArray = GameObject.FindGameObjectsWithTag("Fish");
		fishTotal = fishArray.Length;
		scoreGT.text = "Fish left: " + fishTotal;

		audioPlayer = this.GetComponent<AudioSource>();
		

		controller = GetComponent<CharacterController>();

		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	void Update() {
	
		if (controller.isGrounded) 
		{
			
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(20);
		}
		
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

	}
	
	void OnCollisionEnter(Collision coll)
   
    {   GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Fish") {
            Destroy(collidedWith);
			fishTotal -= 1;
			scoreGT.text = "Fish left: " + fishTotal;
            //int score = int.Parse(scoreGT.text);
            //score += 10;
            //scoreGT.text = score.ToString();

			audioPlayer.PlayOneShot(collectSound);

			if (fishTotal == 0) {
				SceneManager.LoadScene("Final");
			}

        }
	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);
		if (currentHealth <= 0 ){
		OnPlayerDeath?.Invoke();
		}
	}

 }