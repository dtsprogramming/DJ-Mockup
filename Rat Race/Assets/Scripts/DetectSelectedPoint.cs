using System.Collections.Generic;
using UnityEngine;

public class DetectSelectedPoint : MonoBehaviour
{
    [SerializeField] private List<Transform> neighborPositions;
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
