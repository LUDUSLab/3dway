using UnityEngine;
using System.Collections;

public class monsterBehaviour : MonoBehaviour {

	public Animator anime;
	public int vida;

	private bool tomaDano;
	private bool estaMorto;

	// Use this for initialization
	void Start () {
		estaMorto = false;
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

		if(vida <= 0){
			estaMorto = true;
		}

		anime.SetBool ("estaMorto", estaMorto);


	}

	void OnCollisionEnter(Collision other){
		tomaDano = true;
		vida--;
	}
}
