using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

public class OverAllScorePie : MonoBehaviour {

	private float[] values = new float[2];
	public Color[] wedgeColors;
	public Image wedgePrefab;
	public List<LineRenderer> _lines;
	List<string> names = new List<string>();
	List<int> score = new List<int>();
	List<int> rAnswers = new List<int>();
	List<int> wAnswers = new List<int>();
	List<int> coins = new List<int>();
	List<int> boxes = new List<int>();
	float scoreAvg=0;
	float rAnswersAvg=0;
	float wAnswersAvg = 0;
	public Text rNumbers;
	public Text wNumbers;
	float theRest=0;
	//public Text students;
	public Text highStudent;
	int highestScore = 0;

	public Text nameStudent;
	string nameUp;
//int studentNumbers;

	// Use this for initialization
	void Start () {

		_lines = new List<LineRenderer>();

		string[] lines = Regex.Split(ApplicationModel.assessment, "[\\n]");

		for (int i = 1; i < lines.Length-1; i++) {
		//	Debug.Log(lines[i]);
			string[] fields = Regex.Split(lines[i], "[\\t]");
			names.Add ((fields[0]));
			score.Add(System.Int32.Parse(fields[2].Remove(fields[2].Length - 1)));
			rAnswers.Add(System.Int32.Parse(fields[3]));
			wAnswers.Add(6-System.Int32.Parse(fields[3]));
			coins.Add(System.Int32.Parse(fields[4]));
			boxes.Add(System.Int32.Parse(fields[5]));
		//	studentNumbers++;
		}

		for (int i = 0; i < rAnswers.Count; i++) {
			for (int j = i+1; j < rAnswers.Count; j++) {
				if (rAnswers[i] < rAnswers[j]) {
					swap(rAnswers[i], rAnswers[j]);
					swapString(names[i], names[j]);
				}
			}
		}


		Debug.Log(rAnswers.Last());
		Debug.Log (names.Last());

		highestScore = rAnswers.Last();
		highStudent.text = highestScore.ToString ();
		nameUp = names.Last();
		nameStudent.text = "(" + nameUp.ToString () + ")" ;


		scoreAvg = System.Convert.ToSingle(score.Average());
		Debug.Log(scoreAvg);
		Debug.Log ("score averga" + scoreAvg);
		theRest = 100f - scoreAvg;
		Debug.Log ("score averga" + theRest);
		values [0] = scoreAvg;
		values [1] = theRest;

		//	values [2] = 10f;
		makeGraph ();
		rNumbers.text = scoreAvg.ToString() + " %";
		wNumbers.text = theRest.ToString();
		//students.text = studentNumbers.ToString ();

	}

	// Update is called once per frame
	void makeGraph () {
		float total = 0f;
		float zRotation = 0f;

		for (int i = 0; i < values.Length; i++) {
			total += values [i];
		}
		for (int i = 0; i < values.Length; i++) {
			Image newWedge =Instantiate (wedgePrefab) as Image;
			newWedge.transform.SetParent (transform, false);
			newWedge.color =wedgeColors[i];
			newWedge.fillAmount = values [i] / total;
			newWedge.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, zRotation));
			zRotation -= newWedge.fillAmount * 360f;
		}

	}

	void swap( int a, int b) {
		int temp;
		temp = a;
		a = b;
		b = temp;
	}

	void swapString( string a, string b) {
		string temp;
		temp = a;
		a = b;
		b = temp;
	}


}
