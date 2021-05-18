using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileWriter : MonoBehaviour
{
    private const string fileName = "save.dat";

    private void Start()
    {
        WriteData();
    }

    private void Tiles()
    {   
        ///EJEMPLO

        Tile[] allTiles = FindObjectsOfType<Tile>(); //Opción 1
        //GameObject map = null;
        //Tile[] t = map.GetComponentsInChildren<Tile>();

        //Paso 2 - Ordenar la lista de tiles en una matriz
        int maxX = 0;
        int maxZ = 0;

        float xTemp = 0;
        for (int i = 0; i < allTiles.Length; i++)
        {
            if (xTemp < allTiles[i].transform.position.x)
            {
                xTemp = allTiles[i].transform.position.x;
            }
        }   
        
        float zTemp = 0;
        for (int i = 0; i < allTiles.Length; i++)
        {
            if (zTemp < allTiles[i].transform.position.x)
            {
                zTemp = allTiles[i].transform.position.x;
            }
        }

        maxX = Mathf.RoundToInt(xTemp);
        maxZ = Mathf.RoundToInt(xTemp);

        //Crear Matriz
        Tile[][] tiles = new Tile[maxX + 1][];
        for (int i = 0; i < tiles[i].Length; i++)
        {
            tiles[i] = new Tile[maxZ + 1];
        }

        //Añadir cada tile en su posición

        for (int i = 0; i < allTiles.Length; i++)
        {
            int positionxX = Mathf.RoundToInt(allTiles[i].transform.position.x); //Posición X de la Tile, x = 2
            int positionxZ = Mathf.RoundToInt(allTiles[i].transform.position.z); //Posición z de la Tile, z = 4

            tiles[positionxX][positionxZ] = allTiles[i];
        }

        //Paso 3 - Escribir la matriz en un arreglo de strings
        //Escribir si una tile puede o no poner una torre
        for (int x = 0; x < tiles.Length; x++)
        {
            for (int z = 0; z < tiles[x].Length; z++)
            {
                if (tiles[x][z].CanBuildTower())
                {
                    Debug.Log("La tile " + tiles[x][z].name + "o");
                }
                else
                {
                    Debug.Log("La tile " + tiles[x][z].name + "x");
                }
            }
        }

        string[] lines = new string[tiles[0].Length];

        string[] lines = new string[tiles[0].Length];
        lines[] = line;
        lines[0] += "o";

        if (tiles[x][z].CanBuildTower())
        {
            line += "o";
        }
        else
        {
            lines += "x"
        }

        //Paso 4 - Escribir ese arreglo de strings a un archivo
        File.WriteAllLines(path, lines);
    }

    private void WriteData()
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        string data = "My save data.";
        Debug.Log("Path: " + path);

        File.WriteAllText(path, data);
    }
}
