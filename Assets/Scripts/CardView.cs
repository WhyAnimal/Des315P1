//using UnityEngine;
//using UnityEngine.UI;
//using TMPro;

//public class CardView : MonoBehaviour
//{
//    [Header("UI References")]

//    public Image frontImage;
//    public Image backImage;

//    private CardData cardData;
//    private bool isFaceUp = true;

//    public void Setup(CardData data)
//    {
//        cardData = data;

//        frontImage.sprite = cardData.FrontSprite;
//        backImage.sprite = cardData.BackSprite;

//        UpdateVisual();
//    }

//    public void Flip()
//    {
//        isFaceUp = !isFaceUp;
//        UpdateVisual();
//    }

//    private void UpdateVisual()
//    {
//        frontImage.gameObject.SetActive(isFaceUp);
//        backImage.gameObject.SetActive(!isFaceUp);
//    }
//}