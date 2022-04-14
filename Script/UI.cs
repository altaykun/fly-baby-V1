using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public static UI instance;


    public Text scoreText;
    public Text highScore;
    float persec;
    public float score;
    float highscore;
    int uc = 4;
    public int uc2 = 5;


    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        score = 0f;
        highscore = 0f;
        persec = 1f;
        scoreText.text = score.ToString() + "POINTS";
        highScore.text = "HIGH SCORE: " + highscore.ToString();
    }


    public void AddPoints()
    {
        if(highscore<score)
        {
            highscore = score;
        }
        //score += persec * Time.deltaTime*2;
        score += 1;
        scoreText.text = score.ToString() + "POINTS";
        highScore.text = "HIGH SCORE: " + highscore.ToString();


    }

    [SerializeField] private Transform playerTransform;





    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }




    public void OnDrag(PointerEventData eventData)
    {

        playerTransform.position += new Vector3(eventData.delta.x / 100f, 0, 0);
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (PMove.instance.yer == true)
        {
            PMove.instance.GetComponent<Rigidbody>().AddForce(transform.up * uc, ForceMode.Impulse);

        }
        if (PMove.instance.yer2 == true)
        {
            PMove.instance.GetComponent<Rigidbody>().AddForce(transform.up * uc2, ForceMode.Impulse);

        }

    }


    //rb.AddForce(transform.up* jumpForce, ForceMode.Impulse);


}
