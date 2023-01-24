using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    public interface ITankControler
    {
        /// <summary>
        /// Indicates it the controler wants the tank to move forward
        /// </summary>
        /// <returns></returns>
        public bool MoveForward(Map map);

        /// <summary>
        /// Indicates it the controler wants the tank to move backforwards
        /// </summary>
        /// <returns></returns>
        public bool MoveBackwards(Map map);

        /// <summary>
        /// Indicates it the controler wants the tank to move forward
        /// </summary>
        /// <returns></returns>
        public bool Turn(Map map, out float rotations);

        /// <summary>
        /// Indicates it the controler wants the tank to shoot
        /// </summary>
        /// <returns></returns>
        public bool Shoot(Map map);
    }
}
