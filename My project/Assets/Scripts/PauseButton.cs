using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    // Start is called before the first frame update

    private Controller control;
    public TextMeshProUGUI text;
    public GameObject panel;
    public GameObject menu2;
    void Start()
    {
        control = GameObject.Find("Controller").GetComponent<Controller>();
        panel.transform.localPosition = new Vector3(500, 0, -450);
        menu2.transform.localPosition = new Vector3(500, 0, -450);
    }

    public void Pressed()
    {
        control.PauseGame();
        if (control.pause)
        {
            text.GetComponent<TextMeshProUGUI>().text = "Run";
            panel.transform.localPosition = new Vector3(0, 0, -450);
            panel.GetComponent<Menu>().Pause();
        }
        else
        {
            text.GetComponent<TextMeshProUGUI>().text = "Pause";
            panel.transform.localPosition = new Vector3(500, 0, -450);
            menu2.transform.localPosition = new Vector3(500, 0, -450);
        }
    }
}
