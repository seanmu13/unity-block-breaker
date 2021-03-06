﻿using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip punch;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
	
		GameObject[] getCount;
	
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		getCount = GameObject.FindGameObjectsWithTag ("Breakable");
		breakableCount = getCount.Length;
		print ("breakableCount = " + breakableCount);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint (punch, transform.position, 0.25f);
		if (isBreakable) {
			HandleHits();
		}		
	}
	
	void HandleHits () {
		this.timesHit++;
		int maxHits = hitSprites.Length + 1;
		
		if(this.timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke();	
			Destroy(gameObject);
			print ("breakableCount = " + breakableCount);
		}
		else {
			LoadSprites();
		}	
	}
	
	void PuffSmoke() {
		GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		
		if(hitSprites[spriteIndex] != null) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else {
			Debug.LogError("Could not load brick sprites");
		}
	}
	
	// TODO Remove this method once we actually win!	
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
