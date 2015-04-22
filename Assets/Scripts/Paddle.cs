using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	public bool autoPlay = false;
	public float xClamp = 1.18f;
	public float yClamp = 14.8f;
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}		
	}
	
	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, xClamp, yClamp);
		this.transform.position = paddlePos;
	}
	
	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, xClamp, yClamp);		
		this.transform.position = paddlePos;
	}
}
