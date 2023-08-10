using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBullet : MonoBehaviour
{
    private int etape;
    // Start is called before the first frame update
    void Start()
    {
        etape = 0;
    }

    // Update is called once per frame
    void Update()
    {
        etape++;
        if(etape>=100)
            Destroy(gameObject);
    }
}
