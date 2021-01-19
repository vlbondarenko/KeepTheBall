using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class BallShop : MonoBehaviour {
    public Sprite[] balls;
    public GameObject icon;
    public GameObject BallPanel;
    public int numberBall;
    public Button next;
    public Button down;
    public Button select;
    public bool musOn;
    public Text buttonText;
    public Text downText;
    public GameObject oKay;

    public void ShowAds()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
            Debug.Log("реклама просмотрена");
        }

    }
    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                if (PlayerPrefs.GetInt("numberBall") == 1)
                {
                    PlayerPrefs.SetInt("getBall1", 1);
                    buttonText.GetComponent<Text>().text = "Выбрать мяч";
                }
                if (PlayerPrefs.GetInt("numberBall") == 4)
                {
                    PlayerPrefs.SetInt("getBall2", 1);
                    buttonText.GetComponent<Text>().text = "Выбрать мяч";
                }
                break;
            case ShowResult.Skipped:
                Debug.LogWarning("Video was skipped.");
                break;
            case ShowResult.Failed:
                Debug.LogError("Video failed to show.");
                break;
        }
    }


    void Awake()
    {
       
    }

    void Start () {
       if (PlayerPrefs.GetString("takeBall")== "yes")
        {
            PlayerPrefs.SetInt("getBall1", 1);
            PlayerPrefs.SetInt("numberBall", 1);
            PlayerPrefs.SetInt("selectBall", 1);
            PlayerPrefs.SetString("takeBall", "null");
        }
    }

    public void OnClickNextBall()
    {
        musOn = true;
           numberBall += 1;
        PlayerPrefs.SetInt("numberBall", numberBall);
        buttonText.GetComponent<Text>().text = "Выбрать мяч";
        oKay.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0.09f, 0f);
    }
    public void OnClickPredBall()
    {
        musOn = true;
        numberBall -= 1;
        PlayerPrefs.SetInt("numberBall", numberBall);
        buttonText.GetComponent<Text>().text = "Выбрать мяч";
        oKay.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0.09f, 0f);
    }
    public void OnClickClose()
    {
        musOn = true;
        BallPanel.SetActive(false);
      

    }
    public void OnClickOpen()
    {
        musOn = true;
        BallPanel.SetActive(true) ;

    }
    public void SelectBall()
    {
        musOn = true;
        if (PlayerPrefs.GetInt("getBall1") == 0&& PlayerPrefs.GetInt("numberBall") == 1)
        {
            ShowAds();
            PlayerPrefs.SetInt("selectBall", numberBall);
            oKay.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0.09f, 1f);
        }
       else if (PlayerPrefs.GetInt("getBall2") == 0 && PlayerPrefs.GetInt("numberBall") == 4)
        {
            ShowAds();
            PlayerPrefs.SetInt("selectBall", numberBall);
            oKay.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0.09f, 1f);
        }
        else {
            PlayerPrefs.SetInt("selectBall", numberBall);
            oKay.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0.09f, 1f);
        }


    }



    void Update () {


        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.SetInt("getBall1", 0);
           
        }



        numberBall = PlayerPrefs.GetInt("numberBall");
        Debug.Log(PlayerPrefs.GetInt("selectBall"));
        icon.GetComponent<SpriteRenderer>().sprite = balls[PlayerPrefs.GetInt("numberBall")];

        if (musOn == true && PlayerPrefs.GetString("Music") == "yes")
        {
            GameObject.Find("ClickAudio").gameObject.GetComponent<AudioSource>().Play();
            musOn = false;
        }




//*****************************************Изменение цвета иконки*********************************
        if (PlayerPrefs.GetInt("numberBall") == 0)
        {
            icon.GetComponent<SpriteRenderer>().color =new Color(0.235f,0.125f,0.0313f);
        }
        else if (PlayerPrefs.GetInt("numberBall") == 1)
        {
            icon.GetComponent<SpriteRenderer>().color = new Color(1f, 0.815f, 0.5f);
        }
        else if (PlayerPrefs.GetInt("numberBall") == 6)
        {
            icon.GetComponent<SpriteRenderer>().color = new Color(0.96f, 0.8f, 0.556f);
        }
        else if (PlayerPrefs.GetInt("numberBall") == 2)
        {
            icon.GetComponent<SpriteRenderer>().color = new Color(0.78f, 1f, 0.83f);
        }
        else
        {
            icon.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f);
        }





