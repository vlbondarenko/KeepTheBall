using UnityEngine;
using System.Collections;

public class TextAnimation: MonoBehaviour
{
    public Collider2D[] all;
    float timer = 0;
   public int sRavn = 0;
    int inDex = 0;
 

    float Timer()
    {
        for (int i = 1; i < 3; i++)
        {
            timer += Time.deltaTime;
        }
        return timer;
    }
    void Update()
    {
        if (Timer() > sRavn)
        {
            sRavn += 10;
            all[inDex].GetComponent<Rigidbody2D>().isKinematic = false;
            inDex += 1;
        }
   
    }
}
