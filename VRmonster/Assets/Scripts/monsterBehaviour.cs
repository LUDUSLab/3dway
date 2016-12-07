using UnityEngine;
using System.Collections;

public class monsterBehaviour : MonoBehaviour {

	public Animator anime;
	public int vida;

	private bool tomaDano;
	private bool estaMorto;

    public Transform Lifes;

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



	}

	void OnCollisionEnter(Collision other){
        anime.SetTrigger("Damage");
		vida--;
        if(vida <= 0)
        {
            anime.SetTrigger("Die");
        }
        Destroy(Lifes.GetChild(0).gameObject);
    }
}
