using UnityEngine;
using System.Collections;

public class Effector : MonoBehaviour {
    public GamePlay close;
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Bubble")//если шар соприкасается с звездой то к счетчику прибавляется 1
        {
            if (close.cloSeF == true)
            GetComponentInChildren<AreaEffector2D>().forceMagnitude = -3;

        }
    }
    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Bubble")//если шар соприкасается с звездой то к счетчику прибавляется 1
        {
            if (close.cloSeF == true)
                GetComponentInChildren<AreaEffector2D>().forceMagnitude = -3;

        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
