using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warm : MonoBehaviour
{
    public GameObject warm;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            warm.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            warm.SetActive(false);
        }
    }
}
