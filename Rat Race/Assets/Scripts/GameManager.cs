using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    [Header("Set Game Board")]
    [SerializeField] private GameObject[] players;
    [SerializeField] private PlayerStatus[] pStat;
    [SerializeField] private Light2D[] playerGlow;
    [SerializeField] private ParticleSystem[] playerParticles;
    [SerializeField] private Transform[] startPoints;

    [Header("Support Objects")]
    [SerializeField] TextMeshProUGUI playerIndicator;
    [SerializeField] private DeckManager deckManager;
    [SerializeField] private Light2D deckGlow;

    private int[] invincibleCount = {0, 0, 0, 0};

    private int cardValueTracker = 1;
    private int playerIndex = -1;
    private int playerCount = 0;


    private void Awake()
    {
        //if (instance != null && instance != this)
        //{
        //    Destroy(gameObject);
        //}
        //else
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}

        playerCount = players.Length;
}

    private void Start()
    {
        playerIndicator.text = "PLAYER 1";

        for (int i = 0; i < players.Length; i++)
        {
            players[i].transform.position = startPoints[i].position;
        }

        SelectNextPlayer();
    }

    public Transform GetCurrentPlayerTransform()
    {
        return players[playerIndex].transform;
    }

    public void SetCardTrackerValue(int value)
    {
        cardValueTracker = value;

        if (cardValueTracker <= 0)
        {
            Invoke("SelectNextPlayer", 0.5f);
            deckManager.SetPlayerDrawCountToZero();
        }
    }

    private void SelectNextPlayer()
    {
        if (playerIndex >= 3)
        {
            playerIndex = -1;
        }

        playerIndex++;

        SetActivePlayer(playerIndex);
    }

    public int AnnounceCardValue()
    {
        return cardValueTracker;
    }

    #region Player Selection
    public void SetActivePlayer(int index)
    {
        deckGlow.enabled = true;

        CheckInvincibility();

        if (!players[index].activeInHierarchy)
        {
            SelectNextPlayer();
        }
        else
        {
            playerIndicator.text = $"PLAYER {index + 1}";
            playerGlow[index].enabled = true;
            pStat[index].SetActiveStatus(true);

            for (int i = 0; i < players.Length; i++)
            {
                if (i != index)
                {
                    playerGlow[i].enabled = false;
                    pStat[i].SetActiveStatus(false);
                }
            }
        }
    }
    #endregion

    public void SetInvincible()
    {
        invincibleCount[playerIndex] = 3;
        playerParticles[playerIndex].Play();
        players[playerIndex].layer = 0;
        pStat[playerIndex].SetInvincibleStatus(true);
    }

    private void CheckInvincibility()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (pStat[i].GetInvincibleStatus() && invincibleCount[i] > 0) { invincibleCount[i]--; }
            else if (pStat[i].GetInvincibleStatus() && invincibleCount[i] <= 0){ DisableInvincible(i); }
        }
    }

    private void DisableInvincible(int index)
    {
        playerParticles[index].Stop();
        pStat[index].SetInvincibleStatus(false);
        players[index].layer = 2;
    }

    public void ReducePlayerCount()
    {
        playerCount--;

        if (playerCount == 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
