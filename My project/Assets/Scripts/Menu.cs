using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private Controller control;
    private Turret mainTurret;
    private GameObject TurretSG1;
    private GameObject TurretSG2;
    public GameObject turretSGPrefab;
    public GameObject turretElecPrefab;
    private GameObject TurretElec1;
    private GameObject TurretElec2;
    private GameObject TurretElec3;
    private GameObject TurretElec4;
    public TextMeshProUGUI scoreTxt;
    public Button btnTurretRate;
    private int coutTurretRate;
    public Button btnTurrentRotate;
    private int coutTurretRotate;
    public Button btnHPIncrease;
    private int coutHPIncrease;
    public Button btnAddTurretSG;
    private bool BoolAddTurretSG;
    private int coutAddTurretSG;
    public Button btnTurretRange;
    private int coutTurretRange;
    public Button btnSGRate;
    private int coutSGRate;
    public Button btnSGRange;
    private int coutSGRange;
    public Button btnSGAngle;
    private int coutSGAngle;
    private int niveauAngle;
    public Button btnAddTurretElec;
    private bool BoolAddTurretElec;
    private int coutAddTurretElec;
    public Button btnElecRange;
    private int coutElecRange;
    public Button btnElecRate;
    private int coutElecRate;
    public Button btnElecBounce;
    private int coutElecBounce;
    public Button btnElecFork;
    private int coutElecFork;

    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Controller").GetComponent<Controller>();
        mainTurret = GameObject.Find("Turret").GetComponent<Turret>();
        coutTurretRate = 1;
        coutTurretRotate = 1;
        coutHPIncrease = 20;
        BoolAddTurretSG = false;
        coutAddTurretSG = 30;
        coutTurretRange = 1;
        coutSGRate = 1;
        coutSGRange = 1;
        coutSGAngle = 3;
        BoolAddTurretElec = false;
        coutAddTurretElec = 120;
        coutElecRange = 1;
        coutElecRate = 1;
        coutElecBounce = 10;
        coutElecFork = 30;
        btnTurretRate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer la tourelle :\r\nCadence de tir\r\nCout : " + coutTurretRate;
        btnTurrentRotate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer la tourelle :\r\nVitesse de rotation\r\nCout : " + coutTurretRotate;
        btnHPIncrease.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Gagner un point de vie\r\nCout : " + coutHPIncrease;
        btnAddTurretSG.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Ajouter deux tourelles :\r\nFusil � pompe\r\nCout : " + coutAddTurretSG;
        btnTurretRange.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer la tourelle :\r\nPort�e\r\nCout : " + coutTurretRange;
        btnSGRate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer les fusils � pompe :\r\nCadence de tir\r\nCout : " + coutSGRate;
        btnSGRange.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer les fusils � pompe :\r\nPort�e\r\nCout : " + coutSGRange;
        btnSGAngle.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer les fusils � pompe :\r\nAngle et/ou nombre de projectiles\r\nCout : " + coutSGAngle;
        btnAddTurretElec.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Ajouter quatre tourelles :\r\nArc �lectrique\r\nCout : " + coutAddTurretElec;
        btnElecRange.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer les arcs �lectriques :\r\nPort�e et Port�e des rebonds\r\nCout : " + coutElecRange;
        btnElecRate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer les arcs �lectriques :\r\nCadence de tir\r\nCout : " + coutElecRate;
        btnElecBounce.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer les arcs �lectriques :\r\nNombre de rebonds\r\nCout : " + coutElecBounce;
        btnElecFork.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer les arcs �lectriques :\r\nNombre de s�parations\r\nCout : " + coutElecFork;
        niveauAngle = 1;
    }

    public void Pause()
    {
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        scoreTxt.GetComponent<TextMeshProUGUI>().text = "Argent : " + control.score;
        if (control.score < coutTurretRate)
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

        if (control.score < coutAddTurretSG || BoolAddTurretSG)
            btnAddTurretSG.interactable = false;
        else
            btnAddTurretSG.interactable = true;

        if (control.score < coutTurretRange)
            btnTurretRange.interactable = false;
        else
            btnTurretRange.interactable = true;

        if (control.score < coutSGRate || !BoolAddTurretSG)
            btnSGRate.interactable = false;
        else
            btnSGRate.interactable = true;

        if (control.score < coutSGRange || !BoolAddTurretSG)
            btnSGRange.interactable = false;
        else
            btnSGRange.interactable = true;

        if (control.score < coutSGAngle || !BoolAddTurretSG || niveauAngle > 9)
            btnSGAngle.interactable = false;
        else
            btnSGAngle.interactable = true;

        if (control.score < coutAddTurretElec || BoolAddTurretElec)
            btnAddTurretElec.interactable = false;
        else
            btnAddTurretElec.interactable = true;

        if (control.score < coutElecRate || !BoolAddTurretElec)
            btnElecRate.interactable = false;
        else
            btnElecRate.interactable = true;

        if (control.score < coutElecRange || !BoolAddTurretElec)
            btnElecRange.interactable = false;
        else
            btnElecRange.interactable = true;

        if (control.score < coutElecBounce || !BoolAddTurretElec)
            btnElecBounce.interactable = false;
        else
            btnElecBounce.interactable = true;

        if (control.score < coutElecFork || !BoolAddTurretElec)
            btnElecFork.interactable = false;
        else
            btnElecFork.interactable = true;
    }

    public void UPGRateMainTurret()
    {
        control.score -= coutTurretRate;
        coutTurretRate += 1;
        mainTurret.rate--;
        btnTurretRate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer la tourelle :\r\nCadence de tir\r\nCout : "+coutTurretRate;
        UpdateInfo();
    }

    public void UPGRotateTurret()
    {
        control.score -= coutTurretRotate;
        coutTurretRotate += 1;
        mainTurret.vitesse += 0.2f;
        btnTurrentRotate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer la tourelle :\r\nVitesse de rotation\r\nCout : " + coutTurretRotate;
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

    public void UPGNewSGTurret()
    {
        control.score -= coutAddTurretSG;
        BoolAddTurretSG = true;
        TurretSG1 = Instantiate(turretSGPrefab, Vector3.up * 6f, new Quaternion(0, 0, 0, 0)) as GameObject;
        TurretSG1.transform.RotateAround(Vector3.zero, Vector3.forward, 90);
        TurretSG2 = Instantiate(turretSGPrefab, Vector3.up * 6f, new Quaternion(0, 0, 0, 0)) as GameObject;
        TurretSG2.transform.RotateAround(Vector3.zero, Vector3.forward, -90);
        UpdateInfo();
    }

    public void UPGRangeTurret()
    {
        control.score -= coutTurretRange;
        coutTurretRange += 1;
        mainTurret.range++;
        btnTurretRange.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer la tourelle :\r\nPort�e\r\nCout : " + coutTurretRange;
        UpdateInfo();
    }

    public void UPGRangeSG()
    {
        control.score -= coutSGRange;
        coutSGRange += 1;
        TurretSG1.GetComponent<TurretShotgun>().range++;
        TurretSG2.GetComponent<TurretShotgun>().range++;
        btnSGRange.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer la tourelle :\r\nPort�e\r\nCout : " + coutSGRange;
        UpdateInfo();
    }

    public void UPGRateSG()
    {
        control.score -= coutSGRate;
        coutSGRate += 1;
        TurretSG1.GetComponent<TurretShotgun>().rate--;
        TurretSG2.GetComponent<TurretShotgun>().rate--;
        btnSGRate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer les fusils � pompe :\r\nCadence de tir\r\nCout : " + coutSGRate;
        UpdateInfo();
    }

    public void UPGAngleSG()
    {
        control.score -= coutSGAngle;
        if(niveauAngle < 5)
        {
            coutSGAngle += 3;
            TurretSG1.GetComponent<TurretShotgun>().angle += Mathf.PI / 8;
            TurretSG2.GetComponent<TurretShotgun>().angle += Mathf.PI / 8;
            if (niveauAngle % 3 == 0)
            {
                TurretSG1.GetComponent<TurretShotgun>().nb += 2;
                TurretSG2.GetComponent<TurretShotgun>().nb += 2;
            }
        }
        else
        {
            coutSGAngle += 9;
            TurretSG1.GetComponent<TurretShotgun>().nb += 2;
            TurretSG2.GetComponent<TurretShotgun>().nb += 2;
        }
        niveauAngle++;
        btnSGAngle.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer les fusils � pompe :\r\nAngle et/ou nombre de projectiles\r\nCout : " + coutSGAngle;
        UpdateInfo();
    }

    public void UPGNewElecTurret()
    {
        control.score -= coutAddTurretElec;
        BoolAddTurretElec = true;
        TurretElec1 = Instantiate(turretElecPrefab, Vector3.up * 6f, new Quaternion(0, 0, 0, 0)) as GameObject;
        TurretElec1.transform.RotateAround(Vector3.zero, Vector3.forward, 45);
        TurretElec2 = Instantiate(turretElecPrefab, Vector3.up * 6f, new Quaternion(0, 0, 0, 0)) as GameObject;
        TurretElec2.transform.RotateAround(Vector3.zero, Vector3.forward, 315);
        TurretElec3 = Instantiate(turretElecPrefab, Vector3.up * 6f, new Quaternion(0, 0, 0, 0)) as GameObject;
        TurretElec3.transform.RotateAround(Vector3.zero, Vector3.forward, 135);
        TurretElec4 = Instantiate(turretElecPrefab, Vector3.up * 6f, new Quaternion(0, 0, 0, 0)) as GameObject;
        TurretElec4.transform.RotateAround(Vector3.zero, Vector3.forward, 225);
        UpdateInfo();
    }

    public void UPGRangeElec()
    {
        control.score -= coutElecRange;
        coutElecRange += 1;
        TurretElec1.GetComponent<TurretElectric>().range++;
        TurretElec2.GetComponent<TurretElectric>().range++;
        TurretElec3.GetComponent<TurretElectric>().range++;
        TurretElec4.GetComponent<TurretElectric>().range++;
        btnElecRange.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer les arcs �lectriques :\r\nPort�e et Port�e des rebonds\r\nCout : " + coutElecRange;
        UpdateInfo();
    }

    public void UPGRateElec()
    {
        control.score -= coutElecRate;
        coutElecRate += 1;
        TurretElec1.GetComponent<TurretElectric>().rate--;
        TurretElec2.GetComponent<TurretElectric>().rate--;
        TurretElec3.GetComponent<TurretElectric>().rate--;
        TurretElec4.GetComponent<TurretElectric>().rate--;
        btnElecRate.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer les arcs �lectriques :\r\nCadence de tir\r\nCout : " + coutElecRate;
        UpdateInfo();
    }

    public void UPGBounceElec()
    {
        control.score -= coutElecBounce;
        coutElecBounce += 10;
        TurretElec1.GetComponent<TurretElectric>().nbBounce++;
        TurretElec2.GetComponent<TurretElectric>().nbBounce++;
        TurretElec3.GetComponent<TurretElectric>().nbBounce++;
        TurretElec4.GetComponent<TurretElectric>().nbBounce++;
        btnElecBounce.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer les arcs �lectriques :\r\nNombre de rebonds\r\nCout : " + coutElecBounce;
        UpdateInfo();
    }

    public void UPGForkElec()
    {
        control.score -= coutElecFork;
        coutElecFork += 10;
        TurretElec1.GetComponent<TurretElectric>().nbFork++;
        TurretElec2.GetComponent<TurretElectric>().nbFork++;
        TurretElec3.GetComponent<TurretElectric>().nbFork++;
        TurretElec4.GetComponent<TurretElectric>().nbFork++;
        btnElecFork.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Am�liorer les arcs �lectriques :\r\nNombre de s�parations\r\nCout : " + coutElecFork;
        UpdateInfo();
    }
}