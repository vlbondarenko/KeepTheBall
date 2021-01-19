using UnityEngine;
using System.Collections;

public class Tilt : MonoBehaviour {

    public float tilt;

    void Start()
    {

    }


    void Update()
    {
        transform.Rotate(Vector3.right * Time.deltaTime * tilt);
    }
}

