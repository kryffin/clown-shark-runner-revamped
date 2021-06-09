using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorderUI : MonoBehaviour
{

    public Image topBorder, bottomBorder, leftBorder, rightBorder;

    private float areaWidthBy2 = 9.5f;
    private float areaHeight = 14f;

    private float widthOffset = 8f;
    private float heightOffset = 6f;

    private Color borderColor = new Color(0f, 0f, 0f, 0f);

    private void Update()
    {
        // Top
        borderColor.a = (Mathf.Clamp(transform.position.y, areaHeight - heightOffset, areaHeight) - (areaHeight - heightOffset)) / heightOffset;
        topBorder.color = borderColor;

        // Bottom
        borderColor.a = 1f - (Mathf.Clamp(transform.position.y, 0f, heightOffset) / heightOffset);
        bottomBorder.color = borderColor;

        // Right
        borderColor.a = (Mathf.Clamp(transform.position.x, areaWidthBy2 - widthOffset, areaWidthBy2) - (areaWidthBy2 - widthOffset)) / widthOffset;
        rightBorder.color = borderColor;

        // Left
        borderColor.a = (Mathf.Clamp(transform.position.x, -areaWidthBy2, -(areaWidthBy2 - widthOffset)) + (areaWidthBy2 - widthOffset)) / -widthOffset;
        leftBorder.color = borderColor;
    }

}
