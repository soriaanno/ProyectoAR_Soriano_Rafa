using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private ItemButtonManager itemButtonManager;

    private void Start()
    {
        if (GameManager.instance != null)
            GameManager.instance.OnItemsMenu += CreateButtons;
        else
            Debug.LogError("GameManager.instance es NULL. Asegúrate de que existe en la escena.");
    }

    private void CreateButtons()
    {
        if (items == null || items.Count == 0)
        {
            Debug.LogWarning("DataManager: No hay items asignados en la lista.");
            return;
        }

        foreach (var item in items)
        {
            if (itemButtonManager == null || buttonContainer == null)
            {
                Debug.LogError("DataManager: itemButtonManager o buttonContainer no asignados.");
                return;
            }

            ItemButtonManager itemButton = Instantiate(itemButtonManager, buttonContainer.transform);

            itemButton.ItemName = item.ItemName;
            itemButton.ItemDescription = item.ItemDescription;
            itemButton.ItemImage = item.ItemImage; // Sprite del Item
            itemButton.Item3DModel = item.Item3DModel;

            itemButton.name = item.ItemName;
        }

        if (GameManager.instance != null)
            GameManager.instance.OnItemsMenu -= CreateButtons;
    }
}
