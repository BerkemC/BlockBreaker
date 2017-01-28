using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Brick.counter=0;
		Application.LoadLevel(name);
	}
	public void Exit(){
		Application.Quit();
	}
	public void LoadNextLevel(){
		Brick.counter=0;
		Application.LoadLevel(Application.loadedLevel+1);
	}
	public void LoadSameLevel(){
		Brick.counter=0;
		Application.LoadLevel(Application.loadedLevel-1);
	}
}
