using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private Light2D deckGlow;
    [SerializeField] private List <GameObject> playingCards = new List<GameObject>();
    [SerializeField] private Transform cardDrawTf;

    [Header("Card Counts")]
    [SerializeField] private int plusOne = 30;
    [SerializeField] private int plusTwo = 15;
    [SerializeField] private int plusThree = 5;
    [SerializeField] private int noMove = 10;
    [SerializeField] private int invincible = 4;

    private int plusOneCount;
    private int plusTwoCount;
    private int plusThreeCount;
    private int noMoveCount;
    private int invincibleCount;

    public int viewOrderMax = 0;
    private List<GameObject> oldCards = new List<GameObject>();
    private int countOfDrawnCards = 0;
    private int playerCardDrawCount = 0;

    private readonly float[] weights = { 0.47f, 0.23f, 0.16f, 0.08f, 0.06f };

    private void Start()
    {
        plusOneCount = plusOne;
        plusTwoCount = plusTwo;
        plusThreeCount = plusThree;
        noMoveCount = noMove;
        invincibleCount = invincible;

        viewOrderMax = (plusOneCount + plusTwoCount + plusThreeCount + noMoveCount + invincibleCount) * -1;
    }

    private void OnMouseDown()
    {
        if (viewOrderMax == -1) 
        {
            SpawnCardsAndMaintainCount();
            deckGlow.enabled = false;
            gameObject.SetActive(false);
            Invoke("ResetDeck", 1.5f);
        }
        else if (playerCardDrawCount == 0)
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
                if (plusOneCount <= 0) { plusOneCount = 0; SpawnCardsAndMaintainCount(); }
                else { SpawnRandomCard(randIndex); plusOneCount--; }
                break;
            case 1:
                if (plusTwoCount <= 0) { plusTwoCount = 0;  SpawnCardsAndMaintainCount(); }
                else { SpawnRandomCard(randIndex); plusTwoCount--; }
                break;
            case 2:
                if (plusThreeCount <= 0) { plusThreeCount = 0; SpawnCardsAndMaintainCount(); }
                else { SpawnRandomCard(randIndex); plusThreeCount--; }
                break;
            case 3:
                if (noMoveCount <= 0) { noMoveCount = 0; SpawnCardsAndMaintainCount(); }
                else { SpawnRandomCard(randIndex); noMoveCount--; }
                break;
            case 4:
                if (invincibleCount <= 0) { invincibleCount = 0; SpawnCardsAndMaintainCount(); }
                else { SpawnRandomCard(randIndex); invincibleCount--; }
                break;
            default:
                break;
        }
    }

    private void SpawnRandomCard(int index)
    {
        GameObject card = Instantiate(playingCards[index], cardDrawTf);
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

    private void ResetDeck()
    {
        Destroy(oldCards[1]);
        Destroy(oldCards[0]);

        plusOneCount = plusOne;
        plusTwoCount = plusTwo;
        plusThreeCount = plusThree;
        noMoveCount = noMove;
        invincibleCount = invincible;
        viewOrderMax = (plusOneCount + plusTwoCount + plusThreeCount + noMoveCount + invincibleCount) * -1;
        gameObject.SetActive(true);
    }
}
