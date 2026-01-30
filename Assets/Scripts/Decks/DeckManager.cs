//using System.Collections.Generic;
//using UnityEngine;

//public class DeckManager : MonoBehaviour
//{
//    [Header("Data")]
//    public CardDatabase Database;

//    [Header("Prefabs/Anchors")]
//    public CardView CardPrefab;
//    public RectTransform CanvasRoot;
//    public RectTransform DeckAnchor;

//    [Header("Deck Visual")]
//    public int DeckCount = 30;
//    public float StackOffsetY = 1.25f;
//    public float StackTiltDegrees = 1.0f;

//    private readonly List<CardView> _deck = new();

//    public int Count => _deck.Count;
//    public IReadOnlyList<CardView> DeckCards => _deck;

//    public void ReplaceTopSegment(int topCount, List<CardView> newTopOrder)
//    {

//        int count = Mathf.Min(topCount, _deck.Count);
//        if (count <= 0) return;
//        if (newTopOrder == null || newTopOrder.Count != count) return;

//        int start = _deck.Count - count;
//        for (int i = 0; i < count; i++)
//            _deck[start + i] = newTopOrder[i];
//    }

//    public void ShuffleList(System.Random rng)
//    {
//        for (int i = _deck.Count - 1; i > 0; i--)
//        {
//            int j = rng.Next(i + 1);
//            (_deck[i], _deck[j]) = (_deck[j], _deck[i]);
//        }
//    }

//    public void BuildDeck()
//    {
//        ClearDeck();


//        for (int i = 0; i < DeckCount; i++)
//        {
//            var data = Database.Cards[i];
//            var card = Instantiate(CardPrefab, DeckAnchor.parent);
//            card.Bind(data);
//            card.SetFaceUp(false);

//            _deck.Add(card);
//        }

//        RestackVisual();
//    }

//    public CardView DrawTop()
//    {
//        if (_deck.Count == 0) return null;
//        int topIndex = _deck.Count - 1;
//        var top = _deck[topIndex];
//        _deck.RemoveAt(topIndex);
//        return top;
//    }

//    public void RestackVisual()
//    {
//        for (int i = 0; i < _deck.Count; i++)
//        {
//            var card = _deck[i];
//            card.Rect.SetAsLastSibling();


//            card.Rect.anchoredPosition = DeckAnchor.anchoredPosition + new Vector2(0, i * StackOffsetY);


//            float tilt = Random.Range(-StackTiltDegrees, StackTiltDegrees);
//            card.Rect.localRotation = Quaternion.Euler(0, 0, tilt);

//            card.Rect.localScale = Vector3.one;
//        }
//    }

//    private void ClearDeck()
//    {
//        for (int i = 0; i < _deck.Count; i++)
//            if (_deck[i] != null) Destroy(_deck[i].gameObject);
//        _deck.Clear();
//    }
//}