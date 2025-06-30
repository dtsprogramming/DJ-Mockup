using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private bool isInvincible = false;
    [SerializeField] private bool isActive = false;

    public void SetInvincibleStatus(bool value)
    {
        isInvincible = value;
    }

    public bool GetInvincibleStatus() => isInvincible;

    public void SetActiveStatus(bool value)
    {
        isActive = value;
    }

    public bool GetActiveStatus() => isActive;
}
