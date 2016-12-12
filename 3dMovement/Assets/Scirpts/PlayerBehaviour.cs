using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour {

	public GameObject bala;
	public Text text;

	/*
	public Transform vrCamera;
	public CharacterController cc;
	*/

	public float speed = 3.0f;

	private CharacterController controller;

	private GvrViewer gvrViewer;

	private Transform vrHead;

	public bool moveForeward;
	public bool moveBackward;
	public bool moveRight;
	public bool moveLeft;

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

		//text.text = moveHorizontal.ToString ();

		if (moveVertical > 0) {
			moveForeward = true;
			/*
			if(moveVertical < 1){
				moveForeward = false;
			}
			*/
		} else {
			moveForeward = false;
		}

		if (moveHorizontal > 0) {
			moveRight = true;
			/*
			if(moveHorizontal < 1){
				moveRight = false;
			}
			*/
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

		if(Input.GetButtonDown("Shoot1") || Input.GetButtonDown("Shoot2") || Input.GetButtonDown("Fire1")){
			bala.gameObject.SetActive (true);
			Instantiate (bala, bala.transform.position, Quaternion.identity);
			bala.gameObject.SetActive (false);
		}

		if(Input.GetButtonDown("Jump")){
			//transform.rigidbody .Translate (0, 0.7f, 0);
		}

		if(Input.GetButtonDown("Restart")){
			Application.LoadLevel ("Main");
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
