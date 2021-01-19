using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {
    public ParticleSystem star;
    public GamePlay closeF;
    public GameObject sample;
    public float tilt;
    int i = 0;
    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Ball")//если шар соприкасается с звездой то к счетчику прибавляется 1
        {
            

            Instantiate(star, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Destroy(GetComponent<PolygonCollider2D>());
    }
        void Update()
    {
      
        transform.Rotate(Vector3.up * Time.deltaTime * tilt);
        if (closeF.cloSeF == true&&i==0&&closeF.starCollider==true)
        {
            CircleCollider2D component = sample.AddComponent<CircleCollider2D>();
            sample.GetComponent<CircleCollider2D>().isTrigger = true;
            i++;
        } 
    }

}
