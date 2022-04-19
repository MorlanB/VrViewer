using TMPro;
using UnityEngine;

public class Selector : MonoBehaviour
{
    [SerializeField]
    Camera cam;

    [SerializeField]
    TextMeshPro partNameText;

    private RamenPart highlighted;

    private void Update()
    {
        if (highlighted != null)
            highlighted.SetHighlighted(false);

        partNameText.gameObject.SetActive(false);

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            RamenPart hitPart = hit.collider.GetComponentInParent<RamenPart>();

            if (hitPart != null)
            {
                hitPart.SetHighlighted(true);

                highlighted = hitPart;

                partNameText.gameObject.SetActive(true);

                partNameText.transform.position = hitPart.transform.position;
                partNameText.text = hitPart.PartName;                
            }
        }
    }

    //void PartIsBeingSelected()
    //{
    //    RamenPart hitPart = hit.collider.GetComponentInParent<RamenPart>();

    //    if (hitPart != null)
    //    {
    //        hitPart.SetHighlighted(true);

    //        highlighted = hitPart;

    //        partNameText.gameObject.SetActive(true);

    //        partNameText.transform.position = hitPart.transform.position;
    //        partNameText.text = hitPart.PartName;
    //    }
    //}
}
