using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Predmets : MonoBehaviour {
    public Vector3 newPosition;
    public Transform newRotation;
    public string predName;
    public bool pref;
    public Interface reload;//переменная для определения первый раз ли запускалась игра;отработка нажатия на кнопку Again на панели финиша
    public int level;


    public void Start()
    {
        transform.position = new Vector3(PlayerPrefs.GetFloat(predName), PlayerPrefs.GetFloat(predName + "P"), transform.position.z);

        transform.Rotate(new Vector3(0, 0, PlayerPrefs.GetFloat(predName + "R")), Space.Self);

    }

    public void Awake()

    {
        if (PlayerPrefs.GetInt(reload.first)==0)
        {
            newPosition = transform.position;
            PlayerPrefs.SetFloat(predName, newPosition.x);
            PlayerPrefs.SetFloat(predName + "P", newPosition.y);
            PlayerPrefs.SetFloat(predName + "R", newRotation.eulerAngles.z);
            PlayerPrefs.Save();
        }
    }
    
    public void savePosition()
    {
        newPosition = transform.position;   
        PlayerPrefs.SetFloat(predName, newPosition.x); 
        PlayerPrefs.SetFloat(predName+"P", newPosition.y); 
        PlayerPrefs.SetFloat(predName+"R",newRotation.eulerAngles.z );      
        PlayerPrefs.Save();

    }



    void Update () {
        if (reload.raz == true)
        {
            savePosition();
            SceneManager.LoadScene(level);
        }
        if (reload.raz1 == true)
        {
            savePosition();
     
        }

    }
}
