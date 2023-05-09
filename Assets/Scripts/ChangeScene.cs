using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void GoToGame()
    {
        Debug.Log("Chay vao game di");
        SceneManager.LoadScene(1);
        
    }
}
