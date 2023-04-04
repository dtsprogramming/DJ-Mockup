using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovePositions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerIndicator;
    [SerializeField] private List<GameObject> players = new List<GameObject>();

    private int playerIndex;

    #region Player Selection
    public void IsHuman()
    {
        playerIndex = 0;
        playerIndicator.text = "HUMAN";
    }

    public void IsDog()
    {
        playerIndex = 1;
        playerIndicator.text = "DOG";
    }

    public void IsCat()
    {
        playerIndex = 2;
        playerIndicator.text = "CAT";
    }

    public void IsRat()
    {
        playerIndex = 3;
        playerIndicator.text = "RAT";
    }
    #endregion

    public void MoveSelectedPlayer(Transform movePos)
    {
        if ((movePos.position - players[playerIndex].transform.position).magnitude < 3)
        {
            players[playerIndex].transform.position = movePos.position;
        };
    }
}
