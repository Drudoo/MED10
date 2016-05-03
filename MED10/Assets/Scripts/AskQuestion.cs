using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class AskQuestion : MonoBehaviour {

	const int ButtonWidth = 256;
	const int ButtonHeight = 64;

	public string mMessage = "";
	public string mTitle = "Question: ";
	public string answerA = "";
	public string answerB = "";
	public string answerC = "";

	public string rightAnswer = "";

	public bool correct = false;

	private bool showAlert = false;
	private bool a_pressed = false;
	private bool b_pressed = false;
	private bool c_pressed = false;

	private static List<string> questions;

	public static int count = 0;
	public static int coins = 0;
	public bool isCoin = false;

	public bool done = false;

	private void loadFile() {
		string filePath = getFilePath();
		try {
			if (!File.Exists(filePath)) {
				//Debug.Log("No file to load!");
			} else {
				//Debug.Log("Reading file...");
				string[] array = File.ReadAllLines(filePath);
				questions = new List<string>(array);
			}
		} catch (System.Exception e) {
			Debug.Log(e);
		}
	}

	private void printList(List<string> list) {
		string line = "";
		string temp;
		foreach (string str in list) {
			temp = " " + str;
			line = line + temp;
		}
		Debug.Log("Printing list: " + line);

	}

	private string getFilePath() {
		//string date = System.DateTime.Now.ToString("dd");
		//string month = System.DateTime.Now.ToString("MM");
		//string year = System.DateTime.Now.ToString("yyyy");
		//Debug.Log(date + " " + month + " " + year);

		//string fileName = year+month+date+".txt";
		string fileName = ApplicationModel.currentLevel;
		Debug.Log("FileName: " + fileName);

		string filePath = Application.persistentDataPath + "/" + fileName + ".txt";
		Debug.Log("FilePath: " + filePath);
		return filePath;
	}

	void Start() {
		done = false;
		if (Random.Range(0, 2) == 0 && coins < 5 && this.tag !="Player") {
			coins++;
			mTitle = "";
			answerA = "";
			answerB = "";
			answerC = "";
			rightAnswer = "";
			isCoin = true;
			Debug.Log("I am a coin");
		} else {
			loadFile();
			mTitle = questions[0+count];
			answerA = questions[1+count];
			answerB = questions[2+count];
			answerC = questions[3+count];
			rightAnswer = questions[4+count];
			count+=5;
			Debug.Log("I am a question: " + mTitle);
		}
	}

	public void showQuestion() {
		showAlert = true;
		done = false;
		correct = false;
		Debug.Log("Questions: " + mTitle);
	}

	void OnGUI() {
		if (showAlert) {
			showDialog();
			Debug.Log(mTitle + " : " + answerA + " : " + answerB + " : " + answerC + " : " + rightAnswer);
			showAlert = false;
		}
		if (a_pressed) {
			Debug.Log("A Pressed");
			Debug.Log(answerA + " " + rightAnswer);
			if (rightAnswer == "A") {
				ApplicationModel.rightAnswers++;
				correct = true;
			} else {
				ApplicationModel.wrongAnswers++;
			}
			a_pressed = false;
			b_pressed = false;
			c_pressed = false;
			done = true;
			Debug.Log(done);
		}
		if (b_pressed) {
			Debug.Log("B Pressed");
			Debug.Log(answerB + " " + rightAnswer);
			if (rightAnswer == "B") {
				ApplicationModel.rightAnswers++;
				correct = true;
			} else {
				ApplicationModel.wrongAnswers++;
			}
			a_pressed = false;
			b_pressed = false;
			c_pressed = false;
			done = true;
			Debug.Log(done);
		}
		if (c_pressed) {
			Debug.Log("C Pressed");
			Debug.Log(answerC + " " + rightAnswer);
			if (rightAnswer == "C") {
				ApplicationModel.rightAnswers++;
				correct = true;
			} else {
				ApplicationModel.wrongAnswers++;
			}
			a_pressed = false;
			b_pressed = false;
			c_pressed = false;
			done = true;
			Debug.Log(done);
		}
	}

	#if UNITY_ANDROID

	private class PositiveButtonListner:AndroidJavaProxy {
		private AskQuestion mDialog;

		public PositiveButtonListner(AskQuestion d):base("android.content.DialogInterface$OnClickListener") {
			mDialog = d;
		}

		public void onClick(AndroidJavaObject obj, int value) {
			mDialog.a_pressed = true;
			mDialog.b_pressed = false;
			mDialog.c_pressed = false;
		}
	}

	private class NegativeButtonListner:AndroidJavaProxy {
		private AskQuestion mDialog;

		public NegativeButtonListner(AskQuestion d):base("android.content.DialogInterface$OnClickListener") {
			mDialog = d;
		}

		public void onClick(AndroidJavaObject obj, int value) {
			mDialog.a_pressed = false;
			mDialog.b_pressed = true;
			mDialog.c_pressed = false;
		}
	}

	private class NeutralButtonListener:AndroidJavaProxy {
		private AskQuestion mDialog;

		public NeutralButtonListener(AskQuestion d):base("android.content.DialogInterface$OnClickListener") {
			mDialog = d;
		}

		public void onClick(AndroidJavaObject obj, int value) {
			mDialog.a_pressed = false;
			mDialog.b_pressed = false;
			mDialog.c_pressed = true;
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

			alertDialogBuilder.Call<AndroidJavaObject>("setPositiveButton",answerA, new PositiveButtonListner(this));

			alertDialogBuilder.Call<AndroidJavaObject>("setNegativeButton",answerB,new NegativeButtonListner(this));

			alertDialogBuilder.Call<AndroidJavaObject>("setNeutralButton",answerC,new NeutralButtonListener(this));

			AndroidJavaObject dialog = alertDialogBuilder.Call<AndroidJavaObject>("create");
			dialog.Call("show");

			}));
			#endif
	}




}
