using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public GameObject Win;

    void OnTriggerEnter(Collider other) //Load next level and unlock that level
    {
        if (other.tag == "Player")
        {
            Win.SetActive(true);
        }
    }
}
