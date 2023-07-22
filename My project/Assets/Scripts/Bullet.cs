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
        if (target != null)
        {
            Vector3 vectorDist = target.transform.position - transform.position;
            transform.position += vectorDist / (vectorDist.magnitude * 10);
        }
        else
        {
            float minDist = float.MaxValue;
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Vector3 dist = obj.transform.position - transform.position;
                if (dist.magnitude <= 4 && dist.magnitude < minDist)
                {
                    target = obj;
                    minDist = dist.magnitude;
                }
            }
            if(target==null)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject) ;
    }
}
