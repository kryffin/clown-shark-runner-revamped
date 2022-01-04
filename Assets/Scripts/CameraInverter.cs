using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInverter : MonoBehaviour
{

    public Shader classicShader = null;
    public Shader invertShader = null;
    private Material m_renderMaterial;

    public bool inverted = false;

    private void Start()
    {
        if (classicShader == null || invertShader == null)
        {
            Debug.LogError("No shaders on camera.");
            m_renderMaterial = null;
            return;
        }
        m_renderMaterial = new Material(classicShader);
    }

    public void Invert()
    {
        // Revert screen to normal or invert it
        if (inverted)
            m_renderMaterial = new Material(classicShader);
        else
            m_renderMaterial = new Material(invertShader);
        inverted = !inverted;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, m_renderMaterial);
    }
}
