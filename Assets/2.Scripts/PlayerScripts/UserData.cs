using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UserData
{
    public static UserData Instance;
    
    [Header("Player Settings")] 
    public string Name { get; private set; }
    public int Money { get; private set; }
    public float Health { get; set; }
    public float Mana { get; set; } 
    public float moveSpeed = 1.0f;
    public float Attack { get; set; }
    public float Hunger { get; set; }

    public UserData(string name, int money, float health, float mana, float hunger, float attack)
    {
        Name = name;
        Money = money;
        Health = health;
        Mana = mana;
        Hunger = hunger;
        Attack = attack;
    }
    
    public void IncreaseMoney(int amount)
    {
        int MaxMoney = 100000000;
        if (Money > MaxMoney)
        {
           Money =Mathf.Clamp(Money, 0, 100000000);
        }
        Money += amount;
    }
    
    public void DecreaseMoney(int amount)
    { 
        int MinMoney = 0;
        if (Money < MinMoney)
        {
            Money = Mathf.Clamp(Money, 0, 100000000);
        }
        
        Money -= amount;
    }
}
