using UnityEngine;
using System.Collections;

public class MusicScript : MonoBehaviour {
	static MusicScript instance=null;
	// Use this for initialization
	void Awake(){
		if(instance){
			Destroy(gameObject);
		}
		else{
			instance=this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}

}
