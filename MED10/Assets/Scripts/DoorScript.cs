using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public OpenDoor button;
	public float OpenAmount = 5.0f;
	private Vector3 startPosition;

	void Start () {
		startPosition = transform.position;
	}

	void Update () {
		if (button != null && button.Activated && Vector3.Distance(startPosition,transform.position) < OpenAmount) {
			transform.Translate(0f,10f*Time.deltaTime,0f);
		}
	}
}
