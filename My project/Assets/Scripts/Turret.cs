using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public int rate;
    public int nb;
    public int range;
    public int etape;

    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        etape = 0;
    }

    // Update is called once per frame
    void Update()
    {
        etape++;
        if(etape>=rate)
        {
            GameObject target = null;
            float minDist = float.MaxValue;
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Vector3 dist = obj.transform.position - transform.position;
                if (dist.magnitude <= range && dist.magnitude < minDist && (obj.transform.position.magnitude > 6 && dist.magnitude>0.5))
                {
                    target = obj;
                    minDist = dist.magnitude;
                }
            }
            if (target!=null)
            {
                for (int i = 0; i < nb; i++)
                {
                    GameObject obj = Instantiate(prefab, Vector3.up * 7.1f, new Quaternion(1, 1, 1, 1)) as GameObject;
                    Bullet objB = obj.GetComponent<Bullet>();
                    objB.target = target;
                    obj.transform.RotateAround(Vector3.zero, Vector3.forward, transform.eulerAngles.z);
                }
                etape = 0;
            }
            
        }
    }
}
