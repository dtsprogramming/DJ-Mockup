using UnityEngine;

public class MoveCard : MonoBehaviour
{
    [SerializeField] private GameObject cardPlacement;
    [SerializeField] private float lerpSpeed = 15f;

    private void Awake()
    {
        cardPlacement = GameObject.Find("CardPlacement");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector2.Lerp(gameObject.transform.position, cardPlacement.transform.position, lerpSpeed * Time.deltaTime);
    }
}
