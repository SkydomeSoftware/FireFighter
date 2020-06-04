using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Quests : MonoBehaviour
{
    public float time;
    public float timeEnd;
    public bool[] questArray;
    public string[] questDoneString;
    public GameObject informationOnScreen;
    public GameObject pager;


    public static Quests Instance { get; private set; }
   
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        pager.gameObject.SetActive(true);
      
    }




    private void Update()
    {
        clearText();
        timeEnd += Time.deltaTime;
    }
    public void clearText()
    {
        if (time >= 0)
        {
            time -= 0.01f;
        }
        else
        {
            pager.SetActive(false);
            informationOnScreen.GetComponent<Text>().text = "";
        }
    }
    public void DoneQuest(int questID)
    {
        questArray[questID] = true;
        WriteOnScreen(3f, questDoneString[questID]);
    }
    public void WriteOnScreen(float waitTime, string message)
    {
        time = waitTime;
        pager.SetActive(true);
        informationOnScreen.GetComponent<Text>().text = message;
    }

    public bool IsAllMissionComplete(int questID)
    {
        for (int i = 0; i < questID; ++i)
        {
            if (questArray[i] == false)
            {
                pager.SetActive(true);
                WriteOnScreen(4f, "You forgot about something");
                return false;
            }
        }
        return true;
    }
}
