using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeController : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Player Player;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!Player.InMove())
        {
            if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
            {
                if (eventData.delta.x > 0)
                    Player.Move(Vector3.right);
                else
                    Player.Move(Vector3.left);
            }
            else
            {
                if (eventData.delta.y > 0)
                    Player.Move(Vector3.up);
                else
                    Player.Move(Vector3.down);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
    }
}
