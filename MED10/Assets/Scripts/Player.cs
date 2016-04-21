using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	//public var Texture2D newTexture;
	public GameObject questionBox;

	public Vector3 startingPosition= new Vector3(38,216,0);


	private bool up_isDown;
	private bool down_isDown;
	private bool left_isDown;
	private bool right_isDown;
	private bool jump_isDown;

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

	public Button _left;

	private Vector2 input;

	private d_pad buttonUp;
	private d_pad buttonDown;
	private d_pad buttonLeft;
	private d_pad buttonRight;
	private d_pad buttonJump;
	private float dirH = 0.0f;
	private float dirV = 0.0f;

	void Start() {

		buttonUp = GameObject.Find("Up").GetComponent<d_pad>();
		buttonDown = GameObject.Find("Down").GetComponent<d_pad>();
		buttonLeft = GameObject.Find("Left").GetComponent<d_pad>();
		buttonRight = GameObject.Find("Right").GetComponent<d_pad>();
		buttonJump = GameObject.Find("Jump").GetComponent<d_pad>();

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

		up_isDown = buttonUp.getButtonState ();
		down_isDown = buttonDown.getButtonState ();
		left_isDown = buttonLeft.getButtonState ();
		right_isDown = buttonRight.getButtonState ();
		jump_isDown = buttonJump.getButtonState ();

		if (left_isDown) {
			dirH = -1.0f;
			//Debug.Log("left");
		} else if (right_isDown) {
			dirH = 1.0f;
			//Debug.Log("right");
		} else {
			dirH = 0.0f;
		}

		if (down_isDown) {
			dirV = -1.0f;
		} else {
			dirV = 0.0f;
		}

/*
		if (Input.touches.Length <= 0) {

		} else {
			for (int i=0; i < Input.touchCount; i++) {
				if (_left.HitTest(Input.GetTouch(i).position)){
					if (Input.GetTouch(i).phase == TouchPhase.Began) {
						Debug.Log("left");
					}
				}
			}
		}
*/

		#if UNITY_EDITOR
			input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
			//Debug.Log("EDITOR");
		#elif UNITY_ANDROID
			input = new Vector2 (dirH, dirV);
			//Debug.Log("ANDROID");
		#endif
		//Debug.Log(input);

		//Vector2 input = new Vector2 (CrossPlatformInputManager.GetAxisRaw("Horizontal"), CrossPlatformInputManager.GetAxisRaw("Vertical"));

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

		#if UNITY_EDITOR
		if (Input.GetKeyDown (KeyCode.Space)) {
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
		#elif UNITY_ANDROID
		//Debug.Log("ANDROID!");
		if (jump_isDown) {
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

		if (!jump_isDown) {
			if (velocity.y > minJumpVelocity) {
				velocity.y = minJumpVelocity;
			}
		}
		#endif

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

		if (this.transform.position.y < 188 ) {
			
			this.transform.localPosition = startingPosition;
			Debug.Log("dead");}

	}

	void OnTriggerEnter2D(Collider2D coll)
	{

		if (controller.collisions.above && coll.gameObject.tag == "QuestionBox") {
			Debug.Log ("collided player");
			//question

		}
	}

	void OnTriggerExit2D(Collider2D Hit)
	{
		velocity.x = velocity.x * dragForceAirX;
		velocity.y = velocity.y * dragForceAirY;
		inWater = false;


	}

	/*void onCollisionEnter(Collision col){
		if (col.gameObject.name == "QuestionBox") {
			Debug.Log("collided player");
		}


	}*/

	/*void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "QuestionBox")
			Debug.Log("collided player");

	}*/

	/*void OnTriggerEnter2D(Collider2D coll) {
	if (controller.collisions.below && coll.gameObject.tag == "QuestionBox"){
		Debug.Log("collided player");
	}

}*/
}
