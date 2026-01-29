using UnityEngine;

[CreateAssetMenu(menuName = "Card Game/Card Data")]
public class CardData : ScriptableObject
{
    public string CardId;
    public string DisplayName;
    public Sprite FrontSprite;

}