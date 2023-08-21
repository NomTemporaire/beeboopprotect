using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewTurretMenu : MonoBehaviour
{

    private Controller control;
    public GameObject Menu;
    private Menu menu;
    public List<Button> TurretSGG = new List<Button>();
    public List<Button> TurretSGD = new List<Button>();
    public List<Button> TurretElecG = new List<Button>();
    public List<Button> TurretElecD = new List<Button>();
    public List<bool> achatG = new List<bool>();
    public List<bool> achatD = new List<bool>();
    // Start is called before the first frame update
    void Start()
    {
        control = GameObject.Find("Controller").GetComponent<Controller>();
        menu = Menu.GetComponent<Menu>();
        achatG.Add(false);
        achatG.Add(false);
        achatG.Add(false);
        achatD.Add(false);
        achatD.Add(false);
        achatD.Add(false);
    }

    public void open()
    {
        Menu.transform.localPosition = new Vector3(500, 0, -450);
        gameObject.transform.localPosition = new Vector3(0, 0, -450);
        int coutSG = menu.coutAddTurretSG + menu.coutSGSup;
        int coutElec = menu.coutAddTurretElec + menu.coutElecSup;
        int i = 0;
        foreach (Button b in TurretSGG)
        {
            b.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Acheter tourelle fusil à pompe\r\nCout : "+coutSG;
            if(control.score<coutSG || achatG[i])
                b.interactable = false;
            else
                b.interactable = true;
            i++;
        }
        i = 0;
        foreach (Button b in TurretSGD)
        {
            b.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Acheter tourelle fusil à pompe\r\nCout : " + coutSG;
            if (control.score < coutSG || achatD[i])
                b.interactable = false;
            else
                b.interactable = true;
            i++;
        }
        i = 0;
        foreach (Button b in TurretElecG)
        {
            b.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Acheter tourelle arc électrique\r\nCout : " + coutElec;
            if (control.score < coutElec || achatG[i])
                b.interactable = false;
            else
                b.interactable = true;
            i++;
        }
        i = 0;
        foreach (Button b in TurretElecD)
        {
            b.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Acheter tourelle arc électrique\r\nCout : " + coutElec;
            if (control.score < coutElec || achatD[i])
                b.interactable = false;
            else
                b.interactable = true;
            i++;
        }
    }

    public void close()
    {
        Menu.transform.localPosition = new Vector3(0, 0, -450);
        gameObject.transform.localPosition = new Vector3(500, 0, -450);
    }

    public void BuyNewSG(int i)
    {
        menu.UPGNewSGTurret(i);
        if(i<0)
        {
            i *= -1;
            TurretElecD[i-1].interactable = false;
            TurretSGD[i-1].interactable = false;
            achatD[i - 1] = true;
        }
        else
        {
            i--;
            TurretElecG[i-1].interactable = false;
            TurretSGG[i-1].interactable = false;
            achatG[i - 1] = true;
        }
    }

    public void BuyNewElec(int i)
    {
        menu.UPGNewElecTurret(i);
        if (i < 0)
        {
            i *= -1;
            TurretElecD[i-1].interactable = false;
            TurretSGD[i-1].interactable = false;
            achatD[i - 1] = true;
        }
        else
        {
            TurretElecG[i-1].interactable = false;
            TurretSGG[i-1].interactable = false;
            achatG[i - 1] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
