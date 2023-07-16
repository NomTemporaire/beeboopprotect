using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorDist = target.transform.position - transform.position;
        transform.position += vectorDist / (vectorDist.magnitude*10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject) ;
    }
}
