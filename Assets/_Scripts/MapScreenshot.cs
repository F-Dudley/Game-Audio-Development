using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapScreenshot : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private string textureName;

    [ContextMenu("Screenshot")]
    private void PerformShot()
    {
        TakeScreenshot($"{Application.dataPath}/Textures/{textureName}.png");
    }

    private void TakeScreenshot(string dirPath)
    {
        if (cam == null)
        {
            cam = GetComponent<Camera>();
        }

        RenderTexture rt = new RenderTexture(256, 256, 24);
        cam.targetTexture = rt;
        Texture2D screenshot = new Texture2D(256, 256, TextureFormat.RGBA32, false);
        cam.Render();

        RenderTexture.active = rt;
        screenshot.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);

        cam.targetTexture = null;
        cam.targetTexture = null;

        if (Application.isEditor)
        {
            DestroyImmediate(rt);
        }
        else
        {
            Destroy(rt);
        }

        byte[] bytes = screenshot.EncodeToPNG();
        System.IO.File.WriteAllBytes(dirPath, bytes);

        #if UNITY_EDITOR
        AssetDatabase.Refresh();
        #endif
    }
}
