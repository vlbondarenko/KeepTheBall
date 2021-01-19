using UnityEngine;
using System.Collections;

public class Partical : MonoBehaviour {
    private ParticleSystem ps;

    private void Start()
    {
        ps = (ParticleSystem)GetComponent(typeof(ParticleSystem));
    }

    private void Update()
    {
        if (ps)
            if (!ps.IsAlive())
                Destroy(gameObject);
    }
}
