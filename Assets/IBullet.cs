using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    public enum BulletType
    {
        Standerd,
        Laser,
    }

    public enum BulletEventType
    {
        HitTank,
        HitWall,
        Died,
    }

    public struct HitTankEventData
    {
        public int TankID;
    }

    public struct HitWallEventData
    {
        public int TileX;
        public int TileY;
        public Tile.Direction Direction;
    }

    public struct DiedEventData
    {
        
    }

    public struct BulletEvent
    {
        public Type type;

        HitTankEventData HitTankData;
        HitWallEventData HitWallData;
        DiedEventData DiedData;
    }

    public interface IBullet
    {
        /// <summary>
        /// Returns the type of the bullet
        /// </summary>
        /// <returns></returns>
        public BulletType GetBulletType();

        /// <summary>
        /// Returns the latset event if there is any
        /// </summary>
        public BulletEvent? GetEvent();

        /// <summary>
        /// Updates the bullet pos
        /// </summary>
        public void Update(Map map);
    }
}
