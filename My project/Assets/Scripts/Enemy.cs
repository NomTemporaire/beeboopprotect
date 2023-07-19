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

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Bullet"))
        {
            vie--;
            if (vie <= 0)
            {
                GameObject.Find("Controller").GetComponent<Controller>().deleteEnemy(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
