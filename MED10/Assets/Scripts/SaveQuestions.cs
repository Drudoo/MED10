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
	private Text _label;

	private int valueQ = 10;
	private int valueA = 3;

	private static List<string> questions = new List<string>();
	private static List<string> answerA = new List<string>();
	private static List<string> answerB = new List<string>();
	private static List<string> answerC = new List<string>();

	private static int count = 0;
	private GameObject label;
	private string[] objects = {"Question", "Save", "OptionA", "OptionB", "OptionC", "question_title"};

	private string device = "";
	private string fileName = "questions.txt";
	private string filePath;

	void Start() {
		filePath = Application.persistentDataPath + "/" + fileName;
		#if UNITY_EDITOR
			device = "UNITY_EDITOR";
		#elif UNITY_ANDROID
			device = "UNITY_ANDROID";
		#endif

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

			_question = question.GetComponent<InputField>();
			_A = A.GetComponent<InputField>();
			_B = B.GetComponent<InputField>();
			_C = C.GetComponent<InputField>();

			questions.Add(_question.text);
			answerA.Add(_A.text);
			answerB.Add(_B.text);
			answerC.Add(_C.text);

			_question.text = "";
			_A.text = "";
			_B.text = "";
			_C.text = "";
			count++;

			if (count == valueQ) {
				for (int i = 0; i < valueQ; i++) {
					Debug.Log(count + ":: "+ questions[i] + ": " + answerA[i] + " " + answerB[i] + " " + answerC[i]);
				}

				for (int i = 0; i < valueA+3; i++) {
					GameObject _object = GameObject.Find(objects[i]);
					_object.transform.localScale = new Vector3(0, 0, 0);
				}

				if (device == "UNITY_EDITOR") {
					saveEditor(questions);
				} else {
				}
			}
		}
	}

	private void saveAndroid() {

	}

	private void saveEditor(List<string> text) {
		try {
			if (!File.Exists(filePath)) {
				Debug.Log("File opened");
				Debug.Log("Writing...");
				File.WriteAllLines(filePath, text.ToArray());
				Debug.Log("Done!");
			} else {
				Debug.Log("File fileName" + " exists");
				//string[] levelsInfo = File.ReadAllLines(fileName);
			}
		} catch (System.Exception e) {
			Debug.Log(e);
		}
		Debug.Log(filePath);
	}
}
