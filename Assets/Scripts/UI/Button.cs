
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerDownHandler
{
    public event UnityAction Click;

    public void OnPointerDown(PointerEventData eventData)
    {
        Click?.Invoke();
    }
}
