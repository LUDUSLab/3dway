using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{

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

    public Material FadePanel;

    [SerializeField]
    int Lifes;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        gvrViewer = transform.GetChild(0).GetComponent<GvrViewer>();
        vrHead = Camera.main.transform;
        contRight = 0;
        contLeft = 0;
        FadePanel.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);

        Vector3 right = vrHead.TransformDirection(Vector3.right);

        if (vrHead.rotation.eulerAngles.z > 25 && vrHead.rotation.eulerAngles.z <= 85 && moveLeft == false)
        {
            moveLeft = true;
            contLeft = 0;
        }
        else if (vrHead.rotation.eulerAngles.z <= 335 && vrHead.rotation.eulerAngles.z >= 275 && moveRight == false)
        {
            moveRight = true;
            contRight = 0;
        }

        if (moveLeft == true)
        {
            controller.SimpleMove(-right * speed);
            contLeft += Time.deltaTime;
            if (contLeft >= tempDesvia)
            {
                moveLeft = false;
            }
        }
        else if (moveRight == true)
        {
            controller.SimpleMove(right * speed);
            contRight += Time.deltaTime;
            if (contRight >= tempDesvia)
            {
                moveRight = false;
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            bala.gameObject.SetActive(true);
            Instantiate(bala, bala.transform.position, Quaternion.identity);
            bala.gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("esta tocaaaaaaando");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyShoot"))
        {
            StartCoroutine(FadeScreen());
        }
    }

    IEnumerator FadeScreen()
    {
        float alfa = 0;
        while(alfa <= 1)
        {
            yield return new WaitForSeconds(0.05f);
            alfa += 0.05f;
            FadePanel.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, alfa);
        }
        SceneManager.LoadScene("main");
    }
}
