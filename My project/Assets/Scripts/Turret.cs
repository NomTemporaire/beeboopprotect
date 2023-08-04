using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public int rate;
    public int nb;
    public int range;
    private int etape;
    public int vitesseBullet;
    public int degatBullet;

    private Controller control;

    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        etape = 0;
        control = GameObject.Find("Controller").GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!control.pause)
        {
            etape++;
            if (etape >= rate)
            {
                GameObject target = null;
                float minDist = float.MaxValue;
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    Vector3 dist = obj.transform.position - transform.position;
                    if (dist.magnitude <= range && dist.magnitude < minDist && (obj.transform.position.magnitude > 6 && dist.magnitude > 0.5))
                    {
                        target = obj;
                        minDist = dist.magnitude;
                    }
                }
                if (target != null)
                {
                    for (int i = 0; i < nb; i++)
                    {
                        GameObject obj = Instantiate(prefab, Vector3.up * 7.1f, new Quaternion(1, 1, 1, 1)) as GameObject;
                        Bullet objB = obj.GetComponent<Bullet>();
                        objB.target = target;
                        objB.vitesse = vitesseBullet;
                        objB.degat = degatBullet;
                        if (nb > 1)
                        {
                            Vector3 offset = Vector3.left + (Vector3.right * 2 / (nb - 1)) * i;
                            obj.transform.position += offset;
                        }
                        obj.transform.RotateAround(Vector3.zero, Vector3.forward, transform.eulerAngles.z);
                    }
                    etape = 0;
                }

            }
        }
    }
}
