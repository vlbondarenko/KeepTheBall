using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HintSystem : MonoBehaviour {
    public Text hintText;// количество подсказок на кнопке
    public int HintInt;//количество подсказок для хранения в реестре
    public int helpRaz;// первый ли раз запускается игра (0 если игра запускается впервые)
    public Button helpButton;// кнопка помощи
    public GameObject[] hints;// контуры (подсказки)
    public bool hint;//была ли нажата кнопка помощи
    public int n;//индекс контура в массиве
    public int i;// для цикла for
    public GamePlay closeF;//блокировка геймплея
    public GameObject help,help1;// панель подказок
    public GameObject[] pannels;
    public float startTime;
    public GameObject helpPannel;
    public string numLevel;
    public GameObject helpPanel_1;
    bool musOn;
    public string hintPref;
    public void OnClickHelp()//подсказка
    {
        if (HintInt != 0)
        {
            help.SetActive(true);
            closeF.cloSeF = true;
            musOn = true;
        }
       else if (HintInt == 0)// проверка наличия подсказок
        {
            help1.SetActive(true);
            closeF.cloSeF = true;
            musOn = true;
        }
    }
    public void OnClickCloseVideoPanel()
    {
        help1.SetActive(false);
        closeF.cloSeF = false;
        musOn = true;
    }
    public void yes()
    {
            n = PlayerPrefs.GetInt("n" +hintPref );
            HintInt -= 1;
            PlayerPrefs.SetInt("hint", HintInt);
            help.SetActive(false);         
            hint = true;
            i = 0;
            musOn = true;
    }
    public void no()
    {
      
        
            help.SetActive(false);
        closeF.cloSeF = false;
        musOn = true;
    }
     public void OnClickNext()
    { 
        helpPannel.SetActive(false);
        helpPanel_1.SetActive(true);
        PlayerPrefs.SetInt(numLevel, 1);
        musOn = true;
    }
   public void onClickClose()
    {
        helpPanel_1.SetActive(false);
        helpPannel.SetActive(false);
        PlayerPrefs.SetInt(numLevel, 1);
        musOn = true;
    }
    public void Awake()//*****************************************************************************
    {
        if (PlayerPrefs.GetInt("one") == 0)
        {
            PlayerPrefs.SetInt("hint", 10);
        }
    }
    void Start ()//*******************************************************
    {
      
        helpRaz = 1;
        PlayerPrefs.SetInt("one", helpRaz);
    }
	void Update ()//*********************************************************************************
    {

   
        HintInt = PlayerPrefs.GetInt("hint");
        hintText.text = HintInt.ToString();
        if (musOn == true && PlayerPrefs.GetString("Music") == "yes")
        {
            GameObject.Find("ClickAudio").gameObject.GetComponent<AudioSource>().Play();
            musOn = false;
        }
        if (Input.GetKeyDown(KeyCode.S))//************ ненужное
        {
            PlayerPrefs.SetInt("one", 0);
            PlayerPrefs.SetInt(numLevel, 0);
        }
        if (hint == true)//появление подсказки
        {    hint = false;
             closeF.cloSeF = false;
        
            if (n == hints.Length-1)
            {
                PlayerPrefs.SetInt("n" + hintPref, 0);
            }    
                hints[n].transform.position = new Vector3(hints[n].transform.position.x, hints[n].transform.position.y, 0);
                n += 1;
                hints[n].transform.position = new Vector3(hints[n].transform.position.x, hints[n].transform.position.y, 0);
            if (n < hints.Length - 1)
                {
                PlayerPrefs.SetInt("n" + hintPref, n);
                PlayerPrefs.Save();
                 }

           

          
           
        } 
//*************************************************************************
      
        if (Input.GetKeyDown(KeyCode.Escape) && pannels[0].activeSelf == false && pannels[1].activeSelf == false && pannels[2].activeSelf == false && help.activeSelf == true)
        {
            closeF.cloSeF = false;
            help.SetActive(false);
        } 
        if (PlayerPrefs.GetInt(numLevel) == 0)
        {
            startTime += Time.deltaTime;
        }
        if (PlayerPrefs.GetInt(numLevel) == 0 && startTime > 2)
        {
            helpPannel.SetActive(true); 
        }       
    }
}
