using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] private GameObject LeftGates;
    [SerializeField] private GameObject RightGates;
    
    public void MovementGateInDifferentSides()
    {
        LeftGates.transform.DOMoveX(-12, 2);
        RightGates.transform.DOMoveX(12, 2);
    }
    public void MovementGateInCenter()
    {
        LeftGates.transform.DOMoveX(-4, 2);
        RightGates.transform.DOMoveX(4, 2);
    }

    public void GateInCenter()
    {
        LeftGates.transform.position = new Vector3(-4, LeftGates.transform.position.y, LeftGates.transform.position.z);
        RightGates.transform.position = new Vector3(4, RightGates.transform.position.y, RightGates.transform.position.z);
    }
}
