using System;
using System.Collections.Generic;

namespace asim.unity.managers.tilemanager
{
    public class SimpleTileset : Tileset<SimpleTile>
    {
        public SimpleTileset(SimpleTile[,] InitialTileData) : base(InitialTileData) { }

        public override void AddTiles(List<Tuple<int,int,SimpleTile>> rowColTileList,bool replaceExisting)
        {
            foreach (Tuple<int, int, SimpleTile> rowColTile in rowColTileList)
            {
                int rowIndex = rowColTile.Item1;
                int colIndex = rowColTile.Item2;
                SimpleTile tileToAdd = rowColTile.Item3;

                SimpleTile currentTile = TileData[rowIndex, colIndex];

                //Check if theres an existing tile and remove it
                if (currentTile && replaceExisting)
                {
                    currentTile.DestoryTile(true);
                }

                TileData[rowIndex, colIndex] = tileToAdd;
            }
        }

        public override void RemoveTiles(List<Tuple<int, int>> rowColList)
        {
            foreach (Tuple<int, int> rowcol in rowColList)
            {
                int rowIndex = rowcol.Item1;
                int colIndex = rowcol.Item2;

                SimpleTile currentTile = TileData[rowIndex, colIndex];

                //Check if theres an existing tile and remove it
                if (currentTile)
                {
                    currentTile.DestoryTile(true);
                }

                TileData[rowIndex, colIndex] = currentTile;
            }
        }
    }
}
