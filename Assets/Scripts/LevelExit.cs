using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelExit : MonoBehaviour
{
    Collider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(nextLevel());
    }
    IEnumerator nextLevel()
    {
        if (col.IsTouchingLayers(LayerMask.GetMask("Player")))
        {

            yield return new WaitForSecondsRealtime(2f);
            //int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            //if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            //{
            //    SceneManager.LoadScene(nextSceneIndex);
            //    nextSceneIndex = 0;

            //}
            SceneManager.LoadScene(2);


        }

    }


}
