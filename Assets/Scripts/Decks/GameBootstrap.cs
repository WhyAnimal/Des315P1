//using UnityEngine;

//public class GameBootstrap : MonoBehaviour
//{
//    public DeckManager Deck;
//    public Dealer Dealer;

//    private void Start()
//    {
//        Run();
//    }


//    public void Run()
//    {
//        ActionRunner.Instance.Actions.Clear();

//        Deck.BuildDeck();

//        ActionRunner.Instance.Actions.Enqueue(new RiffleShuffleAction(Deck, durationSeconds: 1.0f, topCount: Deck.Count));
//        ActionRunner.Instance.Actions.Enqueue(new RiffleShuffleAction(Deck, durationSeconds: 1.0f, topCount: Deck.Count));
//        ActionRunner.Instance.Actions.Enqueue(new InstantCallbackAction(() => Dealer.DealAllHands()));
//    }
//}