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
    public GameObject normalPrefab;
    public GameObject rapidePrefab;
    public GameObject tankPrefab;
    public GameObject hpPrefab;
    private List<GameObject> hp;
    public int range;
    public int score;
    private int truescore;
    public int hpStart;
    private int nbSummon;
    public bool pause;
    private GameObject hpList;

    void Start()
    {
        pause = false;
        nbSummon = 0;
        hpList = GameObject.Find("HPList");
        hp = new List<GameObject>();
        for(int i = 0; i<hpStart; i++)
        {
            AddHP();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            if (respawnTimer < spawnTime)
            {
                respawnTimer++;
            }
            else
            {
                if (nbEnemies < spawnLimit)
                {
                    respawnTimer = 0;
                    spawnTime--;
                    if (spawnTime == 0)
                    {
                        spawnTime = 30;
                        spawnLimit++;
                    }
                    float angle1 = Random.Range(-Mathf.PI / 2, Mathf.PI / 2);
                    float angle2 = Random.Range(-Mathf.PI / 2, Mathf.PI / 2);
                    float angle3 = Random.Range(-Mathf.PI / 2, Mathf.PI / 2);
                    float angle = (angle1 + angle2 + angle3) / 3;
                    float minus = Random.Range(-1, 1);
                    if (minus < 0)
                    {
                        angle += Mathf.PI;
                    }
                    if (nbSummon % 6 == 0)
                    {
                        GameObject obj = Instantiate(rapidePrefab, new Vector3(range * Mathf.Cos(angle), range * Mathf.Sin(angle), 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                        obj.transform.Rotate(0, 0, (angle * 180) / Mathf.PI);
                    }
                    else
                    {
                        if (nbSummon % 15 == 0)
                        {
                            GameObject obj = Instantiate(tankPrefab, new Vector3(range * Mathf.Cos(angle), range * Mathf.Sin(angle), 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                            obj.transform.Rotate(0, 0, (angle * 180) / Mathf.PI);
                        }
                        else
                        {
                            GameObject obj = Instantiate(normalPrefab, new Vector3(range * Mathf.Cos(angle), range * Mathf.Sin(angle), 0), new Quaternion(0, 0, 0, 0)) as GameObject;
                            obj.transform.Rotate(0, 0, (angle * 180) / Mathf.PI);
                        }
                    }
                    nbEnemies++;
                    nbSummon++;
                }
            }
        }
    }

    public void deleteEnemy(GameObject enemy, bool attaque, int reward)
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
                Debug.Log("Vous avez vaincu " + truescore + " ennemis.");
            }
        }
        else
        {
            score += reward;
            truescore++;
        }
    }

    public void PauseGame()
    {
        pause = !pause;
    }

    public void AddHP()
    {
        GameObject obj = Instantiate(hpPrefab, new Vector3(-38 + 1.1f * hp.Count, 18, 10f), new Quaternion(0, 0, 0, 0)) as GameObject;
        obj.transform.parent = hpList.transform;
        hp.Add(obj);
    }
}
