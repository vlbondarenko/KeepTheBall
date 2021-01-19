using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
    public Ball ball;
    public GameObject exitPosition;
    public bool one;
    public Vector3 newPosition;
    public string predName;
    public bool pref;
    public Interface reload;
    public GamePlay phisicsOn;
    public Bubble onEnterBubble;


    public void Awake()

    {
        if (PlayerPrefs.GetInt(reload.first) == 0)
        {
            newPosition = transform.position;
            PlayerPrefs.SetFloat(predName, newPosition.x);
            PlayerPrefs.SetFloat(predName + "P", newPosition.y);
            PlayerPrefs.Save();
        }
    }
    public void savePosition()
    {
        newPosition = transform.position;
        PlayerPrefs.SetFloat(predName, newPosition.x);
        PlayerPrefs.SetFloat(predName + "P", newPosition.y);
        PlayerPrefs.Save();

    }
    public void Start()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat(predName), PlayerPrefs.GetFloat(predName + "P"), transform.position.z);

       

    }
    void Update()
    {
        if(Mathf.Abs( ball.transform.position.x-transform.position.x)<0.3f&& Mathf.Abs(ball.transform.position.y-transform.position.y) < 0.3&&one==false&&phisicsOn.teleport==true&&onEnterBubble.onEnterBubble==false)
        {
            one = true;
            ball.GetComponent<Rigidbody2D>().isKinematic = true; 
            ball.transform.position =new Vector3(exitPosition.transform.position.x, exitPosition.transform.position.y, ball.transform.position.z);
            ball.GetComponent<Rigidbody2D>().isKinematic = false;

        }
      
        if (reload.raz == true)
        {
            savePosition();
          
        }
        else if (reload.raz1 == true)
        {
            savePosition();
        }

    }
}
