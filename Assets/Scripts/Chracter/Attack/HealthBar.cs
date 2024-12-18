using UnityEngine;
using UnityEngine.UI;

namespace Chracter
{
    public class HealthBar : MonoBehaviour
    {
        // Start is called before the first frame update
    
        public Slider slider;
        public Color Low;
        public Color High;
        public GameObject Fill;

        [SerializeField] Sprite Green;
        [SerializeField] Sprite Red;
        [SerializeField] Sprite Blue;

        public Vector3 offset;
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position) + offset;
        }


        public void SetHealthBarColor(string team)
        {
            if(team=="Team")
            {
                Fill.GetComponent<Image>().sprite = Green;
            }
            else if(team=="Enemy")
            {
                Fill.GetComponent<Image>().sprite = Red;
            }
            else
            {
                Fill.GetComponent<Image>().sprite = Blue;
            }
        }

    
        public void SetHealth(float health, float maxHealth)
        {       
            if (health <= 0)
            {
                slider.gameObject.SetActive(false);
                return;
            }
            
            slider.gameObject.SetActive(health < maxHealth);
            slider.value = health;
            slider.maxValue = maxHealth;
            //Fill.GetComponent<Image>().color = Color.Lerp(Low, High, slider.normalizedValue);
        }

        public void TowerHealth(float health, float maxHealth)
        {
            slider.gameObject.SetActive(true);
            slider.value = health;
            slider.maxValue = maxHealth;
            //Fill.GetComponent<Image>().color = Color.Lerp(Low, High, slider.normalizedValue);
        }
    }
}
