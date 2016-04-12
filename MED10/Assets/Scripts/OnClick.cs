using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnClick : MonoBehaviour {

    // Use this for initialization
    private bool PopUp;

		private string Info;

		private string username;
		private string password;

		private Button _eduB;
		private Button _stuB;

        private float h,w;

        void Start() {
            h = Screen.height;
            w = Screen.width;
        }

		public void showWindow(string newInfo) {
			Info = newInfo;
			username="Enter Username";
			password="";
			GameObject eduB = GameObject.Find("Educator");
			_eduB = eduB.GetComponent<Button>();
			GameObject stuB = GameObject.Find("Student");
			_stuB = stuB.GetComponent<Button>();
			PopUp = true;
		}

		void OnGUI() {

			Rect rect = new Rect (w/2-300/2,h/2, 300, 130);
			Rect close = new Rect (w/2-300/2+280,h/2,20,20);
			Rect usr = new Rect(w/2-300/2+50, h/2+25, 200, 20);
			Rect pwd = new Rect(w/2-300/2+50, h/2+55, 200, 20);

			Rect save = new Rect(w/2-300/2+100, h/2+85, 100, 20);

			if (PopUp) {
					_eduB.interactable = false;
					_stuB.interactable = false;
					GUI.Box(rect, Info);
					if (GUI.Button(close,"X")) {
							_eduB.interactable = true;
							_stuB.interactable = true;

							PopUp = false;
					}
					string _username = GUI.TextField(usr, username, 25);
					username = _username;
					string _password = GUI.PasswordField(pwd, password,"*"[0], 25);
					password = _password;

					if(GUI.Button(save,"Save")) {
						Debug.Log("Username: " + username);
						Debug.Log("Password: " + password);
						_eduB.interactable = true;
						_stuB.interactable = true;
						PopUp = false;
					}

			}
		}

}
