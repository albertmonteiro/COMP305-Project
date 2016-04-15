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

	// Event Handlers
	public void StartButtonClick() {
		SceneManager.LoadScene ("Level1");
	}

	public void InstructionsButtonClick() 
    {
		SceneManager.LoadScene ("Instructions");
	}

    public void BackButtonClick()
    {
        SceneManager.LoadScene("MainMenu");
    }

	public void QuitButtonClick() 
    {
		Application.Quit();
	}
		
}
