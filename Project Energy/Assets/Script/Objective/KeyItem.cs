using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public GameObject keyItem;
    public GameObject keyObject;
    public GameObject pickUpText;

    public bool inRange;
    // Start is called before the first frame update
    void Start()
    {
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetMouseButtonDown(0))
        {
            keyItem.SetActive(true);
            pickUpText.SetActive(false);
            keyObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inRange = true;
            pickUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = false;
            pickUpText.SetActive(false);
        }
    }
}
