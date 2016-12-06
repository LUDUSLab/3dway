using UnityEngine;
using System.Collections;

public class monsterBehaviour : MonoBehaviour {

	public Animator anime;

	private bool tomaDano;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(tomaDano == false){
			anime.SetBool ("tomaDano", false);
		}
		if(tomaDano == true){
			anime.SetBool ("tomaDano", true);
			tomaDano = false;
		}
	}

	void OnCollisionEnter(Collision other){
		tomaDano = true;
	}
}
