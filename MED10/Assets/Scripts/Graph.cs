using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

public class Graph : MonoBehaviour {

	List<int> score = new List<int>();
	List<int> rAnswers = new List<int>();
	List<int> coins = new List<int>();
	List<int> boxes = new List<int>();

	//Name, Game ID, Score, Right Answer, Coins, Boxes, Time

	void Start () {
		string[] lines = Regex.Split(ApplicationModel.assessment, "[\\n]");


		foreach (string _line in lines) {
			string[] fields = Regex.Split(_line, "[\\t]");
			Debug.Log(fields[2]);
			score.Add(System.Int32.Parse(fields[2]));
			rAnswers.Add(System.Int32.Parse(fields[3]));
			coins.Add(System.Int32.Parse(fields[4]));
			boxes.Add(System.Int32.Parse(fields[5]));

		}
	}

	void DrawLines() {
		int prev=0;
		foreach(int point in score) {
			GL.Begin(GL.LINES);
	        GL.Color(Color.red);
	        GL.Vertex3(0, prev, 1);
	        GL.Vertex3(0, point, 1);
	        GL.End();
			prev=point;
		}
	}

	void OnPostRender() {
		DrawLines();
	}


}
