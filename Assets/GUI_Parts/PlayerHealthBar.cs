using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Slider healthbarSlider;
    
    public void GiveFullHealth(float health)
    {
        healthbarSlider.maxValue = health;
        healthbarSlider.value = health;
    }

    public void setHealth(float health)
    {
        healthbarSlider.value = health;
    }

}
