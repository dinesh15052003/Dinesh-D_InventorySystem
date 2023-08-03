using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiUIPosition : MonoBehaviour
{
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Awake()
    {
        // Get a reference to the RectTransform of the UI Image
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.sizeDelta = new Vector2(Screen.width/2, Screen.height);
    }
}
