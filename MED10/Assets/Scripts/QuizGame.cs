using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class QuizGame : MonoBehaviour {

	private InputField _questions;
	private InputField _answers;
	string[] objects = {"Question", "Save", "OptionA", "OptionB", "OptionC", "OptionD", "OptionE", "OptionF", "OptionG"};

	void Start() {
		for (int i = 0; i < 9; i++) {
			GameObject _object = GameObject.Find(objects[i]);
			_object.transform.localScale = new Vector3(0, 0, 0);
		}
	}

	public void Generate() {
		GameObject questions = GameObject.Find("NumberOfQuestions");
		GameObject answers = GameObject.Find("NumberOfAnwers");
		_questions = questions.GetComponent<InputField>();
		_answers = answers.GetComponent<InputField>();

		if (_questions.text!="" && _answers.text!="") {
			MakeTable(_questions,_answers);
		}

	}

	private void MakeTable(InputField _questions, InputField _answers) {
		int _valueQ = int.Parse(_questions.text);
		int _valueA = int.Parse(_answers.text);

		Debug.Log("Q: " + _valueQ + " A: " + _valueA);

		for (int i = 0; i < _valueA+2; i++) {
			GameObject _object = GameObject.Find(objects[i]);
			_object.transform.localScale = new Vector3(1, 1, 1);
		}

		for (int i = 0; i < _valueQ; i++) {
			inputQuestion();
		}
	}

	private void inputQuestion() {

	}

}
