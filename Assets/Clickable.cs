using UnityEngine;
using UnityEngine.EventSystems;

public class Clickable : MonoBehaviour, IPointerClickHandler
{

    //[Header("Interaction Settings")]
    //public string objectName;

    [TextArea] public string message;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(message);
    }
}
