using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Box : MonoBehaviour {

	public float maxJumpHeight = 6;
	public float minJumpHeight = 1;
	public float timeToJumpApex = 0.4f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;
	float moveSpeed = 6;
	float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	float velocityXSmoothing;
	Vector3 velocity;
	int wallDirX = 1;
	public float wallSlideSpeedMax = 3;
	public float wallStickTime = .25f;
	float timeToWallUnstick;

	Controller2D controller;

	[HideInInspector]
	public bool faceDir;

	//float direction;

	void Start() {
		controller = GetComponent<Controller2D>();

	}

	void Update() {

		if (controller.collisions.below) {
			Debug.Log("enemy box");
		}


	}

}
