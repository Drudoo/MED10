using UnityEngine;
using System.Collections;


public class BoxHit : MonoBehaviour {
		//public GameObject Player;
	Controller2D controller;
	public Collider2D collider;
	int wallDirX = 1;

	void Start(){
		controller = GetComponent<Controller2D>();

	}

	void Update() {

		/*if (collider.gameObject.tag == "QuestionBox") {
			Debug.Log("WTF");
		}*/

		if (controller.collisions.above)
			//&& coll.gameObject.tag == "QuestionBox"
			Debug.Log("WTF");

	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (controller.collisions.below)
			//&& coll.gameObject.tag == "QuestionBox"
			Debug.Log("WTF");

		if (coll.gameObject.tag == "QuestionBox") {
			Debug.Log("collided player");
		}

	}

}
