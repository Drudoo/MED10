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
        static float WIDTH = Screen.width/2;
        static float HEIGHT = Screen.height/2;
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

            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,new Vector3(Screen.width / WIDTH, Screen.height / HEIGHT, 1));


			Rect rect = new Rect (300,200, 325, 200);
			Rect close = new Rect (300+275,200,50,50);
			Rect usr = new Rect(300+50, 200+25, 200, 50);
			Rect pwd = new Rect(300+50, 200+75, 200, 50);

			Rect save = new Rect(300+100, 200+125, 100, 20);

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
                        ApplicationModel.username = username;
						_eduB.interactable = true;
						_stuB.interactable = true;
						PopUp = false;
					}

			}
		}

}
