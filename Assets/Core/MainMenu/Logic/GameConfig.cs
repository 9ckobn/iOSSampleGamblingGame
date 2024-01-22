using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "400usd4/GameConfig")]
public class GameConfig : ScriptableObject
{
    public List<levPrefabKvp> config;
}

[Serializable]
public class levPrefabKvp
{
    public int index;
    public GameController prefab;
}