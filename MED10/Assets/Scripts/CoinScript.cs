using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

	public float speed = 4.0f;
	float timeForCoin = 5.5f;
	Vector3 v;
	public bool hit = false;

	// Use this for initialization
	void Start () {
		
		Rigidbody2D rigidbody = GetComponent <Rigidbody2D>();

		//timeForCoin = 0.2f;

		v = rigidbody.velocity;
		v.y = speed;
		rigidbody.velocity = v;

		//rigidbody.velocity.y = speed;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		v.y = speed;
		Rotate ();
		timeForCoin -= Time.deltaTime;
		if (timeForCoin < 0) {
			Destroy (gameObject);
		}
	

	}

	void Rotate(){
		Quaternion rotationCoin = Quaternion.AngleAxis (90, Vector3.up);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotationCoin, 0.05f);
	}
}
