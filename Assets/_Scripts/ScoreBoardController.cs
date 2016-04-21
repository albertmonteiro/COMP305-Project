using UnityEngine;
using System.Collections;

public class ScoreBoardController : MonoBehaviour {


	public int Score;
	public int Lives;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this.gameObject);
		this.Score = 0;
		this.Lives = 5;
		Invoke ("Load", 4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		

	private void Load() {
		Application.LoadLevel ("MainMenu");
	}
}
