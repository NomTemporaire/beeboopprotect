using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    // Start is called before the first frame update
    public int vitesse;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("left"))
        {
            transform.Rotate(0, 0, 0.2f * vitesse);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(0, 0, -0.2f * vitesse);
        }
    }
}
