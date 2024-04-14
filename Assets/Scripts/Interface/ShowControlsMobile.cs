using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowControlsMobile : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(Application.isMobilePlatform);
    }
}
