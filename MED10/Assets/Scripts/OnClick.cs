using UnityEngine;
using System.Collections;

public class OnClick : MonoBehaviour {

    // Use this for initialization
    private bool PopUp;

		private string Info;

		private string username="Enter Username";
		private string password="";

		public void showWindow(string newInfo) {
			Info = newInfo;


			PopUp = true;
		}

		void OnGUI() {
			Rect rect = new Rect (1084/2-300/2,275, 300, 130);
			Rect close = new Rect (1084/2-300/2+280,275,20,20);
			Rect usr = new Rect(1084/2-300/2+50, 300, 200, 20);
			Rect pwd = new Rect(1084/2-300/2+50, 330, 200, 20);

			Rect save = new Rect(1084/2-300/2+100, 360, 100, 20);

			if (PopUp)
			{
					GUI.Box(rect, Info);
					if (GUI.Button(close,"X"))
					{
							PopUp = false;
					}
					string _username = GUI.TextField(usr, username, 25);
					username = _username;
					string _password = GUI.PasswordField(pwd, password,"*"[0], 25);
					password = _password;

					if(GUI.Button(save,"Save")) {
						Debug.Log("Username: " + username);
						Debug.Log("Password: " + password);
					}

			}
		}

}
