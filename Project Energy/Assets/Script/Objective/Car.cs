using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject survive;
    public GameObject repairText;
    public GameObject failText;
    public GameObject gas;
    public GameObject battery;
    public GameObject radio;
    public GameObject carLight;

    public bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
        survive.SetActive(false);
        repairText.SetActive(false);
        failText.SetActive(false);
        gas.SetActive(false);
        battery.SetActive(false);
        radio.SetActive(false);
        carLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gas.activeInHierarchy == true && battery.activeInHierarchy == true && radio.activeInHierarchy == true && inRange && Input.GetMouseButtonDown(0))
        {
            repairText.SetActive(false);
            carLight.SetActive(true);
            survive.SetActive(true);
            { Time.timeScale = 0; };
        }
        else if (gas.activeInHierarchy == false && inRange && Input.GetMouseButtonDown(0))
        {
            repairText.SetActive(false);
            failText.SetActive(true);
        }
        else if (battery.activeInHierarchy == false && inRange && Input.GetMouseButtonDown(0))
        {
            repairText.SetActive(false);
            failText.SetActive(true);
        }
        else if (radio.activeInHierarchy == false && inRange && Input.GetMouseButtonDown(0))
        {
            repairText.SetActive(false);
            failText.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inRange = true;
            repairText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = false;
            repairText.SetActive(false);
            failText.SetActive(false);
        }
    }
}
