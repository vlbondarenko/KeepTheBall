using UnityEngine;
using System.Collections;

public class ConveerMenu : MonoBehaviour {
    public float tilt;

    void Start () {
	
	}
	
	
	void Update () {
        transform.Rotate(Vector3.forward * Time.deltaTime * tilt);
    }
}
