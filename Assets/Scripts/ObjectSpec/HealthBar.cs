using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public HealthPoints hp;
    [Space]
    public Transform background;
    public Transform current;
    [Space]
    public bool hideWhenMax = true;

    public void Awake()
    {
        if (hideWhenMax)
        {
            current.gameObject.SetActive(false);
            background.gameObject.SetActive(false);
        }
    }
    public void SetValue(float currentHealth, float maxHealth)
    {
        current.localScale = new Vector3(background.localScale.x/maxHealth*currentHealth, current.localScale.y, current.localScale.z);
        current.localPosition = new Vector3(-((background.localScale.x - current.localScale.x)/2), background.localPosition.y, background.localPosition.z);
        if (hideWhenMax)
        {
            if (currentHealth == maxHealth)
            {
                current.gameObject.SetActive(false);
                background.gameObject.SetActive(false);
            }
            else
            {
                current.gameObject.SetActive(true);
                background.gameObject.SetActive(true);
            }
        }
    }

}
