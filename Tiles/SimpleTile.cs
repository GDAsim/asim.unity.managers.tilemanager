using System;
using UnityEngine;

namespace asim.unity.managers.tilemanager
{
    /// <summary>
    /// Represent a simple tile in Unity that is either Passable or InPassableTile type
    /// this tile is so simple, that it does not keep track of any of its own data except its tile type
    /// </summary>
    public class SimpleTile : MonoBehaviour, ITile
    {
        public enum Type
        {
            Blank,
            InPassable,
            Passable
        }

        public Type Tiletype { get; private set; }
        public Sprite SpriteImg { get; private set; }

        SpriteRenderer spriteRenderer;
        public static SimpleTile CreateTile(string name,Type tilecode,Sprite sprite)
        {
            GameObject newGO = new GameObject(name);

            SimpleTile newSimpleTile = newGO.AddComponent<SimpleTile>();
            newSimpleTile.Tiletype = tilecode;
            newSimpleTile.SpriteImg = sprite;

            newSimpleTile.spriteRenderer = newGO.AddComponent<SpriteRenderer>();
            newSimpleTile.spriteRenderer.sprite = sprite;

            return newSimpleTile;
        }

        /// <summary>
        /// simply change gameobject name, tile type, and sprite
        /// </summary>
        public void ChangeTile<T>(string newName, T newTiletype, Sprite newSprite) where T : Enum
        {
            if (newTiletype is Type)
            {
                name = newName;
                Tiletype = (Type)(object)newTiletype;
                SpriteImg = newSprite;
            }
            else
            {
                throw new Exception("wrong type");
            }
        }

        /// <summary>
        /// simply destory
        /// </summary>
        public void DestoryTile(bool destoryGO)
        {
            if (destoryGO) Destroy(gameObject);
            else Destroy(this);
        }
    }
}