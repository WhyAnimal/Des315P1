//using UnityEngine;

//public class Dealer : MonoBehaviour
//{
//    public DeckManager Deck;
//    public HandArea PlayerHandBottom;
//    public HandArea HandTop;
//    public HandArea HandLeft;
//    public HandArea HandRight;

//    [Header("Deal Settings")]
//    public int Players = 4;
//    public int CardsPerHand = 7;
//    public float DealInterval = 0.06f;
//    public float DealMoveDuration = 0.22f;
//    public float DealArcHeight = 140f;

//    public void DealAllHands()
//    {
//        PlayerHandBottom.ResetHandCount();
//        HandTop.ResetHandCount();
//        HandLeft.ResetHandCount();
//        HandRight.ResetHandCount();


//        for (int c = 0; c < CardsPerHand; c++)
//        {
//            DealToHand(PlayerHandBottom, isPlayer: true, indexInRound: c, seat: 0);
//            DealToHand(HandLeft, isPlayer: false, indexInRound: c, seat: 1);
//            DealToHand(HandTop, isPlayer: false, indexInRound: c, seat: 2);
//            DealToHand(HandRight, isPlayer: false, indexInRound: c, seat: 3);
//        }
//    }

//    private void DealToHand(HandArea hand, bool isPlayer, int indexInRound, int seat)
//    {
//        var card = Deck.DrawTop();
//        if (card == null) return;


//        card.Rect.anchoredPosition = Deck.DeckAnchor.anchoredPosition;
//        card.Rect.localScale = Vector3.one;
//        card.SetFaceUp(false);
//        card.Rect.SetAsLastSibling();


//        int slotIndex = hand.CardsInHand;
//        int total = CardsPerHand;
//        bool vertical = (hand == HandLeft || hand == HandRight);

//        var pose = hand.GetSlotPose(slotIndex, total, vertical);


//        float delay = (indexInRound * Players + seat) * DealInterval;


//        Vector2 arcOffset = seat switch
//        {
//            0 => new Vector2(0, DealArcHeight),
//            2 => new Vector2(0, -DealArcHeight),
//            1 => new Vector2(DealArcHeight, 0),
//            3 => new Vector2(-DealArcHeight, 0),
//            _ => new Vector2(0, DealArcHeight),
//        };


//        ActionRunner.Instance.Actions.Enqueue(
//            new RectTransformArcMoveAction(card.Rect, pose.pos, arcOffset, delay, DealMoveDuration)
//        );

//        ActionRunner.Instance.Actions.Enqueue(
//            new RectTransformTweenAction(
//                target: card.Rect,
//                toAnchoredPos: pose.pos,
//                toScale: pose.scale,
//                delaySeconds: delay,
//                durationSeconds: DealMoveDuration,
//                easeSmoothStep: true,
//                bringToFrontOnStart: true
//            )
//        );


//        ActionRunner.Instance.Actions.Enqueue(
//            new InstantCallbackAction(() => card.Rect.localRotation = pose.rot)
//        );


//        if (isPlayer)
//        {

//            ActionRunner.Instance.Actions.Enqueue(new CardFlipAction(card, faceUp: true, delay + DealMoveDuration * 0.7f, 0.18f));
//        }
//        else
//        {
//            card.SetFaceUp(false);
//        }


//        typeof(HandArea).GetField("_count", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
//            ?.SetValue(hand, hand.CardsInHand + 1);
//    }
//}