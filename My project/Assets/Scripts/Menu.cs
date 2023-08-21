using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private Controller control;
    private Turret mainTurret;
    private List<GameObject> TurretSG;
    private List<GameObject> TurretElec;
    public GameObject turretSGPrefab;
    public GameObject turretElecPrefab;
    public TextMeshProUGUI scoreTxt;
    public Button btnTurretRate;
    private int coutTurretRate;
    public Button btnTurrentRotate;
    private int coutTurretRotate;
    public Button btnHPIncrease;
    private int coutHPIncrease;
    public int coutAddTurretSG;
    public Button btnTurretRange;
    private int coutTurretRange;
    public Button btnSGRate;
    private int coutSGRate;
    public Button btnSGRange;
    private int coutSGRange;
    public Button btnSGAngle;
    private int coutSGAngle;
    private int niveauAngle;
    public int coutAddTurretElec;
    public Button btnElecRange;
    private int coutElecRange;
    public Button btnElecRate;
    private int coutElecRate;
    public Button btnElecBounce;
    private int coutElecBounce;
    public Button btnElecFork;
    private int coutElecFork;
    public int coutSGSup;
    public int coutElecSup;
    private float amelAngle;
    private bool stopSGRate = false;
    private bool stopSGAngle = false;
    private bool stopElecRate = false;
    private bool stopElecBounce = false;
    private bool stopElecFork = false;

    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Controller").GetComponent<Controller>();
        mainTurret = GameObject.Find("Turret").GetComponent<Turret>();
        coutTurretRate = 1;
        coutTurretRotate = 1;
        coutHPIncrease = 20;
        coutSGSup = 0;
        coutElecSup = 0;
        coutAddTurretSG = 30;
        coutTurretRange = 1;
        coutSGRate = 1;
        coutSGRange = 1;
        coutSGAngle = 3;
        coutAddTurretElec = 30;
        coutElecRange = 1;
        coutElecRate = 1;
        coutElecBounce = 10;
        coutElecFork = 30;
        amelAngle = Mathf.PI / 8;
        TurretSG = new List<GameObject>();
        TurretElec = new List<GameObject>();
        btnTurretRate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer la tourelle :\r\nCadence de tir\r\nCout : " + coutTurretRate;
        btnTurrentRotate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer la tourelle :\r\nVitesse de rotation\r\nCout : " + coutTurretRotate;
        btnHPIncrease.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Gagner un point de vie\r\nCout : " + coutHPIncrease;
        btnTurretRange.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer la tourelle :\r\nPortée\r\nCout : " + coutTurretRange;
        btnSGRate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer les fusils à pompe :\r\nCadence de tir\r\nCout : " + coutSGRate * TurretSG.Count;
        btnSGRange.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer les fusils à pompe :\r\nPortée\r\nCout : " + coutSGRange * TurretSG.Count;
        btnSGAngle.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer les fusils à pompe :\r\nAngle et/ou nombre de projectiles\r\nCout : " + coutSGAngle * TurretSG.Count;
        btnElecRange.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer les arcs électriques :\r\nPortée et Portée des rebonds\r\nCout : " + coutElecRange * TurretElec.Count;
        btnElecRate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer les arcs électriques :\r\nCadence de tir\r\nCout : " + coutElecRate * TurretElec.Count;
        btnElecBounce.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer les arcs électriques :\r\nNombre de rebonds\r\nCout : " + coutElecBounce * TurretElec.Count;
        btnElecFork.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer les arcs électriques :\r\nNombre de séparations\r\nCout : " + coutElecFork * TurretElec.Count;
        niveauAngle = 1;
    }

    public void Pause()
    {
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        scoreTxt.GetComponent<TextMeshProUGUI>().text = "Argent : " + control.score;
        if (control.score < coutTurretRate || mainTurret.rate<=5)
            btnTurretRate.interactable = false;
        else
            btnTurretRate.interactable = true;

        if (control.score < coutTurretRotate)
            btnTurrentRotate.interactable = false;
        else
            btnTurrentRotate.interactable = true;

        if (control.score < coutHPIncrease)
            btnHPIncrease.interactable = false;
        else
            btnHPIncrease.interactable = true;


        if (control.score < coutTurretRange)
            btnTurretRange.interactable = false;
        else
            btnTurretRange.interactable = true;

        if (control.score < coutSGRate * TurretSG.Count || TurretSG.Count == 0 || stopSGRate)
            btnSGRate.interactable = false;
        else
            btnSGRate.interactable = true;

        if (control.score < coutSGRange * TurretSG.Count || TurretSG.Count == 0)
            btnSGRange.interactable = false;
        else
            btnSGRange.interactable = true;

        if (control.score < coutSGAngle * TurretSG.Count || TurretSG.Count == 0 || niveauAngle > 9 || stopSGAngle)
            btnSGAngle.interactable = false;
        else
            btnSGAngle.interactable = true;


        if (control.score < coutElecRate * TurretElec.Count || TurretElec.Count == 0 || stopElecRate)
            btnElecRate.interactable = false;
        else
            btnElecRate.interactable = true;

        if (control.score < coutElecRange * TurretElec.Count || TurretElec.Count == 0)
            btnElecRange.interactable = false;
        else
            btnElecRange.interactable = true;

        if (control.score < coutElecBounce * TurretElec.Count || TurretElec.Count == 0 || stopElecBounce)
            btnElecBounce.interactable = false;
        else
            btnElecBounce.interactable = true;

        if (control.score < coutElecFork * TurretElec.Count || TurretElec.Count == 0 || stopElecFork)
            btnElecFork.interactable = false;
        else
            btnElecFork.interactable = true;
        btnTurretRate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer la tourelle :\r\nCadence de tir\r\nCout : " + coutTurretRate;
        btnTurrentRotate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer la tourelle :\r\nVitesse de rotation\r\nCout : " + coutTurretRotate;
        btnHPIncrease.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Gagner un point de vie\r\nCout : " + coutHPIncrease;
        btnTurretRange.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer la tourelle :\r\nPortée\r\nCout : " + coutTurretRange;
        btnSGRate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer les fusils à pompe :\r\nCadence de tir\r\nCout : " + coutSGRate * TurretSG.Count;
        btnSGRange.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer les fusils à pompe :\r\nPortée\r\nCout : " + coutSGRange * TurretSG.Count;
        btnSGAngle.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer les fusils à pompe :\r\nAngle et/ou nombre de projectiles\r\nCout : " + coutSGAngle * TurretSG.Count;
        btnElecRange.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer les arcs électriques :\r\nPortée et Portée des rebonds\r\nCout : " + coutElecRange * TurretElec.Count;
        btnElecRate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer les arcs électriques :\r\nCadence de tir\r\nCout : " + coutElecRate * TurretElec.Count;
        btnElecBounce.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer les arcs électriques :\r\nNombre de rebonds\r\nCout : " + coutElecBounce * TurretElec.Count;
        btnElecFork.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer les arcs électriques :\r\nNombre de séparations\r\nCout : " + coutElecFork * TurretElec.Count;

    }

    public void UPGRateMainTurret()
    {
        control.score -= coutTurretRate;
        coutTurretRate += 1;
        mainTurret.rate--;
        btnTurretRate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer la tourelle :\r\nCadence de tir\r\nCout : "+coutTurretRate;
        UpdateInfo();
    }

    public void UPGRotateTurret()
    {
        control.score -= coutTurretRotate;
        coutTurretRotate += 1;
        mainTurret.vitesse += 0.2f;
        btnTurrentRotate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer la tourelle :\r\nVitesse de rotation\r\nCout : " + coutTurretRotate;
        UpdateInfo();
    }

    public void UPGHPIncrease()
    {
        control.score -= coutHPIncrease;
        coutHPIncrease += 5;
        control.AddHP();
        btnHPIncrease.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Gagner un point de vie\r\nCout : " + coutHPIncrease;
        UpdateInfo();
    }

    public void UPGNewSGTurret(int i)
    {
        control.score -= (coutAddTurretSG + coutSGSup);
        coutAddTurretSG += 0;
        GameObject turretSG = Instantiate(turretSGPrefab, Vector3.up * 6f, new Quaternion(0, 0, 0, 0)) as GameObject;
        turretSG.transform.RotateAround(Vector3.zero, Vector3.forward, i*45);
        TurretSG.Add(turretSG);
        TurretShotgun firstTurret = TurretSG.First().GetComponent<TurretShotgun>();
        TurretShotgun newTurret = turretSG.GetComponent<TurretShotgun>();
        newTurret.range = firstTurret.range;
        newTurret.nb = firstTurret.nb;
        newTurret.angle = firstTurret.angle;
        newTurret.rate = firstTurret.rate;
        UpdateInfo();
    }

    public void UPGRangeTurret()
    {
        control.score -= coutTurretRange;
        coutTurretRange += 1;
        mainTurret.range++;
        btnTurretRange.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Améliorer la tourelle :\r\nPortée\r\nCout : " + coutTurretRange;
        UpdateInfo();
    }

    public void UPGRangeSG()
    {
        control.score -= coutSGRange * TurretSG.Count;
        coutSGSup += coutSGRange;
        coutSGRange += 1;
        foreach(GameObject turretSG in TurretSG)
        {
            turretSG.GetComponent<TurretShotgun>().range++;
        }
        UpdateInfo();
    }

    public void UPGRateSG()
    {
        control.score -= coutSGRate * TurretSG.Count;
        coutSGSup += coutSGRate;
        coutSGRate += 1;
        int r = 0;
        foreach (GameObject turretSG in TurretSG)
        {
            turretSG.GetComponent<TurretShotgun>().rate--;
            r = turretSG.GetComponent<TurretShotgun>().rate;
        }
        if (r <= 20)
            stopSGRate = true;
        UpdateInfo();
    }

    public void UPGAngleSG()
    {
        control.score -= coutSGAngle * TurretSG.Count;
        foreach (GameObject turretSG in TurretSG)
        {
            float angle = turretSG.GetComponent<TurretShotgun>().angle;
            if(angle+amelAngle<Mathf.PI/2)
            {
                turretSG.GetComponent<TurretShotgun>().angle += amelAngle;
            }
            if(niveauAngle%2==0)
            {
                turretSG.GetComponent<TurretShotgun>().nb += 2;
            }
        }
        coutSGSup += coutSGAngle;
        coutSGAngle += 9;
        niveauAngle++;
        UpdateInfo();
    }

    public void UPGNewElecTurret(int i)
    {
        control.score -= (coutAddTurretElec + coutElecSup);
        GameObject turretElec = Instantiate(turretElecPrefab, Vector3.up * 6f, new Quaternion(0, 0, 0, 0)) as GameObject;
        turretElec.transform.RotateAround(Vector3.zero, Vector3.forward, 45*i);
        TurretElec.Add(turretElec);
        //TO DO - Améliorer nouvelle tourelle au niveau de la première
        TurretElectric firstTurret = TurretElec.First().GetComponent<TurretElectric>();
        TurretElectric newTurret = turretElec.GetComponent<TurretElectric>();
        newTurret.range = firstTurret.range;
        newTurret.rate = firstTurret.rate;
        newTurret.nbBounce = firstTurret.nbBounce;
        newTurret.nbFork = firstTurret.nbFork;
        UpdateInfo();
    }

    public void UPGRangeElec()
    {
        control.score -= coutElecRange * TurretElec.Count;
        coutElecSup += coutElecRange;
        coutElecRange += 1;
        foreach (GameObject turretElec in TurretElec)
        {
            turretElec.GetComponent<TurretElectric>().range++;
        }
        UpdateInfo();
    }

    public void UPGRateElec()
    {
        control.score -= coutElecRate * TurretElec.Count;
        coutElecSup += coutElecRate;
        coutElecRate += 1;
        int r = 0;
        foreach (GameObject turretElec in TurretElec)
        {
            turretElec.GetComponent<TurretElectric>().rate--;
            r = turretElec.GetComponent<TurretElectric>().rate;
        }
        if(r<=30)
        {
            stopElecRate = true;
        }
        UpdateInfo();
    }

    public void UPGBounceElec()
    {
        control.score -= coutElecBounce * TurretElec.Count;
        coutElecSup += coutElecBounce;
        coutElecBounce += 10;
        int b = 0;
        foreach (GameObject turretElec in TurretElec)
        {
            turretElec.GetComponent<TurretElectric>().nbBounce++;
            b = turretElec.GetComponent<TurretElectric>().nbBounce;
        }
        if (b >= 3)
        {
            stopElecBounce = true;
        }
        UpdateInfo();
    }

    public void UPGForkElec()
    {
        control.score -= coutElecFork * TurretElec.Count;
        coutElecSup += coutElecFork;
        coutElecFork += 10;
        int f = 0;
        foreach (GameObject turretElec in TurretElec)
        {
            turretElec.GetComponent<TurretElectric>().nbFork++;
            f = turretElec.GetComponent<TurretElectric>().nbFork;
        }
        if (f >= 1)
        {
            stopElecFork = true;
        }
        UpdateInfo();
    }

}
