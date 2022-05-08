using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MapScreenshot : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private string textureName;

    [ContextMenu("Screenshot")]
    private void PerformShot()
    {
        TakeScreenshot($"{Application.dataPath}/Textures/{textureName}.png");
    }

    private void TakeScreenshot(string dirPath)
    {
        if (camera == null)
        {
            camera = GetComponent<Camera>();
        }

        RenderTexture rt = new RenderTexture(256, 256, 24);
        camera.targetTexture = rt;
        Texture2D screenshot = new Texture2D(256, 256, TextureFormat.RGBA32, false);
        camera.Render();

        RenderTexture.active = rt;
        screenshot.ReadPixels(new Rect(0, 0, 256, 256), 0, 0);

        camera.targetTexture = null;
        camera.targetTexture = null;

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
