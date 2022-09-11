using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{

    void OnTriggerEnter(Collider other) //Load next level and unlock that level
    {
        if (other.tag == "Cold")
        {
            Destroy(gameObject, 30f);
        }
    }
}
