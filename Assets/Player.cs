using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Health heath;
    
    public Health PlayerHealth
    {
        get => heath;
    }
    
}
