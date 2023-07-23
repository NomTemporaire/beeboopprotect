using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int vie;
    public int vitesse;
    public int reward;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (-transform.position.normalized / 300)*vitesse;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Bullet"))
        {
            vie--;
            if (vie <= 0)
            {
                GameObject.Find("Controller").GetComponent<Controller>().deleteEnemy(gameObject, false, reward);
                Destroy(gameObject);
            }
        }
        if(collision.gameObject.tag.Equals("Player"))
        {
            GameObject.Find("Controller").GetComponent<Controller>().deleteEnemy(gameObject, true, 0);
            Destroy(gameObject);
        }
    }
}
