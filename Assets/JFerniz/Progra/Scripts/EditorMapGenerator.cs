using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorMapGenerator : MonoBehaviour
{

    [SerializeField] private int width = 10;
    [SerializeField] private int height = 10;
    [SerializeField] GameObject tilePrefab;

    [ContextMenu("Generate Map")]
    private void GenerateMap()
    {
        DestroyAllChildren();

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 position = new Vector3(x, 0f, z);

                GameObject gameObject = PrefabUtility.InstantiatePrefab (tilePrefab, this.transform) as GameObject;
                gameObject.transform.SetPositionAndRotation(position, Quaternion.identity);
                gameObject.name = $"Tile ({x},{z})";
            }
        }
    }

    [ContextMenu("Clean")]
    private void DestroyAllChildren()
    {
        GameObject[] childrenObjects = new GameObject[transform.childCount];
        for (int i = 0; i < childrenObjects.Length; i++)
        {
            childrenObjects[i] = transform.GetChild(i).gameObject;
        }

        for (int i = 0; i < childrenObjects.Length; i++)
        {
            DestroyImmediate(childrenObjects[i]);
        }
    }
}
