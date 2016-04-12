using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuizGame : MonoBehaviour {

	private InputField _questions;
	private InputField _answers;

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

		for (int i = 0; i < _valueQ; i++) {

		}
}

}
