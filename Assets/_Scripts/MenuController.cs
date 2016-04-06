using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Event Handler for StartButtonClick

	public void StartButtonClick() {
		SceneManager.LoadScene ("Level1");
	}

	public void InstructionsButtonClick() {
		SceneManager.LoadScene ("Instructions");
	}

	public void LevelsButtonClick() {
		SceneManager.LoadScene ("Levels");
	}

	public void QuitButtonClick() {
		Application.Quit();
	}
		
}
