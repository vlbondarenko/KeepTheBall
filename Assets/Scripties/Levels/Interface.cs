using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
//************************         Скрипт подсчета звезд        *********************
public class Interface : MonoBehaviour {

    public int starTarget3 = 3;
    public int starTarget22 = 3;  // 3 звезды  } переменные для сравнения количества собранных звезд с количеством звезд получаемых при прохождении уровня 
    public int starTarget2 = 2;// 2 звезды
    public int starTarget1 = 1;// 1 звезда
    public Image[] starScore; //массив спрайтов звезд для изменения их компонентов Color
    public Ball score;// количество собранных звезд в уровне
    public string keyName; //ключ для сохранения результата
    public GameObject pauSe; // панель паузы
    public Ball Panel; //переменная для доступа к панелям финиша и проигрыша
    public float speedTime;//скость времени
    public Predmets again;//метод сохранения позиции предметов
    public Komveer save;
    private static int loseCount = 0,adCount=0;
    public bool raz,raz1;//перезагрузка уровня
    public string first;//нужна при первом включении уровня
    public HintSystem help;// панель подказок
    public GamePlay closeF;// блокировка геймплея при появлении панели подсказок
    bool musOn,winOn;
    public int numLevel;
    public bool foncStop;



    public void OnClickPlay()//кнопка Play в меню паузы
    { closeF.cloSeF = false;
        pauSe.SetActive(false);
        Time.timeScale = speedTime;
        musOn = true;
    }

    public void OnClickElse()// кнопка Again на панеле финиша
    {

        raz = true;
        PlayerPrefs.SetInt(first, 1);
        PlayerPrefs.Save();
        musOn = true;
        loseCount++;
        if (PlayerPrefs.GetString("noAds") != "yes")
        {
        if (loseCount % 10 == 0  )
        {
            ShowAds();
          
        }
        }


    }

    public void OnClickNext(int level)//кнопка Next для перехода на следующий уровень
    {
        raz1 = true;
         loseCount++;
        PlayerPrefs.SetInt(first, 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(level);
        musOn = true;
        again.savePosition();
      
    }

    public void OnClickHome()//кнопка домой
    {
        raz1 = true;
       
        PlayerPrefs.SetInt(first, 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        musOn = true;
        again.savePosition();
     
    }
    public void OnClickPause()//кнопка паузы
    {if (pauSe.activeSelf == false && Panel.finishPanel.activeSelf == false && Panel.GameOver.activeSelf == false && help.help.activeSelf == false && help.helpPannel.activeSelf == false)
        {
            Time.timeScale = 0;// остановка времени
            pauSe.SetActive(true);
            closeF.cloSeF = true;
        }
        musOn = true;
    }

  public void ShowAds()
    {
        if (Advertisement.IsReady())
        {
            adCount++;
            Advertisement.Show("rewardedVideo",new ShowOptions() { resultCallback=HandleAdResult});
            Debug.Log("реклама просмотрена");
        }

    }

    private void HandleAdResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                if (adCount % 5 == 0)
                {
                    PlayerPrefs.SetInt("hint", PlayerPrefs.GetInt("hint") + 1);
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
    void Start()//************************************************************Start*****************************
    {

       
    }

    void Update ()//************************************************************Update*******************************
    {

        Debug.Log(PlayerPrefs.GetInt("openBall"));
       
        if (musOn == true && PlayerPrefs.GetString("Music") == "yes")
        {
            GameObject.Find("ClickAudio").gameObject.GetComponent<AudioSource>().Play();
            musOn = false;
        }
        if (pauSe.activeSelf == false)
        {
            Time.timeScale = speedTime;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && pauSe.activeSelf == false && Panel.finishPanel.activeSelf == false && Panel.GameOver.activeSelf == false&& help.help.activeSelf == false&&help.helpPannel.activeSelf==false&& help.help1.activeSelf == false)// панель паузы
        {
            Time.timeScale=0;// остановка времени
            pauSe.SetActive(true);
            closeF.cloSeF = true;

        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pauSe.activeSelf == true)
        {
            Time.timeScale = speedTime;
            pauSe.SetActive(false);
            closeF.cloSeF = false;
            
        }
      
    
        if (score.finishPanel.activeSelf)
        {
            if ( PlayerPrefs.GetString("Music") == "yes"&&winOn==false)
            {
                GameObject.Find("Audio_Win").gameObject.GetComponent<AudioSource>().Play();
                winOn = true;
               
            }
            if (score.starInt == starTarget3)
            {
                starScore[0].color = new Color(starScore[0].color.r, starScore[0].color.g, starScore[0].color.b, 255);
                starScore[1].color = new Color(starScore[1].color.r, starScore[1].color.g, starScore[1].color.b, 255);
                starScore[2].color = new Color(starScore[2].color.r, starScore[2].color.g, starScore[2].color.b, 255);
                if (PlayerPrefs.GetInt(keyName) != 3)
                {
                    PlayerPrefs.SetInt("openBall", PlayerPrefs.GetInt("openBall") + 1);
                    PlayerPrefs.Save();
                }
                PlayerPrefs.SetInt(keyName, 3);// сохранение количества звезд в реестре
                PlayerPrefs.Save();
               
                
            }
            if (score.starInt == starTarget2)
            {
                starScore[0].color = new Color(starScore[0].color.r, starScore[0].color.g, starScore[0].color.b, 255);
                starScore[1].color = new Color(starScore[1].color.r, starScore[1].color.g, starScore[1].color.b, 255);

                if (PlayerPrefs.GetInt(keyName)!= 3)
                {
                    PlayerPrefs.SetInt(keyName, 2);
                    PlayerPrefs.Save();
                }

            }
            else if (score.starInt == starTarget22)
            {
                starScore[0].color = new Color(starScore[0].color.r, starScore[0].color.g, starScore[0].color.b, 255);
                starScore[1].color = new Color(starScore[1].color.r, starScore[1].color.g, starScore[1].color.b, 255);

                if (PlayerPrefs.GetInt(keyName) != 3)
                {
                    PlayerPrefs.SetInt(keyName, 2);
                    PlayerPrefs.Save();
                }

            }
            if (score.starInt == starTarget1)
            {
                starScore[0].color = new Color(starScore[0].color.r, starScore[0].color.g, starScore[0].color.b, 255);
                if (PlayerPrefs.GetInt(keyName) != 3&& PlayerPrefs.GetInt(keyName) !=2)
                {
                    PlayerPrefs.SetInt(keyName, 1);
                    PlayerPrefs.Save();
                }
               
            }
            if (raz == true)
            {
                SceneManager.LoadScene(numLevel);
            }
        }


    }
}
