using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

	public float maxJumpHeight = 6;
	public float minJumpHeight = 1;
	public float timeToJumpApex = 0.4f;
	public float wind = -0.5f;
	public float mass = 1.0f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;
	float moveSpeed = 6;


	public Vector2 wallJumpClimb = new Vector2(7.5f,25.0f);
	public Vector2 wallJumpOff = new Vector2(8.5f,7.0f);
	public Vector2 wallLeap = new Vector2(18.0f,25.0f);

	public float wallSlideSpeedMax = 3;
	public float wallStickTime = .25f;
	float timeToWallUnstick;

	float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	bool inWater = false;

	Controller2D controller;

	[HideInInspector]
	public bool faceDir;
	float massX;
	float massY;
	float groundType;

	float cd = 1.05f;
	float pWater = 999.97f;//mass density of water kg/m 3
	float pAir = 1.293f;
	float area= 1.0f;//1 metre x 1 metre = 1 m 2
	float dragForceWaterX;
	float dragForceWaterY;
	float dragForceAirX;
	float dragForceAirY;

	Camera viewCamera;
	float direction;

	void Start() {

		controller = GetComponent<Controller2D> ();
		gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity * timeToJumpApex);
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);
		print ("Gravety: " + gravity + " Jump Velocity: " + maxJumpVelocity);

		viewCamera = Camera.main;
		direction = transform.localScale.x;

		dragForceWaterX = pWater*(velocity.x *velocity.x)*cd*area/2;
		dragForceWaterY = pWater*(velocity.y *velocity.y)*cd*area/2;
		dragForceAirX = pAir * (velocity.x * velocity.x) * cd * area / 2;
		dragForceAirY = pAir * (velocity.y * velocity.y) * cd * area / 2;

	}



	void Update() {

		//Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		Vector2 input = new Vector2 (CrossPlatformInputManager.GetAxisRaw("Horizontal"), CrossPlatformInputManager.GetAxisRaw("Vertical"));

		int wallDirX = (controller.collisions.left) ? -1 : 1;

		bool wallSliding = false;

		float targetVelocityX = input.x * moveSpeed*massX;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing , (controller.collisions.below?accelerationTimeGrounded:accelerationTimeAirborne));


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


		/*
		Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);
		Vector3 point = ray.GetPoint(
		Debug.DrawLine (ray.origin, transform.position, Color.green);

		controller.LookAt (ray);
		*/

		/*Ray ray = viewCamera.ScreenPointToRay (Input.mousePosition);
		Vector3 point = ray.origin;


		Vector3 targetPosition = new Vector3 (point.x,transform.position.y, point.z);
		Debug.Log (point);

		Debug.DrawLine(point,transform.position,Color.red);
		//Debug.DrawRay(ray.origin,ray.direction * 100,Color.red);
		transform.LookAt(point);
		*/
		Vector3 point = viewCamera.ScreenToWorldPoint (Input.mousePosition);
		Vector3 distance = point - transform.position;
		//bool faceLeft = false;
		//bool faceRight = true;
		if (distance.x < 0) {
			//faceLeft = true;
			//transform.LookAt (Vector3.up);
			//transform.localScale = new Vector2(-direction, transform.localScale.y);
			faceDir = true;
			Debug.DrawLine (point, transform.position, Color.red);
		} else {
			//faceRight = true;
			//transform.LookAt (Vector3.down);
			//transform.localScale = new Vector2(direction, transform.localScale.y);
			faceDir = false;
			Debug.DrawLine (point, transform.position, Color.green);
		}
		/*
		if (Input.GetKeyDown (KeyCode.A)) {
			transform.forward = new Vector3 (0f, 0f, -1f);
		} else if (Input.GetKeyDown (KeyCode.D)) {
			transform.forward = new Vector3 (0f, 0f, 1f);
		}
		*/

		massX = mass;
		massY = mass;


		//if (!controller.collisions.below) {
		//	velocity.x+=wind;
		//}


		if (Input.GetKeyDown (KeyCode.Space) || CrossPlatformInputManager.GetButton("Jump")) {
			if (wallSliding) {
				if (wallDirX == input.x) {
					velocity.x = -wallDirX * wallJumpClimb.x;
					velocity.y = wallJumpClimb.y;
				} else if (input.x == 0) {
					velocity.x = -wallDirX * wallJumpOff.x;
					velocity.y = wallJumpOff.y;
				} else {
					velocity.x = -wallDirX * wallLeap.x;
					velocity.y = wallLeap.y;
				}
			}

			if (controller.collisions.below) {
				velocity.y = maxJumpVelocity;
			}
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			if (velocity.y > minJumpVelocity) {
				velocity.y = minJumpVelocity;
			}
		}


		//Debug.Log (GetComponent<Rigidbody2D> ().mass);
		//float targetVelocityX = input.x * moveSpeed * groundType*massX;
		//velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below?accelerationTimeGrounded:accelerationTimeAirborne));

		//velocity.x = input.x * moveSpeed;


		//Debug.Log(input.x * moveSpeed * groundType*massX*Time.deltaTime + " " + input.x * moveSpeed * groundType*massX);
		//float targetVelocityX = input.x * moveSpeed*groundType*massX;



		velocity.y += gravity * Time.deltaTime*massY;

//		if (inWater) {
//			velocity.x = velocity.x * dragForceWaterX;
//			velocity.y = velocity.y * dragForceWaterY;
//		} else {
//			velocity.x = velocity.x * dragForceAirX;
//			velocity.y = velocity.y * dragForceAirY;
//		}

		//Debug.Log (velocity);

		controller.Move (velocity * Time.deltaTime, input);

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D Hit)
	{
		velocity.x = velocity.x * dragForceWaterX;
		velocity.y = velocity.y * dragForceWaterY;

		inWater = true;
	}

	void OnTriggerExit2D(Collider2D Hit)
	{
		velocity.x = velocity.x * dragForceAirX;
		velocity.y = velocity.y * dragForceAirY;
		inWater = false;
	}

}
