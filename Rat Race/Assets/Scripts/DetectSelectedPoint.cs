using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectSelectedPoint : MonoBehaviour
{
    public UnityEvent OnPositionSelected;

    private void OnMouseDown()
    {
        OnPositionSelected.Invoke();
    }
}
