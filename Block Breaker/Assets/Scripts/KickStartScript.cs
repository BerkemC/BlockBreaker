using UnityEngine;
using System.Collections;

public class KickStartScript : MonoBehaviour {
	public Paddle paddle;
	private bool start=false;
	private Vector3 paddleToBall;
	// Use this for initialization
	void Start () {
		paddle=GameObject.FindObjectOfType<Paddle>();
		paddleToBall= this.transform.position - paddle.transform.position;
	}
	void OnCollisionEnter2D(Collision2D col){
		Vector2 tweak =new Vector2 (Random.Range(0f,0.2f),Random.Range (0f,0.2f));
		if(start) GetComponent<AudioSource>().Play();
		GetComponent<Rigidbody2D>().velocity+=tweak;
	}
	// Update is called once per frame
	void Update () {
	    
		if(!start) this.transform.position= paddleToBall+paddle.transform.position;
		
		if(Input.GetMouseButtonDown(0)&& !start ){
			this.GetComponent<Rigidbody2D>().velocity=new Vector2 (Random.Range(-4f,4f),Random.Range (10f,12f));
			start=true;
		}
	}
}
