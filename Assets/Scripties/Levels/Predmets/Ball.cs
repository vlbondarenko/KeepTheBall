using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class Ball : MonoBehaviour {

    public int starInt = 0;// количество собранных звезд
    public GameObject finishPanel;
    public GameObject GameOver;
    public float startTime;
    private bool fiN;
    private byte vkl=2;
    private double sravn;
    public bool ovE,musOn,overOn,starOn,bombOn;
    public GameObject star, win, lose, ball;//звуки 
    public Vector3 startPosition;
    public Sprite newBall;
    public Sprite[] selectBall;



    public void Awake()
    {
        if (PlayerPrefs.GetInt("selectBall")==0)
        {
            GetComponent<SpriteRenderer>().sprite = selectBall[PlayerPrefs.GetInt("selectBall")];
            GetComponent<SpriteRenderer>().color = new Color(0.235f, 0.125f, 0.0313f);
        }
        else if (PlayerPrefs.GetInt("selectBall") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = selectBall[PlayerPrefs.GetInt("selectBall")];
            GetComponent<SpriteRenderer>().color = new Color(1f, 0.815f, 0.5f);
        }
        else if (PlayerPrefs.GetInt("selectBall") == 6)
        {
            GetComponent<SpriteRenderer>().sprite = selectBall[PlayerPrefs.GetInt("selectBall")];
            GetComponent<SpriteRenderer>().color = new Color(0.96f, 0.8f, 0.556f);
        }
        else if (PlayerPrefs.GetInt("numberBall") == 2)
        {
            GetComponent<SpriteRenderer>().sprite = selectBall[PlayerPrefs.GetInt("selectBall")];
            GetComponent<SpriteRenderer>().color = new Color(0.78f, 1f, 0.83f);
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = selectBall[PlayerPrefs.GetInt("selectBall")];
            GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f);
        }

           
       

    }

 
    void OnTriggerEnter2D(Collider2D trigger)
    {   if (trigger.gameObject.tag == "stars")//если шар соприкасается с звездой то к счетчику прибавляется 1
        {
            starInt++;
            starOn = true;         
        }
     if (trigger.gameObject.tag == "finish")
        {         
            startTime =Mathf.Round( Time.time);

            if (starInt > 0)
            {
                fiN = true;
            }
            if (starInt == 0)
            {
                ovE = true;
                overOn = true;
            }
        }
        if (trigger.gameObject.tag == "GameOver")
        {
            startTime = Mathf.Round(Time.time);
            ovE = true;
            overOn = true;
         
        }
        if (trigger.gameObject.tag == "Bomb")
        {   
            startTime = Mathf.Round(Time.time);
            ovE = true;
            overOn = true;
           
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
            GetComponent<Rigidbody2D>().isKinematic=true;
            GetComponent<Collider2D>().isTrigger = true;
            Destroy(GetComponent<CircleCollider2D>());
       

        }
       

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Predmets")
        {
            musOn = true;

        }
    }
    void Start()//***********************************************************************************************
    {
       
        
        startPosition = transform.position;
    }	
	void Update ()
    {
       

        if (PlayerPrefs.GetString("Music") == "yes"&&musOn==true)//звук мяча
        {
            ball.GetComponent<AudioSource>().Play();
            musOn = false;
        }
        if (PlayerPrefs.GetString("Music") == "yes" && starOn == true)//звук взятия звезды 
        {
            star.GetComponent<AudioSource>().Play();
            starOn = false;
        }
        sravn = Mathf.Round(Time.time);
      if (sravn==startTime+vkl && fiN == true)//временная звдержка перед появлением панли финиша
        {
            finishPanel.SetActive(true);
        }
        if (sravn == startTime + vkl && ovE == true)//временная звдержка перед появлением панли проигрыша
        {
            GameOver.SetActive(true);
            if (PlayerPrefs.GetString("Music") == "yes" && overOn == true)
            {
                lose.GetComponent<AudioSource>().Play();
                overOn = false;
            }
        }
    }   
}
