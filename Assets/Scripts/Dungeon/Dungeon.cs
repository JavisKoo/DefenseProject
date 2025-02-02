using UnityEngine;


[CreateAssetMenu(fileName = "Dungeon", menuName = "Scriptable Object/Dungeon")]
public class Dungeon : ScriptableObject
{
    public int dungeonNum;
    public bool isClear = false;
    public string[] dungeonUnits;
    public string dungeonBoss;
}
