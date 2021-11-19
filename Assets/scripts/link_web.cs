using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class link_web : MonoBehaviour
{
    void Start()
    {
        Debug.Log("link_web");
    }

    public void link(string linkweb)
    {
        Application.OpenURL(linkweb);
    }
}
