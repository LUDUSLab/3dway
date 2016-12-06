using UnityEngine;
using System.Collections;

public class colisaoBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = new Quaternion(0, 0, 0, 0);
	}

	void OnCollisionEnter(Collision other){
		Debug.Log ("ljdiwgbfouGIFYWEHUFHIUEHOÇYHO");
	}
}
