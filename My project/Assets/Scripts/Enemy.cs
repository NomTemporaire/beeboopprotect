using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int vie;

    // Start is called before the first frame update
    void Start()
    {
        vie = 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.position.normalized / 100;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Bullet"))
        {
            vie--;
            if (vie <= 0)
            {
                GameObject.Find("Controller").GetComponent<Controller>().deleteEnemy(gameObject, false);
                Destroy(gameObject);
            }
        }
        if(collision.gameObject.tag.Equals("Player"))
        {
            GameObject.Find("Controller").GetComponent<Controller>().deleteEnemy(gameObject, true);
            Destroy(gameObject);
        }
    }
}
