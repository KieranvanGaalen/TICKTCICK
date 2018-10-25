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
        protected Vector2 position = new Vector2(0,0);

        public void AdjustCameraPosition(Player player, Point windowSize)
        {
            if (CheckPlayerPositionXleft(player.Position, windowSize))
            {
                position.X = -player.Position.X + windowSize.X * .20f;
            }
            if (CheckPlayerPositionXright(player.Position, windowSize))
            {
                position.X = -player.Position.X + windowSize.X * .80f;
            }
            /*if (CheckPlayerPositionYtop(player.Position, windowSize))
            {
                position.Y = -player.Position.Y + windowSize.Y * .10f;
            }
            if (CheckPlayerPositionYbottom(player.Position, windowSize))
            {
                position.Y = -player.Position.Y + windowSize.Y * .90f;
            }*/
        }

        protected bool CheckPlayerPositionXleft(Vector2 playerPosition, Point windowSize)
        {
            if (playerPosition.X < windowSize.X * .20f - position.X)
                return true;
            else
                return false;
        }

        protected bool CheckPlayerPositionXright(Vector2 playerPosition, Point windowSize)
        {
            if (playerPosition.X > windowSize.X * .80f - position.X)
                return true;
            else
                return false;
        }

        protected bool CheckPlayerPositionYtop(Vector2 playerPosition, Point windowSize)
        {
            if (playerPosition.Y < (windowSize.Y * .10f) + position.Y)
                return true;
            else
                return false;
        }

        protected bool CheckPlayerPositionYbottom(Vector2 playerPosition, Point windowSize)
        {
            if (playerPosition.Y > windowSize.Y * .90f + position.Y)
                return true;
            else
                return false;
        }

        public virtual Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
