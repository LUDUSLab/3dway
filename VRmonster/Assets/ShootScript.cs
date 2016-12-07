using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {
    public GameObject BulletPrefab;
    public Transform ShootPoint, Target;
    public float velocity;

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        StartCoroutine(RepeatShoot());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator RepeatShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            anim.SetTrigger("Shoot");
            yield return new WaitForSeconds(0.5f);
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject newBullet = (GameObject)Instantiate(BulletPrefab);
        newBullet.transform.position = ShootPoint.position;
        Vector3 Direction = Target.position - ShootPoint.position;
        newBullet.GetComponent<Rigidbody>().velocity = Direction.normalized * velocity;
    }
}
