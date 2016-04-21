using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuizGame : MonoBehaviour {

	private InputField _questions;
	private InputField _answers;

	[HideInInspector]
	public int _valueQ = 10;
	[HideInInspector]
	public int _valueA = 3;

	string[] objects = {"Question", "Save", "OptionA", "OptionB", "OptionC", "OptionD", "OptionE", "OptionF", "OptionG"};

	void Start() {
		//#if UNITY_EDITOR

		//#elif
		string[] hide = {"MakeGame", "Print"};
		for (int i = 0; i < hide.Length; i++) {
			GameObject _object = GameObject.Find(hide[i]);
			_object.transform.localScale = new Vector3(0, 0, 0);
		}
		//#endif

	}

	public void Generate() {
		_valueQ = 10;
		_valueA = 3;

		_questions.text = "";
		_answers.text = "";

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
