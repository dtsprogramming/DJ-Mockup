using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    [Header("Add Attack Target")]
    [SerializeField] private GameObject target;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            target.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }
}
