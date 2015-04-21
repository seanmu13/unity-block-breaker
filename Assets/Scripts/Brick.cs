using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	
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
		// TODO Enable Audio
		//AudioSource.PlayClipAtPoint (crack, transform.position);
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
			Destroy(gameObject);
			print ("breakableCount = " + breakableCount);
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
