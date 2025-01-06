using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovePositions : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerIndicator;
    [SerializeField] private List<GameObject> players = new List<GameObject>();

    [Header("Dice roll for player movement")]
    [SerializeField] private TextMeshProUGUI tmpDiceRoll;
    [SerializeField, Range(1, 6)] private int diceMax = 3;
    private int diceRoll = 0;

    private int playerIndex = -1;

    private void Start()
    {
        playerIndicator.text = "HUMAN";
    }

    #region Player Selection
    public void SetActivePlayer()
    {
        if (playerIndex >= 3)
        {
            playerIndex = -1;
        }

        playerIndex++;

        switch (playerIndex)
        {
            case 0: 
                playerIndicator.text = "HUMAN";
                break;
            case 1:
                playerIndicator.text = "DOG";
                break;
            case 2:
                playerIndicator.text = "CAT";
                break;
            case 3:
                playerIndicator.text = "RAT";
                break;
            default:
                break;
        }
    }
    #endregion

    public void MoveSelectedPlayer(Transform movePos, Transform[] neighbors)
    {
        Transform playerTF = players[playerIndex].transform;
        foreach (Transform t in neighbors)
        {
            if ((playerTF.position.x == t.position.x || playerTF.position.y == t.position.y) && diceRoll > 0)
            {
                players[playerIndex].transform.position = new Vector3(movePos.position.x, movePos.position.y, 0);
                diceRoll--;
                tmpDiceRoll.text = diceRoll.ToString();
                return;
            }
        }
    }

    public void DiceRollRandomNumGenerator()
    {
        SetActivePlayer();

        diceRoll = Random.Range(1, diceMax + 1);
        tmpDiceRoll.text = diceRoll.ToString();
    }
}
