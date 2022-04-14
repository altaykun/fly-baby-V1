using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PMove : MonoBehaviour
{
    private IEnumerator coroutine;

    public bool herseyreset = false;


    public bool yer = false;
    public bool yer2 = false;


    public Transform respawnPoint;

    Animator CharAnimator;

    public float jumpForce;

    public float playerSpeed = 4f;

    Rigidbody rb;

    private bool fare = false;

    public static PMove instance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        instance = this;
        CharAnimator = GetComponent<Animator>();

    }

    private IEnumerator Fasta(float waitTime)
    {
        yield return new WaitForSeconds(1);
        rb.AddForce(transform.forward * 4, ForceMode.Impulse);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jumper")
        {
            if(herseyreset == false)
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                coroutine = Fasta(1.2f);
                StartCoroutine(coroutine);
            }
        }
        if (other.gameObject.tag == "Ground")
        {
            yer = true;

        }
        if (other.gameObject.tag == "GroundS")
        {
            yer2 = true;

        }
        if (other.gameObject.tag == "Hide")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            this.transform.position = respawnPoint.transform.position;
            fare = false;
            UI.instance.score = 0;
            CharAnimator.SetBool("Run", false);
            herseyreset = true;
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            yer = false;
        }
        if (other.gameObject.tag == "GroundS")
        {
            yer2 = false;
        }
        if (other.gameObject.tag == "Hide")
        {
            herseyreset = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (Input.GetMouseButton(0))
        {
            fare = true;
            CharAnimator.SetBool("Run", true);
        }
        if (fare)
        {
            transform.position += transform.forward * playerSpeed * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        UI.instance.AddPoints();
    }
}
