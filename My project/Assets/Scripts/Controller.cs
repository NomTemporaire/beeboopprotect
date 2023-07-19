using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public int respawnTimer;
    public int spawnTime;
    public int spawnLimit;
    public int nbEnemies;
    public GameObject prefab;
    public int range;

    void Start()
    {
        respawnTimer = 0;
        spawnTime = 200;
        spawnLimit = 10;
        nbEnemies = 0;
        range = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if(respawnTimer < spawnTime)
        {
            respawnTimer++;
        }
        else
        {
            if(nbEnemies < spawnLimit)
            {
                respawnTimer = 0;
                spawnTime--;
                float angle = Random.Range(0, Mathf.PI * 2);
                GameObject obj = Instantiate(prefab, new Vector3(range*Mathf.Cos(angle),range*Mathf.Sin(angle),0), new Quaternion(0, 0, 0, 0)) as GameObject;
                obj.transform.Rotate(0, 0, (angle*180)/Mathf.PI);
                nbEnemies++;
            }
        }
    }

    public void deleteEnemy(GameObject enemy)
    {
        nbEnemies--;
    }
}
