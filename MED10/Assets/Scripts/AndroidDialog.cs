using UnityEngine;
using System.Collections;

public class AndroidDialog : MonoBehaviour {

 const int ButtonWidth = 256;
 const int ButtonHeight = 64;

 private string mMessage = "See My Android Dialog";

 private bool mYesPressed = false;
 private bool mNoPressed = false;

 // Use this for initialization
 void Start () {
 }

 // Update is called once per frame
 void Update () {
 }

 void OnGUI() {

  if (GUI.Button(new Rect((Screen.width-ButtonWidth)/2, (Screen.height-ButtonHeight)/2,
                           ButtonWidth, ButtonHeight),
                 "ShowDialog")) {
   showDialog();
  }

  if (mYesPressed) {
   GUI.Label(new Rect((Screen.width-ButtonWidth)/2, (Screen.height-ButtonHeight)/2 + 2 * ButtonHeight,
                      ButtonWidth, ButtonHeight), "You Pressed Yes");
                      Debug.Log("YESSSSSS");
  }

  if (mNoPressed) {
   GUI.Label(new Rect((Screen.width-ButtonWidth)/2, (Screen.height-ButtonHeight)/2 + 2 * ButtonHeight,
                      ButtonWidth, ButtonHeight), "You Pressed No");
                      Debug.Log("NOOOOO");
  }
 }

 // Lets put our android specific code under the macro UNITY_ANDROID
#if UNITY_ANDROID
 // Lets create some listners.
 // These listners will be passed to android

 // Create the postive action listner class
 // It has to be derived from the AndroidJavaProxy class
 // Make the methods as same as that of DialogInterface.OnClickListener
 private class PositiveButtonListner : AndroidJavaProxy {
  private AndroidDialog mDialog;

  public PositiveButtonListner(AndroidDialog d)
   : base("android.content.DialogInterface$OnClickListener") {
   mDialog = d;
  }

  public void onClick(AndroidJavaObject obj, int value ) {
   mDialog.mYesPressed = true;
   mDialog.mNoPressed = false;
  }
 }

 // Create the postive action listner class
 // It has to be derived from the AndroidJavaProxy class
 // Make the methods as same as that of DialogInterface.OnClickListener
 private class NegativeButtonListner : AndroidJavaProxy {
  private AndroidDialog mDialog;

  public NegativeButtonListner(AndroidDialog d)
  : base("android.content.DialogInterface$OnClickListener") {
   mDialog = d;
  }

  public void onClick(AndroidJavaObject obj, int value ) {
   mDialog.mYesPressed = false;
   mDialog.mNoPressed = true;
  }
 }


#endif

 private void showDialog() {

#if UNITY_ANDROID
  // Obtain activity
  AndroidJavaClass unityPlayer = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
  AndroidJavaObject activity = unityPlayer.GetStatic< AndroidJavaObject>  ("currentActivity");

  // Lets execute the code in the UI thread
  activity.Call("runOnUiThread", new AndroidJavaRunnable(() =>  {

   // Create an AlertDialog.Builder object
   AndroidJavaObject alertDialogBuilder = new AndroidJavaObject("android/app/AlertDialog$Builder", activity);

   // Call setMessage on the builder
   alertDialogBuilder.Call< AndroidJavaObject> ("setMessage", mMessage);

   // Call setCancelable on the builder
   alertDialogBuilder.Call< AndroidJavaObject> ("setCancelable", true);

   // Call setPositiveButton and set the message along with the listner
   // Listner is a proxy class
   alertDialogBuilder.Call< AndroidJavaObject> ("setPositiveButton", "Yes", new PositiveButtonListner(this));

   // Call setPositiveButton and set the message along with the listner
   // Listner is a proxy class
   alertDialogBuilder.Call< AndroidJavaObject> ("setNegativeButton", "No", new NegativeButtonListner(this));

   // Finally get the dialog instance and show it
   AndroidJavaObject dialog = alertDialogBuilder.Call< AndroidJavaObject> ("create");
   dialog.Call("show");
  }));
#endif

 }
 }
