using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public struct Body
    {
        public Vector2 Positions;
        public float Rotation;
        public float Width;
        public float Height;

        public Body(Vector2 positions, float rotation, float width, float height)
        {
            Positions = positions;
            Rotation = rotation;
            Width = width;
            Height = height;
        }
    }

    public class Tank
    {
        public ITankControler TankControler;
        public Body Body;
        public float Speed;
        public bool Alive;

        public Tank(ITankControler tankControler, Vector2 positions, float rotation, float speed, float bodyWidth, float bodyHeight)
        {
            TankControler = tankControler;
            Body = new Body(positions, rotation, bodyWidth, bodyWidth);
            Speed = speed;
            Alive = true;
        }

        public void Turn(float rotation)
        {
            Body.Rotation += rotation;
            while (Body.Rotation > 360)
            {
                Body.Rotation -= 360;
            }
            while (Body.Rotation < 0)
            {
                Body.Rotation += 360;
            }
        }

        public void MoveForward(float scale)
        {
            Vector2 vec = new Vector2(Mathf.Cos(Body.Rotation), Mathf.Sin(Body.Rotation));
            vec *= scale * Speed;
            Body.Positions += vec;
        }

        public void MoveBackward(float scale)
        {
            MoveForward(-scale); // Don't know if this will work <3
        }
    }
}