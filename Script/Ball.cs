using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public int hitN;
    public int hitUp;
    public static Ball instance;


    Rigidbody rb;    


    void Start()

    {
        rb = GetComponent<Rigidbody>();
        instance = this;

    }

    private double x = 0.001;
    private double z = -0.001;




    void OnCollisionEnter(Collision other)
    {
        foreach(ContactPoint hitPos in other.contacts)
        {



            if (hitPos.normal.x > x)
            {
                PMove.instance.GetComponent<Rigidbody>().AddForce(-transform.right * hitN);
                PMove.instance.GetComponent<Rigidbody>().AddForce(transform.up * hitUp);
            }

            if (hitPos.normal.x < z)
            {
                PMove.instance.GetComponent<Rigidbody>().AddForce(transform.right * hitN);
                PMove.instance.GetComponent<Rigidbody>().AddForce(transform.up * hitUp);

            }
            if (hitPos.normal.y < z)
            {
                PMove.instance.GetComponent<Rigidbody>().AddForce(transform.right * hitN);
                PMove.instance.GetComponent<Rigidbody>().AddForce(transform.up * hitUp);

            }
        }

    }
}
