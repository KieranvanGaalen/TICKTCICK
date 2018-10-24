using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTick5.GameManagement
{
    class Camera
    {
        public Vector2 position;

        public void AdjustCameraPosition(Vector2 Position, Point windowSize)
        {
            if(CheckPlayerPositionX(Position, windowSize))
            {
                //DOE HIER NOG IETS.
            }
        }

        static bool CheckPlayerPositionX(Vector2 Position, Point windowSize)
        {
            if (Position.X > windowSize.X * .75 || Position.X < windowSize.X * .25)
                return true;
            else
                return false;
        }

        static bool CheckPlayerPositionY(Vector2 Position, Point windowSize)
        {
            if (Position.Y > windowSize.Y * .75 || Position.Y < windowSize.Y * .25)
                return true;
            else
                return false;
        }
    }
}
