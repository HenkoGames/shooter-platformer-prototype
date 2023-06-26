using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public HealthBar healthBar;
    private bool haveHealthBar = false;
    [Space]
    public float healtPoints;
    public int maxHealthPoints;
    [Space]
    //Team is group of object that get hits. This variable helps AI find enemies and friends. Also make shells do not damage shooters
    //0 - props. Can take damage from everyone but enemies dont mark it like main for them
    //1 - player. Enemies choose objects from this team for targeting
    //2 - enemies. 
    //teams list can be appended
    public int team;
    
    void Awake()
    {
        try
        {
            healthBar.hp = GetComponent<HealthPoints>();
            haveHealthBar = true;
        }
        catch
        {
            haveHealthBar = false;
        }
        healtPoints = maxHealthPoints;
    }

    public void GetDamage(float value)
    {
        if(value >= healtPoints)
        {
            Dead();
        }
        else
        {
            healtPoints -= value;
            healthBar.SetValue(healtPoints, maxHealthPoints);
        }
    }
    public void Dead()
    {
        VXDead();
        Destroy(gameObject);
    }
    public void VXDead()
    {

    }
}
