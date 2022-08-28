using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Status Effect")]

public class StatusData : ScriptableObject
{
    public float DOTAmount;
    public float TickSpeed;
    public float MovementPenalty;
    public float LifeTime;
}
