using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("DestroyObj", 3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
