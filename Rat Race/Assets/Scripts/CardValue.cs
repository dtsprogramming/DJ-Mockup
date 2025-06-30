using UnityEngine;

public class CardValue : MonoBehaviour
{
    [SerializeField] private int setCardValue = 0;
    [SerializeField] public int getCardValue {  get; private set; }

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        getCardValue = setCardValue;
        gameManager.SetCardTrackerValue(getCardValue);
    }
}
