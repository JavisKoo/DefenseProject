using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Chracter;
using UnityEngine;
using UnityEngine.UI;


public class MainCharHPBar : MonoBehaviour
{
    [SerializeField]
    private BaseCharacter character = null;
    
    [SerializeField]
    private Slider slider = null;
    
    [SerializeField]
    private Text text = null;
    
    private bool isDead = false;
    
    [SerializeField]
    private Text TxtCountDown = null;
    
    // Start is called before the first frame update
    void Start()
    {
        TxtCountDown.text = "60";
        TxtCountDown.gameObject.SetActive(false);
        slider.maxValue = character.MaxHealth;
        slider.value = character.MaxHealth;
        text.text = character.MaxHealth + "/" + character.MaxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        SetHealth();
    }
    
    public void SetHealth()
    {
        slider.value = character.CurrentHealth;
        slider.maxValue = character.MaxHealth;
        text.text = character.CurrentHealth + "/" + character.MaxHealth;
        
        if(slider.value <= 0)
        {
            isDead = true;
        }
    }
    
    public void countDown()
    {
        StartCoroutine(CCountDown());
    }
    
    private IEnumerator CCountDown()
    {
        yield return new WaitForSeconds(1);
        int count = int.Parse(TxtCountDown.text);
        count--;
        TxtCountDown.text = count.ToString();
        if (count > 0)
        {
            StartCoroutine(CCountDown());
        }
        SetHealth();
    }
}
