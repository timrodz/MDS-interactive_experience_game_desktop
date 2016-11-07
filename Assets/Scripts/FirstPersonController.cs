using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {
	
	[Range(30f, 70f)]
	public float fieldOfView = 45f;

	// Movement //
	[Range(4.0f, 8.0f)]
	public float walkSpeed = 6.0f;

	private float
	initialSpeed,
	maxSpeed;

	// Camera //
	[Range(3.0f, 6.0f)]
	public float mouseSensitivityX;

	[Range(3.0f, 6.0f)]
	public float mouseSensitivityY;

	// the amount of rotation that should be added to the camera
	private float verticalLookRotation;

	// Object members //
	CharacterController controller;

	private float gravity = 20.0f;
	private Vector3 moveDirection = Vector3.zero;

	// Methods //

	void Awake() {

//		body = GetComponent<Rigidbody>();
		controller = GetComponent<CharacterController>();

	}

	void Start() {
		
		initialSpeed = walkSpeed;
		maxSpeed = walkSpeed + 1;

	}
	
	// Update is called once per frame
	void Update() {

		if (controller.isGrounded) {

			if (Input.GetKey(KeyCode.LeftShift)) {
				walkSpeed = maxSpeed;
			}
			else {
				walkSpeed = initialSpeed;
			}

			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= (walkSpeed / 2);

		}

		// Rotate the player around the x axis
		transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivityX);
		
		// Rotate the camera around the y axis (vertical looking)
		verticalLookRotation += Input.GetAxis("Mouse Y") * mouseSensitivityY;

		// Clamp it so it doens't scroll past normal values
		verticalLookRotation = Mathf.Clamp(verticalLookRotation, -fieldOfView, fieldOfView);

		// Apply the rotation value to the left vector (positive y)
		Camera.main.transform.localEulerAngles = Vector3.left * verticalLookRotation;

		// Apply gravity and move the character controller
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

	}

}