using UnityEngine;

[CreateAssetMenu(fileName = "Loot", menuName = "***Scriptable**Objects***/New Loot Object")]
public class Loot : ScriptableObject
{
    public string Name;
    public int spawnChance;
    public Sprite sprite;
}
