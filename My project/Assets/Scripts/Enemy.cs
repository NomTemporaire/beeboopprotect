using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int vie;
    public int vitesse;
    public int reward;
    private Controller control;
    public bool electric;
    private int electricTimer;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Controller").GetComponent<Controller>();
        electric = false;
        electricTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!control.pause)
            transform.position += (-transform.position.normalized / 300)*vitesse;
        if(electricTimer>0)
        {
            electricTimer--;
        }
        else
        {
            electric = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            if (collision.gameObject.name.Contains("ShotGun"))
            {
                vie -= collision.gameObject.GetComponent<BulletSG>().degat;
            }
            else
            {
                vie -= collision.gameObject.GetComponent<Bullet>().degat;
            }
            if (vie <= 0)
            {
                GameObject.Find("Controller").GetComponent<Controller>().deleteEnemy(gameObject, false, reward);
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameObject.Find("Controller").GetComponent<Controller>().deleteEnemy(gameObject, true, 0);
            Destroy(gameObject);
        }
    }

    public void TouchedByElectricArc(int bounce, int fork, float range, int dmg)
    {
        electric = true;
        electricTimer = 10;
        vie -= dmg;
        if (vie <= 0)
        {
            GameObject.Find("Controller").GetComponent<Controller>().deleteEnemy(gameObject, false, reward);
            Destroy(gameObject);
        }
        int f = fork+1;
        if(bounce > 0)
        {
            GameObject target = null;
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Vector3 dist = obj.transform.position - transform.position;
                if (dist.magnitude <= range && !obj.GetComponent<Enemy>().electric)
                {
                    target = obj;
                    float angleTarget = (Mathf.Atan2(dist.y, dist.x) - Mathf.PI / 2) * Mathf.Rad2Deg;
                    Vector3 pos = (target.transform.position + transform.position) / 2;
                    GameObject obj2 = Instantiate(prefab, pos + Vector3.forward * 0.3f, new Quaternion(0, 0, 0, 0)) as GameObject;
                    obj2.transform.localScale = new Vector3(0.2f, dist.magnitude, 0.05f);
                    obj2.transform.Rotate(new Vector3(0, 0, angleTarget));
                    target.GetComponent<Enemy>().TouchedByElectricArc(bounce - 1, fork, range, dmg);
                    f--;
                }
                if(f==0)
                    break;
            }
        }
    }
}
