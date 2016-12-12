using UnityEngine;
using System.Collections;

public class roboBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("w")){
			transform.Translate (0,0, 0.2f);
		}
		if(Input.GetButtonDown("Jump")){
			transform.Translate (0, 0.7f, 0);
		}
	}
}
