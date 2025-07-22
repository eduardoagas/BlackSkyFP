using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class BirdShooter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Tried shooting");
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            foreach (RaycastResult r in results)
            {
                BirdTarget bird = r.gameObject.GetComponent<BirdTarget>();
                if (bird != null)
                {
                    bird.OnHit();
                    break;
                }
            }
        }
    }
}
