using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{

    public class Tank
    {
        public ITankControler TankControler;
        public Vector2 Positions;
        public float Rotation;
        public float Speed;

        public Tank(ITankControler tankControler, Vector2 positions, float rotation, float speed)
        {
            TankControler = tankControler;
            Positions = positions;
            Rotation = rotation;
            Speed = speed;
        }

        public void Turn(float rotation)
        {
            Rotation += rotation;
            while (Rotation > 360)
            {
                Rotation -= 360;
            }
            while (Rotation < 0)
            {
                Rotation += 360;
            }
        }

        public void MoveForward(float scale)
        {
            Vector2 vec = new Vector2(Mathf.Cos(Rotation), Mathf.Sin(Rotation));
            vec *= scale * Speed;
            Positions += vec;
        }

        public void MoveBackward(float scale)
        {
            MoveForward(-scale); // Don't know if this will work <3
        }
    }
}