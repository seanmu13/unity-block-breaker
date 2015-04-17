using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	
	public Sprite[] hitSprites;
	
	private int timesHit;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		bool isBreakable = (this.tag == "Breakable");
		
		if (isBreakable) {
			HandleHits();
		}		
	}
	
	void HandleHits () {
		this.timesHit++;
		int maxHits = hitSprites.Length + 1;
		
		if(this.timesHit >= maxHits) {
			Destroy(gameObject);
		}
		else {
			LoadSprites();
		}	
	}
	
	void LoadSprites() {
		int spriteIndex = timesHit - 1;
		
		if(hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	// TODO Remove this method once we actually win!	
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
