using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public float speed = 3.0f;

	private CharacterController controller;
	private GvrViewer gvrViewer;
	private Transform vrHead;

	private bool moveForeward;
	private bool moveBackward;
	private bool moveRight;
	private bool moveLeft;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		gvrViewer = transform.GetChild (0).GetComponent<GvrViewer> ();
		vrHead = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 forward = vrHead.TransformDirection (Vector3.forward);
		Vector3 right = vrHead.TransformDirection (Vector3.right);

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (moveVertical > 0) {
			moveForeward = true;
		} else {
			moveForeward = false;
		}

		if (moveHorizontal > 0) {
			moveRight = true;
		} else {
			moveRight = false;
		}

		if (moveVertical < 0) {
			moveBackward = true;
		} else {
			moveBackward = false;
		}

		if (moveHorizontal < 0) {
			moveLeft = true;
		} else {
			moveLeft = false;
		}

		if(moveForeward == true){
			controller.SimpleMove (forward*speed);
		}else if(moveBackward == true){
			controller.SimpleMove (-forward*speed);
		}

		if(moveRight == true){
			controller.SimpleMove (right*speed);
		}else if(moveLeft == true){
			controller.SimpleMove (-right*speed);
		}
	
	}
}
