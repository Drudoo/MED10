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

	private bool up_isDown;
	private bool down_isDown;
	private bool left_isDown;
	private bool right_isDown;
	private bool jump_isDown;
	public AskQuestion askQuestion;
	private bool questionAsked = false;

	private Vector3 startingPosition;

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

	Camera viewCamera;
	float direction;

	private bool isDead = false;

	private Vector2 input;
	private string device = "";
	private d_pad buttonLeft;
	private d_pad buttonRight;
	private d_pad buttonJump;
	private float dirH = 0.0f;
	private float dirV = 0.0f;

	public float score = 0;
	public float qScore = 0;
	public Text coinsScore;
	public Text questionScore;


	void Start() {
		buttonLeft = GameObject.Find("Left").GetComponent<d_pad>();
		buttonRight = GameObject.Find("Right").GetComponent<d_pad>();
		buttonJump = GameObject.Find("Jump").GetComponent<d_pad>();

		coinsScore = GameObject.Find("coinsScore").GetComponent<Text>();

		questionScore = GameObject.Find("questionScore").GetComponent<Text>();

		controller = GetComponent<Controller2D> ();
		gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity * timeToJumpApex);
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);
		print ("Gravety: " + gravity + " Jump Velocity: " + maxJumpVelocity);

		viewCamera = Camera.main;
		direction = transform.localScale.x;

		startingPosition  = transform.position;

		#if UNITY_EDITOR
			device = "UNITY_EDITOR";
		#endif

		if (device == "") {
			#if UNITY_ANDROID
				device = "UNITY_ANDROID";
			#endif
		}
	}

	void Update() {
		left_isDown = buttonLeft.getButtonState ();
		right_isDown = buttonRight.getButtonState ();
		jump_isDown = buttonJump.getButtonState ();

		if (left_isDown) {
			dirH = -1.0f;
		} else if (right_isDown) {
			dirH = 1.0f;
		} else {
			dirH = 0.0f;
		}

		if (device == "UNITY_EDITOR") {
			input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		} else {
			input = new Vector2 (dirH, dirV);
		}

		int wallDirX = (controller.collisions.left) ? -1 : 1;

		bool wallSliding = false;

		float targetVelocityX = input.x * moveSpeed;
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


		Vector3 point = viewCamera.ScreenToWorldPoint (Input.mousePosition);
		Vector3 distance = point - transform.position;


		if (distance.x < 0) {
			faceDir = true;
			Debug.DrawLine (point, transform.position, Color.red);
		} else {
			faceDir = false;
			Debug.DrawLine (point, transform.position, Color.green);
		}

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

		velocity.y += gravity * Time.deltaTime;

		controller.Move (velocity * Time.deltaTime, input);

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		if (this.transform.position.y < 188 ) {
			isDead = true;
		}

		if (isDead) {
			this.transform.localPosition = startingPosition;
			if (!questionAsked) {
				if (device == "UNITY_ANDROID") {
					askQuestion.showQuestion();
				} else {
					Debug.Log(askQuestion.isCoin?"I am a coin":("Question: " + askQuestion.mTitle));
				}
				questionAsked = true;
			}
			isDead = false;
		}



	}

	void OnTriggerEnter2D(Collider2D Hit) {

		if (Hit.tag == "Enemy") {
			isDead = true;
		}

		if (controller.collisions.above && Hit.tag == "QuestionBox" && !Hit.gameObject.GetComponent<Box>().hit) {
			if (!Hit.gameObject.GetComponent<Box>().didHit) {
				Hit.gameObject.GetComponent<Box>().hit = true;
	 			if(Hit.gameObject.GetComponent<Box>().coins && Hit.gameObject.GetComponent<AskQuestion>().isCoin){
					score++;
				}
				qScore++;
				questionScore.text = qScore.ToString() + "/12";
				coinsScore.text = score.ToString();
				Hit.gameObject.GetComponent<Box>().didHit = true;
			}

		}
	}
}
