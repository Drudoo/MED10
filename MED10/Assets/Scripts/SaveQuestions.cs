using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class SaveQuestions : MonoBehaviour {

	private InputField _question;
	private InputField _A;
	private InputField _B;
	private InputField _C;
	private Toggle _tA;
	private Toggle _tB;
	private Toggle _tC;
	private Text _label;

	private int valueQ = 10;
	private int valueA = 3;

	private static List<string> questions = new List<string>();
	private static List<string> answerA = new List<string>();
	private static List<string> answerB = new List<string>();
	private static List<string> answerC = new List<string>();
	private static List<string> correct = new List<string>();
	private static int count = 0;
	private GameObject label;
	private string[] objects = {"Question", "Save", "OptionA", "OptionB", "OptionC", "question_title"};

	private string device = "";
	private string fileName = "questions.txt";
	private string filePath;

	private static int uniqueID = 0;

	void Start() {
		#if UNITY_EDITOR
			device = "UNITY_EDITOR";
		#elif UNITY_ANDROID
			device = "UNITY_ANDROID";
		#endif

		string date = System.DateTime.Now.ToString("dd");
		string month = System.DateTime.Now.ToString("MM");
		string year = System.DateTime.Now.ToString("yyyy");
		//Debug.Log(date + " " + month + " " + year);
		uniqueID = int.Parse(date)+int.Parse(month)+int.Parse(year);
		fileName = year+month+date+".txt";
		//Debug.Log(uniqueID);
		filePath = Application.persistentDataPath + "/" + fileName;

		Debug.Log(valueQ + " " + valueA);
		label = GameObject.Find("question_title");
		_label = label.GetComponent<Text>();
		_label.text = "Enter Question " + (count+1) + " of " + valueQ;

	}

	public void Save() {

		if (count < valueQ) {
			_label.text = "Enter Question " + (count+2) + " of " + valueQ;
			GameObject question = GameObject.Find("Question");
			GameObject A = GameObject.Find("OptionA");
			GameObject B = GameObject.Find("OptionB");
			GameObject C = GameObject.Find("OptionC");
			GameObject tA = GameObject.Find("ToggleA");
			GameObject tB = GameObject.Find("ToggleB");
			GameObject tC = GameObject.Find("ToggleC");

			_question = question.GetComponent<InputField>();
			_A = A.GetComponent<InputField>();
			_B = B.GetComponent<InputField>();
			_C = C.GetComponent<InputField>();
			_tA = tA.GetComponent<Toggle>();
			_tB = tB.GetComponent<Toggle>();
			_tC = tC.GetComponent<Toggle>();

			Debug.Log(_tA.isOn.ToString() + _tB.isOn.ToString() + _tC.isOn.ToString());

			questions.Add(_question.text);
			answerA.Add(_A.text);
			answerB.Add(_B.text);
			answerC.Add(_C.text);
			if (_tA.isOn) {
				correct.Add("A");
			} else if (_tB.isOn) {
				correct.Add("B");
			} else if (_tC.isOn) {
				correct.Add("C");
			} else {
				correct.Add("0");
			}

			_question.text = "";
			_A.text = "";
			_B.text = "";
			_C.text = "";
			_tA.isOn = false;
			_tB.isOn = false;
			_tC.isOn = false;
			count++;

			if (count == valueQ) {
				for (int i = 0; i < valueQ; i++) {
					Debug.Log(questions[i] + ": " + answerA[i] + " " + answerB[i] + " " + answerC[i] + " : " + correct[i]);
				}

				for (int i = 0; i < valueA+3; i++) {
					GameObject _object = GameObject.Find(objects[i]);
					_object.transform.localScale = new Vector3(0, 0, 0);
				}

				count = 0;

				printList(questions);
				printList(answerA);
				printList(answerB);
				printList(answerC);
				printList(correct);

				deleteFile();
				saveEditor(questions,answerA,answerB,answerC, correct);
			}
		}
	}

	private void saveAndroid() {

	}

	public void printFile() {
		string[] temp = File.ReadAllLines(filePath);
		List<string> previousText = new List<string>(temp);
		printList(previousText);
	}

	private void saveEditor(List<string> q, List<string> a, List<string> b, List<string> c, List<string> correct) {
		try {
			if (!File.Exists(filePath)) {
				Debug.Log("File opened");
				Debug.Log("Writing...");
				List<string> text = new List<string>();

				for (int i = 0; i < q.Count; i++) {
					text.Add(q[i]);
					text.Add(a[i]);
					text.Add(b[i]);
					text.Add(c[i]);
					text.Add(correct[i]);
				}
				File.WriteAllLines(filePath, text.ToArray());
				Debug.Log("Done!");
			} else {
				Debug.Log("File fileName" + " exists");
			}
		} catch (System.Exception e) {
			Debug.Log(e);
		}
	}

	private void printList(List<string> list) {
		string line = "";
		string temp;
		foreach (string str in list) {
			temp = " " + str;
			line = line + temp;
		}
		Debug.Log("Printing list: " + line);
	}

	private void deleteFile() {
		if (File.Exists(filePath)) {
			Debug.Log("Deleting File...");
			File.Delete(filePath);
		} else {
			Debug.Log("File cannot be deleted.");
		}
	}
}
