using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	public bool pressContinue;

	public void LoadLevelScene(string level){
		SceneManager.LoadScene (level);
        Time.timeScale = 1;
    }
	public void ContinueGame(){
		Debug.Log ("Pressed Continue");
        Time.timeScale = 1;
	}
	public void QuitGame(){
		Application.Quit ();
	}
}
