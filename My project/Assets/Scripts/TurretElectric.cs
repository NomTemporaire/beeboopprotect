using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretElectric : MonoBehaviour
{
    private Controller control;
    public int rate;
    public int range;
    public int etape;
    public int degatBullet;
    public int nbBounce;
    public int nbFork;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        etape = 0;
        rate = 300;
        range = 10;
        nbBounce = 1;
        nbFork = 0;
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
                float angle = Mathf.Deg2Rad * (transform.eulerAngles.z+90);
                Vector3 cannon = new Vector3(Mathf.Cos(angle)*7,Mathf.Sin(angle)*7,0);
                GameObject target = null;
                float minDist = float.MaxValue;
                Vector3 toZero = Vector3.zero;
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    Vector3 dist = obj.transform.position - cannon;
                    if (dist.magnitude <= range && dist.magnitude < minDist && (obj.transform.position.magnitude > 6 && dist.magnitude > 0.5) && !obj.GetComponent<Enemy>().electric)
                    {
                        target = obj;
                        minDist = dist.magnitude;
                        toZero = dist;
                    }
                }
                if (target != null)
                {
                    float angleTarget = (Mathf.Atan2(toZero.y,toZero.x)-Mathf.PI/2)*Mathf.Rad2Deg;
                    Debug.Log("0: " + angleTarget);
                    Vector3 pos = (target.transform.position + cannon)/2;
                    GameObject obj = Instantiate(prefab, pos+Vector3.forward*0.3f, new Quaternion(0, 0, 0, 0)) as GameObject;
                    obj.transform.localScale = new Vector3(0.2f, minDist, 0.01f);
                    obj.transform.Rotate(new Vector3(0,0,angleTarget));
                    target.GetComponent<Enemy>().TouchedByElectricArc(nbBounce, nbFork, range / 2, degatBullet);
                    etape = 0;
                }
            }
        }
    }
}
