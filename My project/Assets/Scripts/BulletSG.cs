using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSG : MonoBehaviour
{

    public Vector3 direction;

    public int range { get; set; }
    public int vitesse { get; set; }
    public int degat { get; set; }

    private float dep;

    private Controller control;
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Controller").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!control.pause)
        {
            transform.position += direction * 0.2f * vitesse;
            dep += 0.2f * vitesse;
            if(dep>=range)
            {
                Destroy(gameObject);
            }
        }
    }
}
