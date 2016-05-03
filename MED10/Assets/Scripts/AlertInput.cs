using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlertInput : MonoBehaviour {

	const int ButtonWidth = 256;
	const int ButtonHeight = 64;

	public string mMessage = "Please Enter Game Name";
	public string mTitle = "Game name";
	public string answerA = "Save";
	public string answerB = "Discard Game";
	public string mText = "";

	private bool mSavePressed = false;
	private bool mCancelPressed = false;

	private bool showAlert = false;
	AndroidJavaObject input;

	public void alertPopup() {
		showAlert = true;
	}

	void OnGUI() {
		if (showAlert) {
			showDialog();
			showAlert = false;
		}

		if (mSavePressed) {
			Debug.Log("SAVED");
			Application.LoadLevel("Game");
			mSavePressed = false;
		}

		if (mCancelPressed) {
			Debug.Log("CANCEL");
			Application.LoadLevel("Game");
			mCancelPressed = false;
		}
	}

	#if UNITY_ANDROID

	private class PositiveButtonListner:AndroidJavaProxy {
		private AlertInput mDialog;

		public PositiveButtonListner(AlertInput d):base("android.content.DialogInterface$OnClickListener") {
			mDialog = d;
		}

		public void onClick(AndroidJavaObject obj, int value) {
			mDialog.mSavePressed = true;
			mDialog.mCancelPressed = false;
			Debug.Log("OUTPUT:: " + mDialog.input.Get<string>("getText"));
		}
	}

	private class NegativeButtonListner:AndroidJavaProxy {
		private AlertInput mDialog;

		public NegativeButtonListner(AlertInput d):base("android.content.DialogInterface$OnClickListener") {
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

			input = new AndroidJavaObject("android/widget/EditText", activity);

			alertDialogBuilder.Call<AndroidJavaObject>("setPositiveButton",answerA, new PositiveButtonListner(this));

			alertDialogBuilder.Call<AndroidJavaObject>("setView", input);

			alertDialogBuilder.Call<AndroidJavaObject>("setNegativeButton",answerB,new NegativeButtonListner(this));

			AndroidJavaObject dialog = alertDialogBuilder.Call<AndroidJavaObject>("create");
			dialog.Call("show");

		}));
		#endif
	}

}
