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
    public GameObject enemyPrefab;
    public GameObject hpPrefab;
    private List<GameObject> hp;
    public int range;
    public int score;
    public int hpStart;

    void Start()
    {
        hp = new List<GameObject>();
        for(int i = 0; i<hpStart; i++)
        {
            GameObject obj = Instantiate(hpPrefab, new Vector3(-27+0.6f*i,12, 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            obj.transform.position += new Vector3(2, 0, 0);
            hp.Add(obj);
        }
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
                float angle1 = Random.Range(-Mathf.PI / 2, Mathf.PI / 2);
                float angle2 = Random.Range(-Mathf.PI / 2, Mathf.PI / 2);
                float angle3 = Random.Range(-Mathf.PI / 2, Mathf.PI / 2);
                float angle = (angle1 + angle2 + angle3) / 3;
                float minus = Random.Range(-1, 1);
                if (minus < 0)
                {
                    angle += Mathf.PI;
                }
                GameObject obj = Instantiate(enemyPrefab, new Vector3(range * Mathf.Cos(angle), range * Mathf.Sin(angle), 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                obj.transform.Rotate(0, 0, (angle * 180) / Mathf.PI);
                nbEnemies++;
            }
        }
    }

    public void spawnEnemy()
    {
        
    }

    public void deleteEnemy(GameObject enemy, bool attaque)
    {
        nbEnemies--;
        if(attaque)
        {
            GameObject obj = hp.ElementAt(hp.Count - 1);
            hp.Remove(obj);
            Destroy(obj);
            if (hp.Count == 0)
            {
                foreach (GameObject play in GameObject.FindGameObjectsWithTag("Player"))
                {
                    Destroy(play);
                }
                Debug.Log("Perdu !");
                Debug.Log("Vous avez vaincu " + score + " ennemis.");
            }
        }
        else
        {
            score += 1;
        }
    }
}
