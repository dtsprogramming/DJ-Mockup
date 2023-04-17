using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectSelectedPoint : MonoBehaviour
{
    [SerializeField] private Transform[] neighborPositions;
    [SerializeField] private PlayerMovePositions pmp;

    private Transform tf;

    private void Start()
    {
        tf = GetComponent<Transform>();
    }

    private void OnMouseDown()
    {
        pmp.MoveSelectedPlayer(tf, neighborPositions);
    }
}
