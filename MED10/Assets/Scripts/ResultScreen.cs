using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour {

	// Use this for initialization
	public Text correctAnswers;
	public Text wrongAnswers;
	public Text Coins;
	public Text boxes;
	public Text Score;

	private float c;
	private float b;
	private float rA;
	private float wA;


	void Start () {

		rA = ApplicationModel.rightAnswers;
		wA = ApplicationModel.wrongAnswers;
		c = ApplicationModel.coins;

		boxes.text = ApplicationModel.boxes.ToString ();
		Coins.text = ApplicationModel.coins.ToString ();
		correctAnswers.text = ApplicationModel.rightAnswers.ToString ();
		wrongAnswers.text = ApplicationModel.wrongAnswers.ToString ();
		float temp = Mathf.Round (((rA-wA+c)/9*100));
		Score.text = temp.ToString() + "%";
		Debug.Log(temp);

		ApplicationModel.assessment+=(ApplicationModel.username + "\t" + ApplicationModel.currentLevel + "\t" + temp.ToString()+"%" + "\t" + System.DateTime.Now.ToString("yyyy-MM-ddTHH:mm:sszzz") + "\n");

	}
	// Update is called once per frame
	void Update () {


	}
}
