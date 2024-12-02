using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/ItemData")]
public class ItemData : ScriptableObject
{
    public enum ItemType {
        Warrior,   //0
        Thief,     //1
        Archer,    //2
        Goblin,    //3
        Slime,     //4
        Wizard,    //5
        MagicWarrior, //6
        Minotaur,  //7
        Centaur,   //8
        Golem,     //9
        Paladin,   //10
        DeerWarrior, //11
        WoodGolem, //12
        Elementalist, //13
        Dragon,     //14


        Empty      //100
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
