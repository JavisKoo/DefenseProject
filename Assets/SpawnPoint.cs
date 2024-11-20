using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject[] characterPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCharacter(int characterIndex)
    {
        //spawn character
        Instantiate(characterPrefab[characterIndex], transform.position, Quaternion.identity);
        
    }
}
