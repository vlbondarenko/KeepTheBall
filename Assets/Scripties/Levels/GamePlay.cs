using UnityEngine;
using System.Collections;
 
//*********Скрипт передвижения предметов*********
public class GamePlay : MonoBehaviour

{
    public Konveer selectKonv;
    public Ball SelectedBall,ballPos;
    public Predmets SelectedBalka;
    public Komveer selectKomv;
    public Teleport selectTeleport;
    public Bubble selectBubble;
    public Fan selectFan;
    public Fin finPosition;
    public Star starPos;
    private byte i;
    private float timer;
    public float speed1=1000;
    public bool cloSeF,teleport,bubbleBlok=true,starCollider;
    public Conveer[] ukaz,ukaz1;

    //**********************  Время нажатия клавиши   **************************
    float OnMouseDrag()//таймер
    {
        for (i = 1; i < 100; i++)
        {
            timer -= Time.deltaTime;
        }
        return timer;
    }
    //***********************  Выполняется при старте программы  **************
    void Start()
    {
    }
    //************************ Выполняется при обновлении кадра ****************
    void Update()
    {
       

        Vector3 cour = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Позиция курсора

    

        //Округленные до целого координаты
        //*********************** Выбор объекта *************************************
        if (Input.GetKeyDown(KeyCode.Mouse0)&&cloSeF==false)// Выбор предмета на игровом поле
        {
            Collider2D all = Physics2D.OverlapCircle((Vector2)cour, 0.25f);
           
                if (all.GetComponent<Ball>())
                {
                    SelectedBall = all.GetComponent<Ball>();
                }
                else if (all.GetComponent<Predmets>())
                {
                    SelectedBalka = all.GetComponent<Predmets>();
                }
               
               else if (all.GetComponent<Teleport>())
                {
                    selectTeleport = all.GetComponent<Teleport>();
                }
               else if (all.GetComponent<Bubble>())
                {
                    selectBubble = all.GetComponent<Bubble>();
                }
               else if (all.GetComponent<Fan>())
                {
                    selectFan = all.GetComponent<Fan>();
                }
                else if (all.GetComponent<Komveer>())
            {
                selectKomv = all.GetComponent<Komveer>();
            }
            else if (all.GetComponent<Konveer>())
            {
                selectKonv = all.GetComponent<Konveer>();
            }

        }
        //********************** Установка таймера если объект выбран **************
        if (SelectedBalka != null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            timer = 70;
        }
       
        if (selectFan != null && Input.GetKeyDown(KeyCode.Mouse0))
        {
            timer = 70;
        }
        //**** Перемещение объекта ******************************************
        if (selectKonv != null)//предмет
        {
            if (OnMouseDrag() < 15 && cloSeF == false && cour.y <= 4f)
            {

                selectKonv.transform.position = Vector2.MoveTowards(selectKonv.transform.position, cour, Time.deltaTime * speed1);
            }
            else if (OnMouseDrag() < 15 && cloSeF == false && cour.y >= 4f)
            {

                selectKonv.transform.position = Vector2.MoveTowards(selectKonv.transform.position, new Vector3(cour.x, 4f, 0), Time.deltaTime * speed1);
            }
        }
        if (selectKomv != null)//предмет
        {
            if (OnMouseDrag() < 15 && cloSeF == false && cour.y <= 4f)
            {

                selectKomv.transform.position = Vector2.MoveTowards(selectKomv.transform.position, cour, Time.deltaTime * speed1);
            }
            else if (OnMouseDrag() < 15 && cloSeF == false && cour.y >= 4f)
            {

                selectKomv.transform.position = Vector2.MoveTowards(selectKomv.transform.position, new Vector3(cour.x, 4f, 0), Time.deltaTime * speed1);
            }
        }
        if (SelectedBalka != null)//предмет
        {
            if (OnMouseDrag() < 15&&cloSeF==false&&cour.y<=4f)
            {
                SelectedBalka.transform.localScale = new Vector3(0.42f, 0.14f, 1);
                SelectedBalka.transform.position = Vector2.MoveTowards(SelectedBalka.transform.position, cour, Time.deltaTime * speed1);
            }
            else if(OnMouseDrag() <15 && cloSeF == false && cour.y >= 4f)
            {
                SelectedBalka.transform.localScale = new Vector3(0.4f, 0.13f, 1);
                SelectedBalka.transform.position = Vector2.MoveTowards(SelectedBalka.transform.position,new Vector3(cour.x,4f,0), Time.deltaTime * speed1);
            }
        }
      
        if (selectTeleport != null)//предмет
        {
            if (cloSeF == false && cour.y <= 4f)
            {
               
                selectTeleport.transform.position = Vector2.MoveTowards(selectTeleport.transform.position, cour, Time.deltaTime * speed1);
            }
            else if ( cloSeF == false && cour.y >= 4f)
            {
               
                selectTeleport.transform.position = Vector2.MoveTowards(selectTeleport.transform.position, new Vector3(cour.x, 4f, 0), Time.deltaTime * speed1);
            }
        }
        if (selectBubble != null)//предмет
        {
            if (cloSeF == false && cour.y <= 4f)
            {
               
                selectBubble.transform.position = Vector2.MoveTowards(selectBubble.transform.position, cour, Time.deltaTime * speed1);
            }
            else if (cloSeF == false && cour.y >= 4f)
            {
                
                selectBubble.transform.position = Vector2.MoveTowards(selectBubble.transform.position, new Vector3(cour.x, 4f, 0), Time.deltaTime * speed1);
            }
        }
        if (selectFan != null)//предмет
        {
            if (OnMouseDrag() < 15 && cloSeF == false && cour.y <= 4f)
            {

                selectFan.transform.position = Vector2.MoveTowards(selectFan.transform.position, cour, Time.deltaTime * speed1);
            }
            else if (OnMouseDrag() < 15 && cloSeF == false && cour.y >= 4f)
            {

                selectFan.transform.position = Vector2.MoveTowards(selectFan.transform.position, new Vector3(cour.x, 4f, 0), Time.deltaTime * speed1);
            }
        }
        //**************************************************************************************************************************************


        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (selectKonv != null)
            {
                if (OnMouseDrag() >= 15 && cloSeF == false)
                {
                    selectKonv.GetComponent<SurfaceEffector2D>().speed = -selectKonv.GetComponent<SurfaceEffector2D>().speed;
                    ukaz1[0].tilt = -ukaz1[0].tilt;
                    ukaz1[1].tilt = -ukaz1[1].tilt;
                    ukaz1[2].tilt = -ukaz1[2].tilt;
                }
                selectKonv.transform.localScale = new Vector3(0.9f, 0.73f, 1f);
                selectKonv = null;
            }

            if (selectKomv != null)
            {
                if (OnMouseDrag() >= 15 && cloSeF == false)
                {
                    selectKomv.GetComponent<SurfaceEffector2D>().speed = -selectKomv.GetComponent<SurfaceEffector2D>().speed;
                    ukaz[0].tilt = -ukaz[0].tilt;
                    ukaz[1].tilt = -ukaz[1].tilt;
                    ukaz[2].tilt = -ukaz[2].tilt;
                }
                selectKomv.transform.localScale = new Vector3(0.9f, 0.73f, 1f);
                selectKomv = null;
            }
            if (SelectedBalka != null)
            {
                if (OnMouseDrag() >= 15&&cloSeF==false)
                {
                    SelectedBalka.transform.Rotate(new Vector3(0, 0, 22.5f), Space.Self);
                }
                SelectedBalka.transform.localScale = new Vector3(0.4f, 0.13f, 1f);
                SelectedBalka = null;
            }
           
            if (SelectedBall != null)// при нажатии на шар - включить физику
            {
                SelectedBall.GetComponent<Rigidbody2D>().isKinematic = false;
                SelectedBall = null;
                cloSeF = true;
                teleport = true;
                bubbleBlok = false;
                starCollider = true;
               

            }
            if (selectTeleport != null)
            {
              
                selectTeleport = null;
            }
            if (selectBubble != null)
            {
                selectBubble.savePosition();
                selectBubble = null;
            }
            if (selectFan != null)
            {
                if (OnMouseDrag() >= 15 && cloSeF == false)
                {
                    selectFan.transform.Rotate(new Vector3(0, 0, 180f), Space.Self);
                }

                selectFan = null;
            }
            timer = 70;
        }
      
    }
}
    