//********************Отключение кнопок влево вправо**************************
        if (PlayerPrefs.GetInt("numberBall") == 0)
        {
            down.GetComponent<Button>().interactable = false;
        }
        else
        {
            down.GetComponent<Button>().interactable = true;
        }
        if (PlayerPrefs.GetInt("numberBall") == 6)
        {
            next.GetComponent<Button>().interactable = false;
        }
        else
        {
            next.GetComponent<Button>().interactable = true;
        }

//************************************Работа кнопки выбрать мяч******************************************
        if (PlayerPrefs.GetInt("numberBall") == PlayerPrefs.GetInt("selectBall"))
        {
            select.GetComponent<Button>().interactable = false;
            oKay.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0.09f, 1f);
           
        }
        else if (PlayerPrefs.GetInt("numberBall") == 0)
        {
            downText.GetComponent<Text>().text = "";
            select.GetComponent<Button>().interactable = true;
            buttonText.GetComponent<Text>().text = "Выбрать мяч";
        }
        else if (PlayerPrefs.GetInt("numberBall") == 1)
        {
            downText.GetComponent<Text>().text = "Получите мяч за просмотр рекламы";
            if (PlayerPrefs.GetInt("getBall1") == 0)
            {
                buttonText.GetComponent<Text>().text = "Получить мяч";
            }
            else if (PlayerPrefs.GetInt("getBall1") != 0)
            {
                buttonText.GetComponent<Text>().text = "Выбрать мяч";
            }
            select.GetComponent<Button>().interactable = true;

        }
        else if (PlayerPrefs.GetInt("numberBall") == 2 & PlayerPrefs.GetInt("openBall") >= 5)
        {
            downText.GetComponent<Text>().text = "Пройдите 5 уровней на 3 звезды";
            buttonText.GetComponent<Text>().text = "Выбрать мяч";
            select.GetComponent<Button>().interactable = true;
           
        }
        else if (PlayerPrefs.GetInt("numberBall") == 3 & PlayerPrefs.GetInt("openBall") >= 15)
        {
            downText.GetComponent<Text>().text = "Пройдите 15 уровней на 3 звезды";
            select.GetComponent<Button>().interactable = true;
            buttonText.GetComponent<Text>().text = "Выбрать мяч";
        }
        else if (PlayerPrefs.GetInt("numberBall") == 4)
        {
            downText.GetComponent<Text>().text = "Получите мяч за просмотр рекламы";
            select.GetComponent<Button>().interactable = true;
            if (PlayerPrefs.GetInt("getBall2") == 0)
            {
                buttonText.GetComponent<Text>().text = "Получить мяч";
            }
        }
        else if (PlayerPrefs.GetInt("numberBall") == 5 & PlayerPrefs.GetInt("openBall") >= 25)
        {
            downText.GetComponent<Text>().text = "Пройдите 25 уровней на 3 звезды";
            select.GetComponent<Button>().interactable = true;
            buttonText.GetComponent<Text>().text = "Выбрать мяч";
        }
        else if (PlayerPrefs.GetInt("numberBall") == 6 & PlayerPrefs.GetInt("openBall") >= 35)
        {
            downText.GetComponent<Text>().text = "Пройдите 35 уровней на 3 звезды";
            select.GetComponent<Button>().interactable = true;
            buttonText.GetComponent<Text>().text = "Выбрать мяч";
        }
        else 
        {
            
            select.GetComponent<Button>().interactable = false;
        }

//******************************************текст*****************************************
         if (PlayerPrefs.GetInt("numberBall") == 0)
        {
            downText.GetComponent<Text>().text = "";
            
        }
        else if (PlayerPrefs.GetInt("numberBall") == 1)
        {
            downText.GetComponent<Text>().text = "Получите мяч за просмотр рекламы";
          
        }
        else if (PlayerPrefs.GetInt("numberBall") == 2 )
        {
            downText.GetComponent<Text>().text = "Пройдите 5 уровней на 3 звезды";
        }
        else if (PlayerPrefs.GetInt("numberBall") == 3 )
        {
            downText.GetComponent<Text>().text = "Пройдите 15 уровней на 3 звезды";
        }
        else if (PlayerPrefs.GetInt("numberBall") == 4)
        {
            downText.GetComponent<Text>().text = "Получите мяч за просмотр рекламы";
        }
        else if (PlayerPrefs.GetInt("numberBall") == 5 )
        {
            downText.GetComponent<Text>().text = "Пройдите 25 уровней на 3 звезды";
        }
        else if (PlayerPrefs.GetInt("numberBall") == 6 )
        {
            downText.GetComponent<Text>().text = "Пройдите 35 уровней на 3 звезды";
        }
    }
}
