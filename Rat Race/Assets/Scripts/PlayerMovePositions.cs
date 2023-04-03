using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePositions : MonoBehaviour
{
    [SerializeField] private List<GameObject> players = new List<GameObject>();
    [SerializeField] private Positions movePositions = new Positions();

    private bool isHuman = false;
    private bool isDog = false;
    private bool isCat = false;
    private bool isRat = false;

    #region Player Selection
    public void IsHuman()
    {
        isHuman = true;
        isDog = false;
        isCat = false;
        isRat = false;
    }

    public void IsDog()
    {
        isDog = true;
        isHuman = false;
        isCat = false;
        isRat = false;
    }

    public void IsCat()
    {
        isCat = true;
        isHuman = false;
        isDog = false;
        isRat = false;
    }

    public void IsRat()
    {
        isRat = true;
        isHuman = false;
        isDog = false;
        isCat = false;
    }
    #endregion

    public void MoveSelectedPlayer(Transform movePos)
    {
        if (isHuman)
        {
            players[0].transform.position = movePos.transform.position;
        }

        if (isDog)
        {
            players[1].transform.position = movePos.transform.position;
        }

        if (isCat)
        {
            players[2].transform.position = movePos.transform.position;
        }

        if (isRat)
        {
            players[3].transform.position = movePos.transform.position;
        }
    }

    [System.Serializable]
    public class Positions
    {
        [SerializeField] private List<MovePosNeighbors> positionList = new List<MovePosNeighbors>();
    }

    [System.Serializable]
    public class MovePosNeighbors
    {
        [SerializeField] private List<GameObject> position = new List<GameObject>();
        [SerializeField] private List<GameObject> neighbors = new List<GameObject>();
    }
}
