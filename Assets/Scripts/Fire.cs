using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public static Fire Instance { get; private set; }
    
    
    public float fireHP;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
   public void extinguish()
    {
        fireHP--;
        if (fireHP <= 0)
        {
            Destroy(this.gameObject);
            Quests.Instance.WriteOnScreen(6f, $"Great! You done mission in: {Quests.Instance.timeEnd.ToString("0.00")}s");
        }
    }
}
