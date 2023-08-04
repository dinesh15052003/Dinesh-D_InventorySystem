using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiUIPosition : MonoBehaviour
{
    private RectTransform rectTransform;
    public int side;

    // Start is called before the first frame update
    void Awake()
    {
        // Get a reference to the RectTransform of the UI Image
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.localPosition = new Vector3(side * Screen.width / 4, 0.0f, 0.0f); 
    }
}
