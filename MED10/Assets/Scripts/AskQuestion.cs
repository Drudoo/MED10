using UnityEngine;
using System.Collections;

public class AskQuestion : MonoBehaviour {

	const int ButtonWidth = 256;
	const int ButtonHeight = 64;

	public string mMessage = "What is biggest?";
	public string mTitle = "Question: ";
	public string answerA = "Mouse";
	public string answerB = "Elephant";
	public string answerC = "Dog";

	public string rightAnswer = "Elephant";

	public bool correct = false;

	private bool showAlert = false;
	private bool a_pressed = false;
	private bool b_pressed = false;
	private bool c_pressed = false;



	public void showQuestion() {
		showAlert = true;
	}

	void OnGUI() {
		if (showAlert) {
			showDialog();
			showAlert = false;
		}
		if (a_pressed) {
			Debug.Log("A Pressed");
			Debug.Log(answerA + " " + rightAnswer);
			if (answerA == rightAnswer) {
				correct = true;
			}
			a_pressed = false;
		}
		if (b_pressed) {
			Debug.Log("B Pressed");
			Debug.Log(answerB + " " + rightAnswer);
			if (answerB == rightAnswer) {
				correct = true;
			}
			b_pressed = false;
		}
		if (c_pressed) {
			Debug.Log("C Pressed");
			Debug.Log(answerC + " " + rightAnswer);
			if (answerC == rightAnswer) {
				correct = true;
			}
			c_pressed = false;
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

			alertDialogBuilder.Call<AndroidJavaObject>("setNeutralButton",answerC,new NegativeButtonListner(this));

			AndroidJavaObject dialog = alertDialogBuilder.Call<AndroidJavaObject>("create");
			dialog.Call("show");

			}));
			#endif
	}




}
