﻿using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	public float speed;
	public float tempDesvia;

	public GameObject bala;

	private CharacterController controller;
	private GvrViewer gvrViewer;
	private Transform vrHead;

	private bool moveRight;
	private bool moveLeft;

	private float contRight;
	private float contLeft;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController> ();
		gvrViewer = transform.GetChild (0).GetComponent<GvrViewer> ();
		vrHead = Camera.main.transform;
		contRight = 0;
		contLeft = 0;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 right = vrHead.TransformDirection (Vector3.right);

		if(vrHead.rotation.eulerAngles.z > 25 && vrHead.rotation.eulerAngles.z <= 85 && moveLeft == false){
			//controller.SimpleMove (-right*speed);
			moveLeft = true;
			contLeft = 0;
		}else if(vrHead.rotation.eulerAngles.z <= 335 && vrHead.rotation.eulerAngles.z >= 275 && moveRight == false){
			//controller.SimpleMove (right*speed);
			moveRight = true;
			contRight = 0;
		}
			
		if(moveLeft == true){
			Debug.Log ("esta movendo direita");
			controller.SimpleMove (-right*speed);
			contLeft += Time.deltaTime;
			if(contLeft >= tempDesvia){
				moveLeft = false;
			}
		}else if(moveRight == true){
			controller.SimpleMove (right*speed);
			contRight += Time.deltaTime;
			if(contRight >= tempDesvia){
				moveRight = false;
			}
		}

		if(Input.GetButtonDown("Jump")){
			bala.gameObject.SetActive (true);
			Instantiate (bala, bala.transform.position, Quaternion.identity);
			bala.gameObject.SetActive (false);
		}

		//Debug.Log (vrHead.rotation.ToString() + " | " + vrHead.rotation.eulerAngles.z.ToString());
	}
}
