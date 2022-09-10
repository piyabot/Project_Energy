using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezing : MonoBehaviour
{
    public GameObject freeze;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) //Load next level and unlock that level
    {
        if (other.tag == "Cold")
        {
            freeze.SetActive(true);
        }
        else
        {
            freeze.SetActive(false);
        }
    }
}
