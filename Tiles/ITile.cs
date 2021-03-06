using System;
using UnityEngine;

namespace asim.unity.managers.tilemanager
{
    /// <summary>
    /// Interface for a tile for tilemanager
    /// </summary>
    public interface ITile
    {
        public void ChangeTile<T>(string newName, T newTiletype, Sprite newSprite) where T:Enum;
        public void DestoryTile(bool destoryGO);
    }
}
