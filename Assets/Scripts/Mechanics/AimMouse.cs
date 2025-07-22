using UnityEngine;
using UnityEngine.EventSystems;

public class AimMouse : MonoBehaviour
{
    RectTransform aim;
    RectTransform canvas;

    void Start()
    {
        aim = GetComponent<RectTransform>();
        canvas = aim.parent.GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas,
            Input.mousePosition,
            null, // Se for Canvas em Overlay
            out localPos
        );
        aim.localPosition = localPos;
    }
}
