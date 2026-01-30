using UnityEngine;

public class Cards : MonoBehaviour
{
    public CardData Data;

    [SerializeField] private SpriteRenderer frontRenderer;
    [SerializeField] private SpriteRenderer backRenderer;

    private bool isFaceUp = true;

    public void Initialize(CardData data)
    {
        Data = data;
        frontRenderer.sprite = Data.FrontSprite;
        backRenderer.sprite = Data.BackSprite;
    }
}