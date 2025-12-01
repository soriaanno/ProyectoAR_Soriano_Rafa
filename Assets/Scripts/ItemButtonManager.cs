using UnityEngine;
using UnityEngine.UI;

public class ItemButtonManager : MonoBehaviour
{
    private string itemName;
    private string itemDescription;
    private Sprite itemImage;
    private GameObject item3DModel;

    // Propiedades completas con getter y setter
    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }

    public string ItemDescription
    {
        get { return itemDescription; }
        set { itemDescription = value; }
    }

    public Sprite ItemImage
    {
        get { return itemImage; }
        set { itemImage = value; }
    }

    public GameObject Item3DModel
    {
        get { return item3DModel; }
        set { item3DModel = value; }
    }

    void Start()
    {
        // Comprueba que los elementos existen antes de asignar
        if (transform.childCount >= 3)
        {
            var nameText = transform.GetChild(0).GetComponent<Text>();
            if (nameText != null) nameText.text = itemName;

            var imageRaw = transform.GetChild(1).GetComponent<RawImage>();
            if (imageRaw != null && itemImage != null) imageRaw.texture = itemImage.texture;

            var descText = transform.GetChild(2).GetComponent<Text>();
            if (descText != null) descText.text = itemDescription;
        }

        // Añade listeners al botón
        var button = GetComponent<Button>();
        if (button != null)
        {
            if (GameManager.instance != null)
                button.onClick.AddListener(GameManager.instance.ARPosition);

            button.onClick.AddListener(Create3DModel);
        }
    }

    private void Create3DModel()
    {
        if (item3DModel != null)
            Instantiate(item3DModel);
    }
}
