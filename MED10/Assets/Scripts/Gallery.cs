using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Gallery : MonoBehaviour {

	private List<string> files = new List<string>();

	static float WIDTH = Screen.width/2;
	static float HEIGHT = Screen.height/2;

	void Start() {
		DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath + "/");
		FileInfo[] info = dir.GetFiles("*.*");

		foreach (FileInfo f in info) {
			Debug.Log(Path.GetFileName(f.ToString()));
			files.Add(Path.GetFileNameWithoutExtension(f.ToString()));
		}
	}

	void OnGUI() {
		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,new Vector3(Screen.width / WIDTH, Screen.height / HEIGHT, 1));
		GUILayout.BeginArea(new Rect(25,25,150,300));
	    GUILayout.BeginVertical();
	    foreach(string i in files) {
	        if(GUILayout.Button(i)) {
	            Debug.Log("pressed Item " + i);
				ApplicationModel.currentLevel = i;
				SceneManager.LoadScene("Game");
	        }
	    }
	    GUILayout.EndVertical();
	    GUILayout.EndArea();
	}

}
