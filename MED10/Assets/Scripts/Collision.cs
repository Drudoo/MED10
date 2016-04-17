using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Script start");
	}

	// Update is called once per frame
	void Update () {

	}

	public void OnTriggerStay2D(Collider2D col) {
		Debug.Log(col);
	}

	public void OnTriggerEnter2D(Collider2D col) {
		Debug.Log(col);
	}
	public void OnTriggerExit2D(Collider2D col) {
		Debug.Log(col);
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log("ehh something work");
	}

}
