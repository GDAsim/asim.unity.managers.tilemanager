using System.Collections.Generic;

using UnityEngine;

namespace Asim.Managers.TileManager
{
    /// <summary>
    /// Tilemanager controls multiple tilesets
    /// </summary>
    public abstract class TileManager<T, Ts> : MonoBehaviour
        where T : ITile
        where Ts : Tileset<T>
    {
        /// <summary>
        /// Holds a list of tilesets
        /// </summary>
        public List<Ts> Tilesets = new List<Ts>();

        /// <summary>
        /// Reset the entire tilemanager , clearing all tilesets
        /// </summary>
        public void Reset()
        {
            /*Remove all tilesets - means also destorying gameobject and clearing list*/
            foreach (Ts tileset in Tilesets)
            {
                tileset.RemoveAll();
            }
            Tilesets.Clear();
        }
    }
}