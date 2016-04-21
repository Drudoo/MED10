using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Enemy : MonoBehaviour {

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
		gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
		//maxJumpVelocity = Mathf.Abs(gravity * timeToJumpApex);
		//minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);

		//direction = transform.localScale.x;
	}

	void Update() {


		if (controller.collisions.right || controller.collisions.left) {
			wallDirX*=-1;
		}

		bool wallSliding = false;

		Vector2 input = new Vector2(1.0f*wallDirX, 0.0f);
		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below?accelerationTimeGrounded:accelerationTimeAirborne));
		/*
		if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0) {
			wallSliding = true;
			if (velocity.y < -wallSlideSpeedMax) {
				velocity.y = -wallSlideSpeedMax;
			}

			if (timeToWallUnstick > 0) {
				velocityXSmoothing = 0;
				velocity.x = 0;

				if (input.x != wallDirX && input.x != 0) {
					timeToWallUnstick -= Time.deltaTime;
				} else {
					timeToWallUnstick = wallStickTime;
				}
			} else {
				timeToWallUnstick = wallStickTime;
			}
		}
		*/

		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime, input);
	}

}
