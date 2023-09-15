using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    private int height = 40;
    private int width = 40;
    private float GridSpaceSize = 4f;

    public GameObject[,] gameGrid;

    public GameObject gridCellPrefab;

    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        gameGrid = new GameObject[height, width];
        if (gridCellPrefab == null)
        {
            return;
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < height; x++)
            {
                gameGrid[x, y] = Instantiate(gridCellPrefab, new Vector3(x * GridSpaceSize, 6.030694f, y * GridSpaceSize), Quaternion.identity);
                gameGrid[x, y].GetComponent<GridCell>().SetPosition(x, y);
                gameGrid[x, y].transform.parent = transform;
                float yRotation = 90.0f;
                gameGrid[x, y].transform.eulerAngles = new Vector3(yRotation, transform.eulerAngles.y, transform.eulerAngles.z);
                
                gameGrid[x, y].gameObject.name = "Grid Space(x: " + x.ToString() + " , y: " + y.ToString() + ")";
            }
        }
    }
    public Vector2Int GetGridPosFromWorld(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / GridSpaceSize);
        int y = Mathf.FloorToInt(worldPosition.z / GridSpaceSize);

        x = Mathf.Clamp(x, 0, width);
        y = Mathf.Clamp(x, 0, height);

        return new Vector2Int(x, y);
    }

    public Vector3 GetWorldPosFromGridPos(Vector2Int gridPos)
    {
        float x = gridPos.x * GridSpaceSize;
        float y = gridPos.y * GridSpaceSize;

        return new Vector3(x, 0, y);
    }
}
