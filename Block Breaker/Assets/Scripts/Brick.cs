using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public AudioClip crack;
	private LevelManager levelManager;
	public static int counter=0;
	public Sprite[] hitSprites;
	private bool IsBreakable;
	public GameObject smoke;
	
	private int currentHit;
	// Use this for initialization
	void Start () {
		currentHit=0;
		levelManager=GameObject.FindObjectOfType<LevelManager>();
		IsBreakable =(this.tag=="Breakable");
		if(IsBreakable)counter++;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter2D(Collision2D collider){
		if(IsBreakable) HandleHits();		
	}
	
	void HandleHits(){
		currentHit++;
		int maxHits=hitSprites.Length+1;
		
		if(currentHit >= maxHits){
			AudioSource.PlayClipAtPoint( crack ,transform.position);
			puffSmoke();
			Destroy(gameObject,Time.deltaTime);
			counter--;
			if (counter<=0){
				Application.LoadLevel(Application.loadedLevel+1);
			}
		}
		else{
			LoadSprites();
		}
	}
	
	void LoadSprites(){
		int i=currentHit-1;
		if(hitSprites[i]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[i];
		}
		
	}
	void puffSmoke(){
		GameObject smokePuff=Instantiate(smoke,gameObject.transform.position,Quaternion.identity)as GameObject;
		smokePuff.GetComponent<ParticleSystem>().startColor=gameObject.GetComponent<SpriteRenderer>().color;
	}
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
	
		
}
