using UnityEngine;
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

	public void Table(string _scores) {
		scores = _scores;
		showTable = true;
	}

	void OnGUI() {

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
			scrollPosition = GUILayout.BeginScrollView(scrollPosition,GUILayout.Width(Screen.width-200),GUILayout.Height(Screen.height-400));
		    foreach (string _line in lines) {
		        string[] fields = Regex.Split(_line, "[\\t]");

				if (fields.Length >= 4) {

					GUILayout.BeginHorizontal("Box");
					GUILayout.Label(fields[0], GUILayout.Width(w1));
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
