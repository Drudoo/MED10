using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlertPopup : MonoBehaviour {

	const int ButtonWidth = 256;
	const int ButtonHeight = 64;

	private InputField _questions;
	private InputField _answers;

	public string mMessage = "Please enter username and passwod";
	public string mTitle = "Sign Up";

	public string answerA = "";
	public string answerB = "";

	private bool mSavePressed = false;
	private bool mCancelPressed = false;

	private bool showSignUp = false;

	public void alertPopup() {
		showSignUp = true;
	}

	void OnGUI() {
		if (showSignUp) {
			showDialog();
			showSignUp = false;
		}

		if (mSavePressed) {
			Debug.Log("SAVED");
			mSavePressed = false;
		}

		if (mCancelPressed) {
			Debug.Log("CANCEL");
			mCancelPressed = false;
		}
	}

	#if UNITY_ANDROID

	private class PositiveButtonListner:AndroidJavaProxy {
		private AlertPopup mDialog;

		public PositiveButtonListner(AlertPopup d):base("android.content.DialogInterface$OnClickListener") {
			mDialog = d;
		}

		public void onClick(AndroidJavaObject obj, int value) {
			mDialog.mSavePressed = true;
			mDialog.mCancelPressed = false;
		}
	}

	private class NegativeButtonListner:AndroidJavaProxy {
		private AlertPopup mDialog;

		public NegativeButtonListner(AlertPopup d):base("android.content.DialogInterface$OnClickListener") {
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

			if(answerA != "") {
				alertDialogBuilder.Call<AndroidJavaObject>("setPositiveButton",answerA, new PositiveButtonListner(this));
			}
			alertDialogBuilder.Call<AndroidJavaObject>("setNegativeButton",answerB,new NegativeButtonListner(this));

			AndroidJavaObject dialog = alertDialogBuilder.Call<AndroidJavaObject>("create");
			dialog.Call("show");

			}));
			#endif
	}

}
