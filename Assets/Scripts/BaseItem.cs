using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : MonoBehaviour
{
    [Header("Image")]
    public Sprite image;

    [Header("Data")]
    public int ID;
    public string Name;
    public string Description;
    public int count = 1;

    private float hoverAmplitude = 0.1f;
    private float hoverFrequency = 1.0f;
    private float rotationSpeed = 30.0f;

    private Vector3 originalPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Save the original position for reference
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Hover and rotate the item slowly in the world
        Hover();
        Rotate();
    }
    private void Hover()
    {
        // Calculate the vertical hover offset based on time and amplitude
        float yOffset = Mathf.Sin(Time.time * hoverFrequency) * hoverAmplitude;

        // Update the item's position
        transform.position = originalPosition + Vector3.up * yOffset;
    }

    private void Rotate()
    {
        // Rotate the item slowly around its Y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
