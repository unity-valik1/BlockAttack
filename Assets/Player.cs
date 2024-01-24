using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Health heath;
    [SerializeField] Movement movement;
    
    public Health PlayerHealth
    {
        get => heath;
    } 
    public Movement PlayerMovement
    {
        get => movement;
    }
    
}
