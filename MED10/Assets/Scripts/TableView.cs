﻿using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class TableView : MonoBehaviour {
	public Vector2 scrollPosition;
	private bool showTable = false;
	private string scores;

	static float WIDTH = Screen.width;
	static float HEIGHT = Screen.height;

	//-----//
	const int ButtonWidth = 256;
	const int ButtonHeight = 64;

	private bool mSavePressed = false;
	private bool mCancelPressed = false;
	private string mTitle = "";
	private string mMessage = "";
	private bool showPopUp = false;
	//-----//


	//-----//
	int scrollFinger = -1;
	Vector2 scrollPos = Vector2.zero;

	Vector2 TouchScrollView(Rect aScreenRect, Vector2 aScrollPos, Rect aContentRect, ref int aFingerID) {
		aScrollPos = GUILayout.BeginScrollView(aScrollPos);

		foreach (Touch T in Input.touches) {
			if (T.phase == TouchPhase.Began) {
				Vector2 pos = T.position;
				if (aScreenRect.Contains(pos)) {
					aFingerID = T.fingerId;
				}
			} else if (aFingerID == T.fingerId) {
				Vector2 delta = T.deltaPosition;
				aScrollPos.y += delta.y;
				aScrollPos.x -= delta.x;

				if (T.phase == TouchPhase.Ended || T.phase == TouchPhase.Canceled) {
					aFingerID = -1;
				}
			}
			return aScrollPos;
		}
		return aScrollPos;
	}
	//-----//

	public void Table() {
		//scores = _scores;
		showTable = true;
	}

	#if UNITY_ANDROID

	private class PositiveButtonListner:AndroidJavaProxy {
		private TableView mDialog;

		public PositiveButtonListner(TableView d):base("android.content.DialogInterface$OnClickListener") {
			mDialog = d;
		}

		public void onClick(AndroidJavaObject obj, int value) {
			mDialog.mSavePressed = true;
			mDialog.mCancelPressed = false;
		}
	}

	private class NegativeButtonListner:AndroidJavaProxy {
		private TableView mDialog;

		public NegativeButtonListner(TableView d):base("android.content.DialogInterface$OnClickListener") {
			mDialog = d;
		}

		public void onClick(AndroidJavaObject obj, int value) {
			mDialog.mSavePressed = false;
			mDialog.mCancelPressed = true;
		}
	}

	#endif

	private void showDialog() {
		#if UNITY_ANDROID

		AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

		activity.Call("runOnUiThread", new AndroidJavaRunnable(() => {

			AndroidJavaObject alertDialogBuilder = new AndroidJavaObject("android/app/AlertDialog$Builder", activity);

			alertDialogBuilder.Call<AndroidJavaObject>("setTitle", mTitle);
			alertDialogBuilder.Call<AndroidJavaObject>("setMessage", mMessage);
			alertDialogBuilder.Call<AndroidJavaObject>("setCancelable", true);

			alertDialogBuilder.Call<AndroidJavaObject>("setNegativeButton","Close",new NegativeButtonListner(this));

			AndroidJavaObject dialog = alertDialogBuilder.Call<AndroidJavaObject>("create");
			dialog.Call("show");

			}));
			#endif
	}

	void OnGUI() {

		if (showPopUp) {
			showDialog();
			showPopUp = false;
		}

		if (mSavePressed) {
			mSavePressed = false;
		}


		GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,new Vector3(Screen.width / WIDTH, Screen.height / HEIGHT, 1));
		if (showTable) {
			//scores = "a\tb\tc\nd\te\tf\na\tb\tc\nd\te\tf\na\tb\tc\nd\te\tf\na\tb\tc\nd\te\tf\na\tb\tc\nd\te\tf\na\tb\tc\nd\te\tf\na\tb\tc\nd\te\tf\na\tb\tc\nd\te\tf\n";

			scores = "Student name\tGame id\tGame name\tTime\nDeborah Wells\t509579\tQuiz\tApr 14 15:27:36 2016 GMT\nNora Terry\t509579\tQuiz\tJun 19 18:27:36 2013 GMT\nCynthia Grant\t509579\tQuiz\tJun 19 18:27:36 2013 GMT\nJonathan Jones\t307371\tPuzzle\tJun 19 18:27:36 2013 GMT\nEarl Washington\t255414\tAdventure\tApr 14 15:27:36 2016 GMT\nJacqueline Foster\t255414\tAdventure\tApr 14 15:27:36 2016 GMT\nDeborah Wells\t509579\tQuiz\tApr 14 15:27:36 2016 GMT\nNora Terry\t509579\tQuiz\tJun 19 18:27:36 2013 GMT\nCynthia Grant\t509579\tQuiz\tJun 19 18:27:36 2013 GMT\nJonathan Jones\t307371\tPuzzle\tJun 19 18:27:36 2013 GMT\nEarl Washington\t255414\tAdventure\tApr 14 15:27:36 2016 GMT\nJacqueline Foster\t255414\tAdventure\tApr 14 15:27:36 2016 GMT\nDeborah Wells\t509579\tQuiz\tApr 14 15:27:36 2016 GMT\nNora Terry\t509579\tQuiz\tJun 19 18:27:36 2013 GMT\nCynthia Grant\t509579\tQuiz\tJun 19 18:27:36 2013 GMT\nJonathan Jones\t307371\tPuzzle\tJun 19 18:27:36 2013 GMT\nEarl Washington\t255414\tAdventure\tApr 14 15:27:36 2016 GMT\nJacqueline Foster\t255414\tAdventure\tApr 14 15:27:36 2016 GMT\nDeborah Wells\t509579\tQuiz\tApr 14 15:27:36 2016 GMT\nNora Terry\t509579\tQuiz\tJun 19 18:27:36 2013 GMT\nCynthia Grant\t509579\tQuiz\tJun 19 18:27:36 2013 GMT\nJonathan Jones\t307371\tPuzzle\tJun 19 18:27:36 2013 GMT\nEarl Washington\t255414\tAdventure\tApr 14 15:27:36 2016 GMT\nJacqueline Foster\t255414\tAdventure\tApr 14 15:27:36 2016 GMT\nDeborah Wells\t509579\tQuiz\tApr 14 15:27:36 2016 GMT\nNora Terry\t509579\tQuiz\tJun 19 18:27:36 2013 GMT\nCynthia Grant\t509579\tQuiz\tJun 19 18:27:36 2013 GMT\nJonathan Jones\t307371\tPuzzle\tJun 19 18:27:36 2013 GMT\nEarl Washington\t255414\tAdventure\tApr 14 15:27:36 2016 GMT\nJacqueline Foster\t255414\tAdventure\tApr 14 15:27:36 2016 GMT\nDeborah Wells\t509579\tQuiz\tApr 14 15:27:36 2016 GMT\nNora Terry\t509579\tQuiz\tJun 19 18:27:36 2013 GMT\nCynthia Grant\t509579\tQuiz\tJun 19 18:27:36 2013 GMT\nJonathan Jones\t307371\tPuzzle\tJun 19 18:27:36 2013 GMT\nEarl Washington\t255414\tAdventure\tApr 14 15:27:36 2016 GMT\nJacqueline Foster\t255414\tAdventure\tApr 14 15:27:36 2016 GMT\n";
			float win = Screen.width*0.6f;
			float w1=win*0.35f;
			float w2=win*0.15f;
			float w3=win*0.35f;

		    string[] lines = Regex.Split(scores, "[\\n]");
			GUILayout.BeginArea(new Rect(100,100,Screen.width-200,Screen.height-400));
			//scrollPosition = GUILayout.BeginScrollView(scrollPosition,GUILayout.Width(Screen.width-200),GUILayout.Height(Screen.height-400));

			//-----//
			scrollPos = TouchScrollView(new Rect(100,100,Screen.width-200,Screen.height-400),scrollPos,new Rect(100,100,Screen.width-200,Screen.height-400), ref scrollFinger);
			//-----//


		    foreach (string _line in lines) {
		        string[] fields = Regex.Split(_line, "[\\t]");

				if (fields.Length >= 4) {

					GUILayout.BeginHorizontal("Box");
					if(GUILayout.Button(fields[0], GUILayout.Width(w1))) {
						showPopUp = true;
						mTitle=fields[0];
						mMessage=fields[1] + " : " + fields[2] + " : "  + fields[3];
					}
					GUILayout.Label(fields[1], GUILayout.Width(w2));
					GUILayout.Label(fields[2], GUILayout.Width(w3));
					GUILayout.Label(fields[3], GUILayout.Width(w3));
					GUILayout.EndHorizontal();
				}
		    }
			GUILayout.EndScrollView();

			GUILayout.EndArea();

		}
	}
}
