using UnityEngine;
using System.Collections;

public class InteractiveMeny : MonoBehaviour {

    public InteractiveMeny Symbol;
    public int speed = 1000;
    public GameObject[] panels;
	
	void Start () {
	
	}


    void Update() {
        Vector3 cour = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Позиция курсора

        //*********************** Выбор объекта *************************************
        if (panels[0].activeSelf==false&& panels[1].activeSelf == false&& panels[2].activeSelf == false&& panels[3].activeSelf == false&& panels[4].activeSelf == false&& panels[5].activeSelf == false) {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Collider2D all = Physics2D.OverlapCircle((Vector2)cour, 0.3f);

                if (all.GetComponent<InteractiveMeny>())
                {
                    Symbol = all.GetComponent<InteractiveMeny>();
                }


            }
            if (Symbol != null)//предмет
            {
                Symbol.GetComponent<Rigidbody2D>().isKinematic = true;
                Symbol.transform.position = Vector2.MoveTowards(Symbol.transform.position, cour, Time.deltaTime * speed);

            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                if (Symbol != null)
                {

                    Symbol.GetComponent<Rigidbody2D>().isKinematic = false;
                    Symbol = null;
                }
            }
        }
    }
}
