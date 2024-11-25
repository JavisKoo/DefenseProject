using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject[] characterPrefab;

    [SerializeField] public int CharacterIndex=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCharacter()
    {
        //spawn character
        Instantiate(characterPrefab[CharacterIndex], transform.position, Quaternion.identity);
        
    }
}
