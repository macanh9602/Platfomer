using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public GameObject panel;
    // Start is called before the first frame update
    public void Openpanel1()
    {
        panel.SetActive(true);
    }
    public void ClosePanel1()
    {
        panel.SetActive(false);
    }
}
