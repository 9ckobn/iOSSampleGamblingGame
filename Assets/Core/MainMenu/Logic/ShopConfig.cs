using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ShopConfig")]
public class ShopConfig : ScriptableObject
{
    public List<Slot> slots;
}

[Serializable]
public struct Slot
{
    public string name, description;
}