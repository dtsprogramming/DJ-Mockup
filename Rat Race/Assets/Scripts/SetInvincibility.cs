using UnityEngine;

public class SetInvincibility : MonoBehaviour
{
    [SerializeField] private GameManager gm;

    private void Awake()
    {
        gm = FindFirstObjectByType<GameManager>();
        SetInvincible();
    }

    public void SetInvincible()
    {
        gm.SetInvincible();
    }
}
