using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShotgun : MonoBehaviour
{

    private Controller control;
    public int rate;
    public int nb;
    public int range;
    public float angle;
    public int etape;
    public int vitesseBullet;
    public int degatBullet;
    private float correctAngle;

    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        etape = 0;
        nb = 5;
        rate = 300;
        range = 5;
        angle = Mathf.PI / 2;
        control = GameObject.Find("Controller").GetComponent<Controller>();
        correctAngle = Mathf.PI / 4;
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
                    bool tir = true;
                    Vector3 toZero = target.transform.position - transform.position;
                    float angleTarget = Mathf.Atan2(toZero.y, toZero.x);
                    if(transform.position.x<0)
                    {
                        if (Mathf.Cos(angleTarget) > Mathf.Cos(Mathf.PI + correctAngle))
                        {
                            if(Mathf.PI - angleTarget<0)
                            {
                                if (angleTarget%(Mathf.PI*2) < Mathf.PI + correctAngle + angle/2)
                                    angleTarget = Mathf.PI + correctAngle;
                                else
                                    tir = false;
                            }
                            else
                            {
                                if (angleTarget%(Mathf.PI * 2) > Mathf.PI - correctAngle - angle/2)
                                    angleTarget = Mathf.PI - correctAngle;
                                else
                                    tir = false;
                            }
                        }
                    }
                    else
                    {
                        if (Mathf.Cos(angleTarget) < Mathf.Cos(correctAngle))
                        {
                            if(angleTarget>Mathf.PI*2)
                                angleTarget -= Mathf.PI*2;
                            if (angleTarget < 0)
                            {
                                if (angleTarget < -correctAngle - angle / 2)
                                    angleTarget = -Mathf.PI / 4;
                                else
                                    tir = false;
                            }
                            else
                            {
                                if (angleTarget % (Mathf.PI * 2) < correctAngle + angle / 2)
                                    angleTarget = Mathf.PI / 4;
                                else
                                    tir = false;
                            }
                        }
                    }
                    if(tir)
                    {
                        for (int i = 0; i < nb; i++)
                        {
                            int j = i - (int)Mathf.Floor(nb / 2);
                            float bulletAngle = angleTarget - j * angle / nb;
                            Vector3 direct = new Vector3(Mathf.Cos(bulletAngle), Mathf.Sin(bulletAngle), 0);
                            GameObject obj = Instantiate(prefab, transform.position + direct * 0.2f, new Quaternion(1, 1, 1, 1)) as GameObject;
                            BulletSG objB = obj.GetComponent<BulletSG>();
                            objB.vitesse = vitesseBullet;
                            objB.degat = degatBullet;
                            objB.direction = direct;
                            objB.range = range;
                        }
                        etape = 0;
                    }
                }

            }
        }
    }
}
