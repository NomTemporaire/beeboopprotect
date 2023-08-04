using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    // Start is called before the first frame update
    public int vitesse;

    private Controller control;

    void Start()
    {
        vitesse = 1;
        control = GameObject.Find("Controller").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!control.pause)
        {
            transform.Rotate(0.1f * vitesse, 0.2f * vitesse, -0.1f * vitesse);
        }
    }
}
