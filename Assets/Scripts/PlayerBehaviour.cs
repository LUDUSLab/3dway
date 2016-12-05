using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public float speed;
	public float tempDesvia;

	private CharacterController controller;
	private GvrViewer gvrViewer;
	public Transform vrHead;

	private bool moveRight;
	private bool moveLeft;

	private float contRight;
	private float contLeft;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		gvrViewer = transform.GetChild (0).GetComponent<GvrViewer> ();
		contRight = 0;
		contLeft = 0;
		//vrHead = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 right = vrHead.TransformDirection (Vector3.right);

		if(vrHead.rotation.eulerAngles.z > 25 && vrHead.rotation.eulerAngles.z <= 85 && moveLeft == false){
			//controller.SimpleMove (-right*speed);
			moveLeft = true;
		}else if(vrHead.rotation.eulerAngles.z <= 335 && vrHead.rotation.eulerAngles.z >= 275 && moveRight == false){
			//controller.SimpleMove (right*speed);
			moveRight = true;
		}
			
		if(moveLeft == true){
			controller.SimpleMove (-right*speed);
			contLeft += Time.deltaTime;
			if(contLeft >= tempDesvia){
				contLeft = 0;
				moveLeft = false;
			}
		}else if(moveRight == true){
			controller.SimpleMove (right*speed);
			contRight += Time.deltaTime;
			if(contRight >= tempDesvia){
				contRight = 0;
				moveRight = false;
			}
		}

		Debug.Log (vrHead.rotation.ToString() + " | " + vrHead.rotation.eulerAngles.z.ToString());
	}
}
