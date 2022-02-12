using UnityEngine;

using System.Collections.Generic;

namespace Asim.Managers.TileManager
{
    public class SimpleTile_TileManager : TileManager<SimpleTile, SimpleTileset>
    {
        /// <summary>
        /// Singleton instance for other scripts to access
        /// </summary>
        public static SimpleTile_TileManager Instance = null;

        /*Assign Prefab Tiles in Inspector */
        [SerializeField] SimpleTile PassableTile;
        [SerializeField] SimpleTile InPassableTile;
        [SerializeField] char PassableTile_Char = '#';

        List<GameObject> TileSetContainerGO = new List<GameObject>();

        void Awake()
        {
            //Check For Required Things
            if (PassableTile == null) throw new UnassignedReferenceException("Assign PassableTile in Inspector!");
            if (InPassableTile == null) throw new UnassignedReferenceException("Assign PassableTile in Inspector!");

            if (Instance == null)
                Instance = this;
            else if (Instance != this)
            {
                Debug.LogWarning("There is already a TileManager in the Game. Removing TileManager from " + name);
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        /// <summary>
        /// Process the input char array
        /// </summary>
        public SimpleTileset SpawnTilesetFromCharArray(char[][] tilemapchararray)
        {
            if (tilemapchararray == null) return null;

            //1. Find the max length of cols needed : note that input is a jagged array
            int maxColCount = 0;
            for (int i = 0; i < tilemapchararray.Length; i++)
            {
                char[] row = tilemapchararray[i];
                if (maxColCount < row.Length) maxColCount = row.Length;
            }

            //2. Create our tiles data struct
            SimpleTile[,] simpleTiles = new SimpleTile[tilemapchararray.Length, maxColCount];

            //3. Read though the char array, from the char, create a tile and assign to the struct
            //3a. Create a simple GameObject Container to hold all the tiles
            GameObject STSContainer = new GameObject("SimpleTileSet" + Tilesets.Count);
            TileSetContainerGO.Add(STSContainer);

            for (int i = 0; i < simpleTiles.GetLength(0); i++)
            {
                char[] row = tilemapchararray[i];
                for (int j = 0; j < simpleTiles.GetLength(1); j++)
                {
                    //if the current index goes beyond the chararray, we ignore it
                    if (j >= row.Length) continue;

                    SimpleTile tile;
                    if (row[j] == PassableTile_Char)
                    {
                        tile = Instantiate(PassableTile, STSContainer.transform);
                    }
                    else
                    {
                        tile = Instantiate(InPassableTile, STSContainer.transform);
                    }
                    //Simple Set Position of tiles, base on index
                    tile.transform.localPosition = new Vector3(j, -i, 0);
                    simpleTiles[i, j] = tile;
                }
            }

            //4. Add it into our tilesets
            SimpleTileset STS = new SimpleTileset(simpleTiles);
            Tilesets.Add(STS);

            return STS;
        }

        /// <summary>
        /// Remove all tiles
        /// </summary>
        public void Removetiles()
        {
            foreach (SimpleTileset ts in Tilesets)
            {
                ts.RemoveAll();
            }
            //Also destory the containers
            foreach (GameObject container in TileSetContainerGO)
            {
                Destroy(container);
            }
        }
    }
}
