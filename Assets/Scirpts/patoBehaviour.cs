using UnityEngine;
using System.Collections;

public class patoBehaviour : MonoBehaviour {

	public GameObject pato;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.name == "bala(Clone)"){
			Destroy (pato);
		}
	}
}
