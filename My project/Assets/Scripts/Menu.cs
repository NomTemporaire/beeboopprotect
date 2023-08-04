using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private Controller control;
    private Ring ring;
    private Turret mainTurret;
    private GameObject secTurret1;
    private GameObject secTurret2;
    public GameObject turretPrefab;
    public TextMeshProUGUI scoreTxt;
    public Button btnUPG1;
    private int coutUPG1;
    public Button btnUPG2;
    private int coutUPG2;
    public Button btnUPG3;
    private int coutUPG3;

    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Controller").GetComponent<Controller>();
        ring = GameObject.Find("Orbital Ring").GetComponent<Ring>();
        mainTurret = ring.transform.GetChild(0).GetComponent<Turret>();
        coutUPG1 = 1;
        coutUPG2 = 1;
        coutUPG3 = 20;
    }

    public void Pause()
    {
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        scoreTxt.GetComponent<TextMeshProUGUI>().text = "Score : " + control.score;
        if (control.score < coutUPG1)
            btnUPG1.interactable = false;
        else
            btnUPG1.interactable = true;

        if (control.score < coutUPG2)
            btnUPG2.interactable = false;
        else
            btnUPG2.interactable = true;

        if (control.score < coutUPG3)
            btnUPG3.interactable = false;
        else
            btnUPG3.interactable = true;
    }

    public void UPGRateMainTurret()
    {
        control.score -= coutUPG1;
        coutUPG1 += 1;
        mainTurret.rate--;
        btnUPG1.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer la tourelle :\r\nCadence de tir\r\nCout : "+coutUPG1;
        UpdateInfo();
    }

    public void UPGRotateRing()
    {
        control.score -= coutUPG2;
        coutUPG2 += 1;
        ring.vitesse += 0.2f;
        btnUPG2.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer l'anneau :\r\nVitesse de rotation\r\nCout : " + coutUPG2;
        UpdateInfo();
    }

    public void UPGHPIncrease()
    {
        control.score -= coutUPG3;
        coutUPG3 += 5;
        control.AddHP();
        btnUPG3.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Gagner un point de vie\r\nCout : " + coutUPG3;
        UpdateInfo();
    }
}
