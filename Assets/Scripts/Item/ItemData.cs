using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/ItemData")]
public class ItemData : ScriptableObject
{
    public enum ItemType {
        Empty, //비어있을때
        Warrior,
        Wizard,
        Archer,
        Thief,
        Goblin, //적 유닛인데 일단 추가
        Slime,  //적 유닛인데 일단 추가
    }

    [Header("# Main Info")]
    public ItemType itemType;
    public int itemId;
    public string itemName;

    public string itemDesc;
    public Sprite itemIcon;

    [Header("# Level Data")]
    public int level;
    /*public float baseDamage;
    public int baseCount;
    public float[] damages;
    public int[] counts;*/

    /*[Header("# Character Obj")]
    public GameObject Character;*/

    [Header("# Cost Data")]
    public int cost;
}
