using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Game/Card Database")]
public class CardDatabase : ScriptableObject
{
    public List<CardData> Cards = new List<CardData>();
}