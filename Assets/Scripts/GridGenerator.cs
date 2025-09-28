using UnityEngine;

// This attribute allows the script to run in the editor.
[ExecuteInEditMode]
public class GridGenerator : MonoBehaviour
{
    public GameObject tilePrefab;
    public int width = 10;
    public int height = 10;
    public float tileSize = 2.0f;  

    // The ContextMenu attribute adds a right-click option in the Inspector.
    [ContextMenu("Generate Grid")]
    void GenerateGrid()
    {
        // Clear any existing tiles before generating a new grid.
        // This prevents creating multiple grids on top of each other.
        int childCount = transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                Vector3 position = new Vector3(x * tileSize, 0, z * tileSize);
                // Instantiate the tile in the editor
                GameObject newTile = Instantiate(tilePrefab, position, Quaternion.identity);
                newTile.transform.SetParent(this.transform);
                newTile.name = $"Tile_{x}_{z}";
            }
        }
    }
}