using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    public class PlayerTankControler : ITankControler
    {
        public bool WannaMoveForward = false;
        public bool WannaMoveBackward = false;
        public bool WannaShoot = false;
        public float WannaRotate = 0f;

        public bool MoveForward(Map map)
        {
            if (WannaMoveForward)
            {
                WannaMoveForward = false;
                return true;
            }
            return false;
        }

        public bool MoveBackwards(Map map)
        {
            if (WannaMoveBackward)
            {
                WannaMoveBackward = false;
                return true;
            }
            return false;
        }

        public bool Shoot(Map map)
        {
            if (WannaShoot)
            {
                WannaShoot = false;
                return true;
            }
            return false;
        }

        public bool Turn(Map map, out float rotations)
        {
            rotations = WannaRotate;
            if (WannaRotate == 0f)
                return false;
            return true;
        }
    }
}
