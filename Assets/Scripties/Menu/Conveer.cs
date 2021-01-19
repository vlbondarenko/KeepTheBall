using UnityEngine;
using System.Collections;

public class Conveer : MonoBehaviour { 
    public float tilt;
    public Interface reload;
    public string numLev;
   public void Awake()
    {
     
        if (PlayerPrefs.GetInt(reload.first) == 0)
        {
            PlayerPrefs.SetFloat(numLev + "u", tilt);
            PlayerPrefs.Save();
        }
    }
    
    void Start()
    {
        tilt = PlayerPrefs.GetFloat(numLev + "u");
    }

    void Update () {

       

        transform.Rotate(Vector3.forward * Time.deltaTime * tilt);
        if (reload.raz == true)
        {
            PlayerPrefs.SetFloat(numLev + "u", tilt);
            PlayerPrefs.Save();
        }
        else if (reload.raz1 == true)
        {
            PlayerPrefs.SetFloat(numLev + "u", tilt);
            PlayerPrefs.Save();
        }
	
	}
}
