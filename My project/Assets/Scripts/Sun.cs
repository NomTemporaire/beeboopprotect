using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    // Start is called before the first frame update
    public int vitesse;

    void Start()
    {
        vitesse = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0.05f * vitesse, 0f);
    }
}
