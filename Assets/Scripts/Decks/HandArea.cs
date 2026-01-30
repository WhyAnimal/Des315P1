//using UnityEngine;

//public class HandArea : MonoBehaviour
//{
//    public RectTransform Anchor;
//    public int CardsInHand => _count;

//    [Header("Layout")]
//    public float Spacing = 110f;
//    public float VerticalSpacing = 90f;
//    public float FanDegrees = 12f;

//    private int _count = 0;

//    public void ResetHandCount() => _count = 0;
//    public void IncrementCount() => _count++;
//    public (Vector2 pos, Quaternion rot, Vector3 scale) GetSlotPose(int index, int total, bool vertical)
//    {

//        float mid = (total - 1) * 0.5f;
//        float offset = index - mid;

//        Vector2 basePos = Anchor.anchoredPosition;
//        Vector2 pos = vertical
//            ? basePos + new Vector2(0, offset * VerticalSpacing)
//            : basePos + new Vector2(offset * Spacing, 0);

//        float angle = -offset * FanDegrees;
//        Quaternion rot = Quaternion.Euler(0, 0, angle);

//        return (pos, rot, Vector3.one);
//    }
//}