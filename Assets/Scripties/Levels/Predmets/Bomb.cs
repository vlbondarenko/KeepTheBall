using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
    public ParticleSystem fire, dym,over;
    public GameObject boomAud;
    public Bubble onEnterBub;

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Ball")//если шар соприкасается с звездой то к счетчику прибавляется 1
        {
            Instantiate(fire, transform.position, transform.rotation);
            Instantiate(dym, transform.position, transform.rotation);
            Instantiate(over, transform.position, transform.rotation);
            Destroy(gameObject);
            if (PlayerPrefs.GetString("Music") == "yes")
            {
                boomAud.GetComponent<AudioSource>().Play();
            }

        }
        if (trigger.gameObject.tag == "Bubble")//если шар соприкасается с звездой то к счетчику прибавляется 1
        {
            if (onEnterBub.onEnterBubble == true)
            {
                Instantiate(fire, transform.position, transform.rotation);
                Instantiate(dym, transform.position, transform.rotation);

                Destroy(gameObject);
                if (PlayerPrefs.GetString("Music") == "yes")
                {
                    boomAud.GetComponent<AudioSource>().Play();
                }
            }

        }
    }
    void Start () {
        if (PlayerPrefs.GetInt("selectBall") == 0)
        {
            over.startColor = new Color(0.58f, 0.27f, 0f);
        }
       else if (PlayerPrefs.GetInt("selectBall") == 3)
        {
            over.startColor = new Color(0.6f, 0.69f, 0.16f);
        }
        else if (PlayerPrefs.GetInt("selectBall") == 1)
        {
            over.startColor = new Color(0.66f, 0.36f, 0.08f);
        }
        else if (PlayerPrefs.GetInt("selectBall") == 2)
        {
            over.startColor = new Color(0.78f, 1f, 0.83f);
        }
        else if (PlayerPrefs.GetInt("selectBall") == 4)
        {
            over.startColor = new Color(0.83f, 0.325f, 0.114f);
        }
        else if (PlayerPrefs.GetInt("selectBall") == 5)
        {
            over.startColor = new Color(0.15f, 0.14f, 0.145f);
        }
        else if (PlayerPrefs.GetInt("selectBall") == 6)
        {
            over.startColor = new Color(0.96f, 0.8f, 0.557f);
        }
       

    }
}
