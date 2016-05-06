using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Graph : MonoBehaviour {

	List<int> score = new List<int>();
	List<int> rAnswers = new List<int>();
	List<int> coins = new List<int>();
	List<int> boxes = new List<int>();
float scoreAvg=0;
float rAnswersAvg=0;
	private bool showGraph = false;

	//Name, Game ID, Score, Right Answer, Coins, Boxes, Time

	public Color c1 = Color.yellow;
	public Color c2 = Color.red;

	public List<LineRenderer> _lines;
	Vector3[] VERTICES;
	Vector3[] VERTICES_Right;
	private bool createLine(Vector3[] vertices) {
		LineRenderer lRend = new GameObject().AddComponent<LineRenderer>() as LineRenderer;
		_lines.Add(lRend);
		lRend.material = new Material(Shader.Find("Unlit/Color"));
		lRend.SetColors(c1,c2);
		lRend.SetWidth(0.5f, 0.5f);
		lRend.SetVertexCount(vertices.Length);
		for (int i=0; i<vertices.Length; i++) {
			lRend.SetPosition(i, vertices[i]);
		}
		return true;
	}

	void OnGUI() {
		if (GUI.Button (new Rect(10,10,100,20), "Show")) {
			createLine(VERTICES);
			createLine(VERTICES_Right);

			showGraph = true;
		}

		if (showGraph) {
			GUI.Label(new Rect(Screen.width/2-15,Screen.height/2+50, 100,20), "Score");
			GUI.Label(new Rect(Screen.width/2-15,Screen.height/2-scoreAvg*4, 100,20), scoreAvg.ToString());

			GUI.Label(new Rect(Screen.width/2+30,Screen.height/2+50, 100,20), "Score");
			GUI.Label(new Rect(Screen.width/2+30,Screen.height/2-rAnswersAvg*10, 100,20), rAnswersAvg.ToString());
		}

	}

	void Start () {

		_lines = new List<LineRenderer>();



		string[] lines = Regex.Split(ApplicationModel.assessment, "[\\n]");

		//LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		//lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		//lineRenderer.SetWidth(0.5f,0.5f);
		//lineRenderer.SetColors(c1,c2);

		for (int i = 1; i < lines.Length-1; i++) {
			Debug.Log(lines[i]);
			string[] fields = Regex.Split(lines[i], "[\\t]");
			score.Add(System.Int32.Parse(fields[2].Remove(fields[2].Length - 1)));
			rAnswers.Add(System.Int32.Parse(fields[3]));
			coins.Add(System.Int32.Parse(fields[4]));
			boxes.Add(System.Int32.Parse(fields[5]));
		}
		scoreAvg = System.Convert.ToSingle(score.Average());
		Debug.Log(scoreAvg);
		rAnswersAvg = System.Convert.ToSingle(rAnswers.Average());
		Debug.Log(rAnswersAvg);
		float coinsAvg = System.Convert.ToSingle(coins.Average());
		Debug.Log(coinsAvg);
		float boxesAvg = System.Convert.ToSingle(boxes.Average());
		Debug.Log(boxesAvg);

		float scale = 1.0f;

		VERTICES = new Vector3[2] {new Vector3(0,0,0), new Vector3(0,scoreAvg*scale,0)};


		VERTICES_Right = new Vector3[2] {new Vector3(1,0,0), new Vector3(1,rAnswersAvg,0)};

		/*
		lineRenderer.SetPosition(0, new Vector3(0, 0, 0));
		lineRenderer.SetPosition(1, new Vector3(0, System.Convert.ToSingle(scoreAvg)*0.05f, 0));


		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
		lineRenderer.SetWidth(0.5f,0.5f);
		lineRenderer.SetColors(c1,c2);

		lineRenderer.SetPosition(0, new Vector3(1, 0, 0));
		lineRenderer.SetPosition(1, new Vector3(1, System.Convert.ToSingle(rAnswersAvg)*0.05f, 0));

		*/
	}
}
