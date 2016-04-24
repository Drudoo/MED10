using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	// Update is called once per frame
	public void ChangeToScene (string sceneToChangeTo) {
		Debug.Log("Load: " + sceneToChangeTo);

		SceneManager.LoadScene(sceneToChangeTo);
	}

}
