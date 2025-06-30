using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Add Attack Target")]
    [SerializeField] private GameObject[] targets;

    private PlayerStatus status;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        status = GetComponent<PlayerStatus>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "MovePos")
        {
            if (status.GetActiveStatus())
            {
                collision.gameObject.SetActive(false);
                gameManager.ReducePlayerCount();
            }
        }
    }
}
