using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	public float ScaleToDepress = 1f;
	public GameObject button;
	private Vector3 buttonStartPosition;
	public Controller2D player;

	public bool Activated = false;

	void Start () {
		buttonStartPosition = button.transform.localPosition;
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.tag == "Player") {
			DepressButton(col.transform.localScale.x);
		}
	}

	private void DepressButton(float scale) {
		if (scale >= ScaleToDepress && Vector3.Distance(button.transform.localPosition, buttonStartPosition) < 0.4f) {
			button.transform.Translate(0f,-1f*Time.deltaTime,0f);
		}

		if (Vector3.Distance(button.transform.localPosition,buttonStartPosition)> 0.3f) {
			Activated = true;
		}
	}
}
