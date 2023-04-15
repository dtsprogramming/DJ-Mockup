using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectSelectedPoint : MonoBehaviour
{
    [SerializeField] private Transform[] neighborPositions;

    private PlayerMovePositions pmp;
    private Transform tf;

    private void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        pmp = FindObjectOfType<PlayerMovePositions>();
    }

    private void OnMouseDown()
    {
        for (int i = 0; i < neighborPositions.Length; i++)
        {
            pmp.MoveSelectedPlayer(tf, neighborPositions[i]);
        }
        
    }
}
