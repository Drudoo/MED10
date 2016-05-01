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

	public Texture tex;

	private int totalImages = 0;

	void Start() {
		DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath + "/");
		FileInfo[] info = dir.GetFiles("*.*");

		foreach (FileInfo f in info) {
			//Debug.Log(Path.GetFileName(f.ToString()));
			files.Add(Path.GetFileNameWithoutExtension(f.ToString()));
		}
	}

	void OnGUI() {
		if (ApplicationModel.downloaded) {
			if (async != null) {
	            GUI.DrawTexture(new Rect(Screen.width/2-256/2, Screen.height/3, 256, 16), emptyProgressBar);
	            GUI.DrawTexture(new Rect(Screen.width/2-256/2, Screen.height/3, 256 * async.progress, 16), fullProgressBar);
	        }

			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,new Vector3(Screen.width / WIDTH, Screen.height / HEIGHT, 1));
			GUILayout.BeginArea(new Rect(100,250,800,300));
		    GUILayout.BeginHorizontal();


			if (files.Count == 1) {
				GUILayout.BeginVertical();
		        if(GUILayout.Button(tex)) {
		            Debug.Log("pressed Item " + files[0]);
					ApplicationModel.currentLevel = files[0];
					//SceneManager.LoadScene("Game");
					SyncLoadLevel("Game");
		        }
				GUILayout.Label(files[0]);
				GUILayout.EndVertical();
			} else if (files.Count == 2) {
				for (int i = 0; i < 2; i++) {
					GUILayout.BeginVertical();
			        if(GUILayout.Button(tex)) {
			            Debug.Log("pressed Item " + files[i]);
						ApplicationModel.currentLevel = files[i];
						//SceneManager.LoadScene("Game");
						SyncLoadLevel("Game");
			        }
					GUILayout.Label(files[i]);
					GUILayout.EndVertical();
				}
			} else {
				for (int i = files.Count; i --> totalImages;) {

					GUILayout.BeginVertical();
			        if(GUILayout.Button(tex)) {
			            Debug.Log("pressed Item " + files[i]);
						ApplicationModel.currentLevel = files[i];
						//SceneManager.LoadScene("Game");
						SyncLoadLevel("Game");
			        }
					GUILayout.Label(files[i]);
					GUILayout.EndVertical();
				}
			}



		    foreach(string i in files) {

		    }
		    GUILayout.EndHorizontal();
		    GUILayout.EndArea();
		}

	}


	public Texture2D emptyProgressBar; // Set this in inspector.
	public Texture2D fullProgressBar; // Set this in inspector.

	private AsyncOperation async = null; // When assigned, load is in progress.
	private void SyncLoadLevel(string levelName) {
	     async = Application.LoadLevelAsync (levelName);
	     Load ();
	 }

	 IEnumerator Load ()
	 {
	     yield return async;
	 }

}
