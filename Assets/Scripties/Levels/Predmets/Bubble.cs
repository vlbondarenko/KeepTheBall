using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {
    public Ball ball;
    public float speed,speed1;
    Vector3 cour;
    public HintSystem panel;
    public Physics2D bubble;
    public GamePlay close;
    public Bubble buBble;
    public Vector3 newPosition;
    public string predName;
    public Interface reload;
    public Teleport one;
    public ParticleSystem bubBle,destroyBall;
    public bool onEnterGaOv,onEnterBubble;
    public int i=1;
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "GameOver")//если шар соприкасается с звездой то к счетчику прибавляется 1
        {
            one.one = false;
            onEnterGaOv = true;

        }
        if (trigger.gameObject.tag == "Bomb")//если шар соприкасается с звездой то к счетчику прибавляется 1
        {
            if (onEnterBubble == true)
            {
                ball.transform.parent = null;
                one.one = false;
               ball. GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
               ball. GetComponent<Rigidbody2D>().isKinematic = true;
               ball. GetComponent<Collider2D>().isTrigger = true;
                ball.startTime = Mathf.Round(Time.time);
                ball.ovE = true;
                ball.overOn = true;
                Instantiate(bubBle, transform.position, transform.rotation);
                Instantiate(destroyBall, transform.position, transform.rotation);
             
                Destroy(gameObject);
            }
        }
    }
    public void Awake() {
        if (PlayerPrefs.GetInt(reload.first) == 0)
        {
            newPosition = transform.position;
            PlayerPrefs.SetFloat(predName, newPosition.x);
            PlayerPrefs.SetFloat(predName + "B", newPosition.y);
            PlayerPrefs.Save();
        }
    }
    public void savePosition()
{
    newPosition = transform.position;
    PlayerPrefs.SetFloat(predName, newPosition.x);
    PlayerPrefs.SetFloat(predName + "B", newPosition.y);
    PlayerPrefs.Save();
        Debug.Log("co[hfytybt");

}
public void Start()
{
    transform.position = new Vector3(PlayerPrefs.GetFloat(predName), PlayerPrefs.GetFloat(predName + "B"), transform.position.z);
}


void Update () {
      

        cour = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        newPosition = transform.position;
      
        if(Mathf.Abs(ball.transform.position.x-transform.position.x)<0.4&& Mathf.Abs(ball.transform.position.y - transform.position.y) < 0.4 && ball.transform.position != transform.position)
        {
            one.one = true;
            ball.GetComponent<Rigidbody2D>().isKinematic = true;
            ball.transform.position = Vector2.MoveTowards(ball.transform.position, transform.position, Time.deltaTime * speed);
           

        }
        else if (ball.transform.position == transform.position)
        {
           
            ball.transform.parent = transform;
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().gravityScale = -0.15f;
            ball.GetComponent<Collider2D>().isTrigger = true;
            GetComponent<Collider2D>().isTrigger = false;
            onEnterBubble = true;



        }

        if (Input.GetKeyDown(KeyCode.Mouse0)&&close.cloSeF==true&&ball.finishPanel.activeSelf==false&&ball.GameOver.activeSelf==false&&reload.pauSe.activeSelf==false&&panel.help.activeSelf==false&& panel.help1.activeSelf == false)
        {
            Collider2D[] all = Physics2D.OverlapCircleAll((Vector2)cour, 0.5f);
            foreach (var item in all)
            {
                if (item.GetComponent<Bubble>())
                {
                    buBble = item.GetComponent<Bubble>();
                }
            }
        }
        
        if (buBble != null)
        {
            if (PlayerPrefs.GetString("Music") == "yes")
            {
                GameObject.Find("BubbleAudio").gameObject.GetComponent<AudioSource>().Play();
              

            }
          
            ball.transform.parent =null;
            ball.GetComponent<Rigidbody2D>().isKinematic = false;
            ball.GetComponent<Collider2D>().isTrigger = false;
            Instantiate(bubBle, transform.position, transform.rotation);
            onEnterBubble = false;
            one.one = false;
            Destroy(gameObject);
         
        }

       

    }
}
