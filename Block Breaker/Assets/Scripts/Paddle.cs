using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public bool AutoPlay=false;
	// Use this for initialization
	private KickStartScript ball;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!AutoPlay)MoveWithMouse();
		else MoveAuto();
	}
	void MoveWithMouse(){
		Vector3 Paddle = new Vector3(this.transform.position.x,0.5f,0f);
		
		float mousePos=Input.mousePosition.x / Screen.width *16;
		Paddle.x=Mathf.Clamp (mousePos,0.5f,15.5f);
		
		this.transform.position=Paddle;
	}
	void MoveAuto(){
		Vector3 Paddle = new Vector3(this.transform.position.x,0.5f,0f);
		
		ball=KickStartScript.FindObjectOfType<KickStartScript>();
		Paddle.x=Mathf.Clamp (ball.transform.position.x,0.5f,15.5f);
		this.transform.position=Paddle; 
	}
}
