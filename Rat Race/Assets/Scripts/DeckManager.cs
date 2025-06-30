using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private Light2D deckGlow;
    [SerializeField] private List <GameObject> playingCards = new List<GameObject>();
    [SerializeField] private Transform cardDraw;

    [Header("Card Counts")]
    [SerializeField] private int plusOneCount = 30;
    [SerializeField] private int plusTwoCount = 15;
    [SerializeField] private int plusThreeCount = 5;
    [SerializeField] private int noMoveCount = 10;
    [SerializeField] private int invincibleCount = 4;

    public int viewOrderMax = 0;
    private List<GameObject> oldCards = new List<GameObject>();
    private int countOfDrawnCards = 0;
    private int playerCardDrawCount = 0;

    private readonly float[] weights = { 0.47f, 0.23f, 0.16f, 0.08f, 0.06f };

    private void Start()
    {
        viewOrderMax = (plusOneCount + plusTwoCount + plusThreeCount + noMoveCount + invincibleCount) * -1;
    }

    private void OnMouseDown()
    {
        if (playerCardDrawCount == 0)
        {
            SpawnCardsAndMaintainCount();
            deckGlow.enabled = false;
        }
    }

    private void SpawnCardsAndMaintainCount()
    {
        int randIndex = GetRandomCardIndex();

        switch (randIndex)
        {
            case 0:
                plusOneCount--;
                if (plusOneCount <= 0) { plusOneCount = 0; SpawnCardsAndMaintainCount(); }
                else { SpawnRandomCard(randIndex); }
                break;
            case 1:
                plusTwoCount--;
                if (plusTwoCount <= 0) { plusTwoCount = 0;  SpawnCardsAndMaintainCount(); }
                else { SpawnRandomCard(randIndex); }
                break;
            case 2:
                plusThreeCount--;
                if (plusThreeCount <= 0) { plusThreeCount = 0; SpawnCardsAndMaintainCount(); }
                else { SpawnRandomCard(randIndex); }
                break;
            case 3:
                noMoveCount--;
                if (noMoveCount <= 0) { noMoveCount = 0; SpawnCardsAndMaintainCount(); }
                else { SpawnRandomCard(randIndex); }
                break;
            case 4:
                invincibleCount--;
                if (invincibleCount <= 0) { invincibleCount = 0; SpawnCardsAndMaintainCount(); }
                else { SpawnRandomCard(randIndex); }
                break;
            default:
                break;
        }
    }

    private void SpawnRandomCard(int index)
    {
        GameObject card = Instantiate(playingCards[index], cardDraw);
        countOfDrawnCards++;
        playerCardDrawCount++;

        Renderer cardRend = card.GetComponent<Renderer>();
        cardRend.sortingOrder = viewOrderMax;

        oldCards.Add(card);
        viewOrderMax++;

        ClearOldCards();
    }

    public void SetPlayerDrawCountToZero()
    {
        playerCardDrawCount = 0;
    }

    private void ClearOldCards()
    {
        if (countOfDrawnCards > 2)
        {
            Destroy(oldCards[0]);
            oldCards.RemoveAt(0);
        }
    }

    private int GetRandomCardIndex()
    {
        float totalWeight = 0f;
        foreach (float weight in weights)
        {
            totalWeight += weight;
        }

        float randomValue = Random.value * totalWeight;
        float cumulativeWeight = 0f;

        for (int i = 0; i < weights.Length; i++)
        {
            cumulativeWeight += weights[i];
            if (randomValue <= cumulativeWeight)
            {
                return i;
            }
        }

        // Fallback to last index (should rarely happen)
        return weights.Length - 1;
    }
}
