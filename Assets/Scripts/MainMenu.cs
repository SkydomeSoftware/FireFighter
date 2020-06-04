using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject StartButton;
    public GameObject InputFieldName;


    public void StartGame()
    {
        if(InputFieldName.GetComponent<InputField>().text != "")
        {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }
        else
        {
            InputFieldName.GetComponent<Image>().color = Color.red;
        }
    }
}
