using UnityEngine;

public class CardValue : MonoBehaviour
{
    [SerializeField] private int ThisCardValue = 0;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int cardValue = ThisCardValue;
        gameManager.SetCardTrackerValue(cardValue);
    }
}
