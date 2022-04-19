using TMPro;
using UnityEngine;

public class RamenPart : MonoBehaviour
{
    [SerializeField]
    string partName = "Unnamed";

    [SerializeField]
    TextMeshPro partNameText;

    private RamenPart highlighted;

    public string PartName => partName;

    public void SetHighlighted(bool value)
    {
        Material material = GetComponent<Renderer>().material;

        material.SetColor("_EmissionColor", value ? new Color(0.5f, 0.5f, 0.5f, 1) : Color.black);
        material.EnableKeyword("_EMISSION");
    }

    public void PartIsPointed()
    {
        SetHighlighted(true);
        highlighted = gameObject.GetComponent<RamenPart>();

        partNameText.gameObject.SetActive(true);

        partNameText.transform.position = transform.position;
        partNameText.text = PartName;
    }

    public void PartExitedPointed()
    {
        highlighted.SetHighlighted(false);
        partNameText.gameObject.SetActive(false);

    }
}
