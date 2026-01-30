//using UnityEngine;

//public class CardSpawner : MonoBehaviour
//{
//    public CardDatabase cardDatabase;
//    public CardView cardPrefab;
//    public Transform cardParent;

//    void Start()
//    {
//        SpawnCard(0); // spawn first card in database
//    }

//    public void SpawnCard(int index)
//    {
//        CardView card = Instantiate(cardPrefab, cardParent);
//        card.Setup(cardDatabase.Cards[index]);
//    }
//}