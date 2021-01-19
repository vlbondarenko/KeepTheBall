using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour {
    public Camera cAmera;
    public float speed;
    public Vector3 startMarker=new Vector3(0,0,0);
    public Vector3 endMarker=new Vector3(6,0,0);
    Vector3 newPos;
    public float startTime;
    public float journeyLength;
    int ukaz=0;
    bool razr,clos;
    public Button right;
    public Button left;
    bool musOn;
    public Vector3 newPosition;
    public string meny;
    public string keyName = "S";
    public int numLev;

    public void Awake()
    {

       
        if (PlayerPrefs.GetInt("firstGame") == 0)
        {
            CountLevel();
            PlayerPrefs.SetInt("firstGame", 1);
        }
           
        
       
        transform.position = new Vector3(PlayerPrefs.GetFloat(meny), PlayerPrefs.GetFloat(meny + "V"), -10);
        ukaz = PlayerPrefs.GetInt(meny + "Z");
    }
    
    public void CountLevel()
    {
        for (int i = 1; i < 50; i++)
        {
            if (PlayerPrefs.GetInt(keyName + numLev.ToString()) == 3)
            {
                PlayerPrefs.SetInt("openBall", PlayerPrefs.GetInt("openBall") + 1);
            }
            numLev++;
        }
    }

    public void savePosition()
    {
        newPosition = transform.position;
        PlayerPrefs.SetFloat(meny, newPosition.x);
        PlayerPrefs.SetFloat(meny + "V", newPosition.y);
        PlayerPrefs.SetInt(meny + "Z", ukaz);
        PlayerPrefs.Save();
    }

    void Start()
    {journeyLength = Vector3.Distance(startMarker, endMarker);
       
        
    }
    public void OnClickRight()
    {
        startTime = Time.time;
        newPos = new Vector3(cAmera.transform.position.x + 12f, cAmera.transform.position.y, cAmera.transform.position.z);
        razr = true;
        ukaz += 1;
        musOn = true;
    

       
    }
    public void OnClickLeft()
    {
        startTime = Time.time;
        newPos = new Vector3(cAmera.transform.position.x - 12f, cAmera.transform.position.y, cAmera.transform.position.z);
        clos = true;
        ukaz -= 1;
        musOn = true;
       
    }
    void Update()
    {
        newPosition = transform.position;
        if (musOn == true && PlayerPrefs.GetString("Music") == "yes")
        {
            GameObject.Find("ClickAudio").gameObject.GetComponent<AudioSource>().Play();
            musOn = false;
        }
        if (razr == true)
        {
          
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            cAmera.transform.position = Vector3.Lerp(cAmera.transform.position, newPos, fracJourney);
           
        }
        if (ukaz == 3)
        {
            right.GetComponent<Button>().interactable = false;
        }
        else if (ukaz != 3)
        {
            right.GetComponent<Button>().interactable = true;
        }
        if (clos == true)
        {

            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            cAmera.transform.position = Vector3.Lerp(cAmera.transform.position, newPos, fracJourney);

        }
        if (ukaz == 0)
        {
            left.GetComponent<Button>().interactable = false;
        }
        else if (ukaz!=0)
        {
            left.GetComponent<Button>().interactable = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        Debug.Log(PlayerPrefs.GetFloat(meny));


        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.SetInt("firstGame", 0);
            PlayerPrefs.SetInt("openBall", 0);
            PlayerPrefs.SetInt("watch",0);
        }
        Debug.Log(PlayerPrefs.GetInt("openBall"));
    }
}
