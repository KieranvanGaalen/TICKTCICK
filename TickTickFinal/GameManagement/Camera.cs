using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Camera
{
    public Vector2 position = new Vector2(0, 0);
    protected GameEnvironment parent;

    public Camera(GameEnvironment parent)
    {
        this.parent = parent;
    }

    public Matrix GetCameraPosition(InputHelper inputHelper)
    {
        return Matrix.CreateTranslation(parent.GraphicsDevice.Viewport.X + position.X, parent.GraphicsDevice.Viewport.Y + position.Y, 0) * Matrix.CreateScale(inputHelper.Scale.X, inputHelper.Scale.Y, 1);
    }

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
        if (CheckPlayerPositionYtop(player.Position, windowSize))
        {
            position.Y = -player.Position.Y + windowSize.Y * .10f;
        }
        if (CheckPlayerPositionYbottom(player.Position, windowSize))
        {
            position.Y = -player.Position.Y + windowSize.Y * .90f;
        }        
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
