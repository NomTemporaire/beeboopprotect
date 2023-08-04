using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    // Start is called before the first frame update
    public float vitesse;

    private Controller control;

    void Start()
    {
        control = GameObject.Find("Controller").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!control.pause)
        {
            if (Input.GetKey("left"))
            {
                transform.Rotate(0, 0, 0.2f * vitesse);
            }
            if (Input.GetKey("right"))
            {
                transform.Rotate(0, 0, -0.2f * vitesse);
            }
        }
    }
}
