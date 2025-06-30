using System.Collections.Generic;
using UnityEngine;

public class PlayerMovePositions : MonoBehaviour
{
    private GameManager gm;

    public int moveDist;

    private void Start()
    {
        gm = FindFirstObjectByType<GameManager>();
    }

    public void MoveSelectedPlayer(Transform movePos, List<Transform> neighbors)
    {
        moveDist = gm.AnnounceCardValue();

        Transform playerTF = gm.GetCurrentPlayerTransform();

        foreach (Transform t in neighbors)
        {
            if (playerTF.position == t.position && moveDist > 0)
            {
                playerTF.position = movePos.position;
                moveDist--;
                gm.SetCardTrackerValue(moveDist);
                
                return;
            }
        }
    }
}
