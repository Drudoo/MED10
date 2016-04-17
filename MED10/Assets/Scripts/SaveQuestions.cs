using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class SaveQuestions : MonoBehaviour {

	public QuizGame quizGame;
	private InputField _question;
	private InputField _A;
	private InputField _B;
	private InputField _C;

	private static List<string> questions = new List<string>();
	private static List<string> answerA = new List<string>();
	private static List<string> answerB = new List<string>();
	private static List<string> answerC = new List<string>();

	private static int count = 0;

	void Start() {

	}

	public void Save() {

		if (count < quizGame._valueQ) {
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
		}
		
		if (count == quizGame._valueQ) {
			for (int i = 0; i < quizGame._valueQ; i++) {
				Debug.Log(questions[i] + ": " + answerA[i] + " " + answerB[i] + " " + answerC[i]);
			}
		}

	}
}
