using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    public GameObject UI;
    float time = 120;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UI.GetComponent<TextMeshProUGUI>().text = "0:00";
    }

    // Update is called once per frame
    void Update()
    {

        int second = (int)time % 60;
        UI.GetComponent<TextMeshProUGUI>().text = "" + (int)time / 60 + " : " + second.ToString("00");
        time -= Time.deltaTime;
    }
}
