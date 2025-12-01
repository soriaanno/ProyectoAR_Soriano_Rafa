using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField] public string ItemName;
    //[SerializeField] public Sprite ItemIcon;
    [SerializeField] public string ItemDescription;
    [SerializeField] public GameObject Item3DModel;
    [SerializeField] public Sprite ItemImage;


}
