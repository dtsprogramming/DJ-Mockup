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

    public void MoveSelectedPlayer(Transform movePos, Transform[] neighbors)
    {
        Transform playerTF = players[playerIndex].transform;
        foreach (Transform t in neighbors)
        {
            if (playerTF.position.x == t.position.x || playerTF.position.y == t.position.y)
            {
                players[playerIndex].transform.position = new Vector3(movePos.position.x, movePos.position.y, 0);
                return;
            }
        }
    }
}
