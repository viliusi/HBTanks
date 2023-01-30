using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class Tank : MonoBehaviour
    {
        public Rigidbody2D body;
        
        public ITankControler TankControler;
        public float Speed;
        public bool Alive;

        public Tank(ITankControler tankControler, Vector2 positions, float rotation, float speed, float bodyWidth, float bodyHeight)
        {
            TankControler = tankControler;
            Speed = speed;
            Alive = true;
        }

        public void Turn(float rotation)
        {
        }

        public void MoveForward(float scale)
        {
        }

        public void MoveBackward(float scale)
        {
            MoveForward(-scale); // Don't know if this will work <3
        }
    }
}