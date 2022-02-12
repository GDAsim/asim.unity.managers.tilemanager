using System;
using System.Collections.Generic;

namespace asim.unity.managers.tilemanager
{
    /// <summary>
    /// Tileset represent a set a tiles
    /// also keep tracks and manages the tiles position in the index
    /// </summary>
    public abstract class Tileset<Tile> where Tile : ITile
    {
        public Tile[,] TileData;

        public Tileset(Tile[,] InitialTileData)
        {
            TileData = InitialTileData;
        }

        /// <summary>
        /// For inherit to add tiles at certain index
        /// </summary>
        public abstract void AddTiles(List<Tuple<int, int, SimpleTile>> rowColTileList, bool replaceExisting);

        /// <summary>
        /// For inherit to remove certain index tiles
        /// </summary>
        public abstract void RemoveTiles(List<Tuple<int, int>> rowColList);

        /// <summary>
        /// To remove all tiles
        /// </summary>
        public virtual void RemoveAll()
        {
            if (TileData == null) return;

            for (int i = 0; i < TileData.GetLength(0); i++)
            {
                for (int j = 0; j < TileData.GetLength(1); j++)
                {
                    Tile tile = TileData[i, j];
                    if(tile != null)
                    {
                        tile.DestoryTile(true);
                    }
                }
            }
            TileData = null;
        }
    }
}
