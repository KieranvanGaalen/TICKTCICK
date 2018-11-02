using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Camera
{
    protected Vector2 position = new Vector2(0, 0);
    protected GameEnvironment parent;

    public Camera(GameEnvironment parent)
    {
        this.parent = parent;
    }

    public Matrix GetCameraPosition(InputHelper inputHelper)
    {
        return Matrix.CreateTranslation(parent.GraphicsDevice.Viewport.X + position.X, parent.GraphicsDevice.Viewport.Y + position.Y, 0) * Matrix.CreateScale(inputHelper.Scale.X, inputHelper.Scale.Y, 1);
    }

    public void Update(Player player, Point windowSize, Vector2 LevelSize, GameObjectList backgrounds)
    {
        if (player.IsAlive) {
            if (CheckPlayerPositionXleft(player.Position, windowSize))
            {
                position.X = -player.Position.X + windowSize.X * .20f +1;
                foreach (GameObject a in backgrounds.Children)
                {
                    if (a is Clouds)
                    {
                        GameObjectList cloudList = a as GameObjectList;
                        foreach (SpriteGameObject cloud in cloudList.Children)
                        {
                            cloud.Position = new Vector2(cloud.Position.X + 3, cloud.Position.Y);
                            if (cloud.Position.X + cloud.Width < 0)
                                cloud.Position = new Vector2(windowSize.X, cloud.Position.Y);
                        }
                    }
                    else
                    {
                        SpriteGameObject b = a as SpriteGameObject;
                        if (b.Layer == -4)
                        {
                            b.Position = new Vector2(b.Position.X + 1, b.Position.Y); //om de een of andere rede mogen we niet b.Position.X veranderen, maar wel de hele position.
                            if (b.Position.X + b.Width < 0)
                                b.Position = new Vector2(windowSize.X, b.Position.Y);
                        }
                    }
                }
            }

            else if (CheckPlayerPositionXright(player.Position, windowSize, LevelSize.X))
            {
                position.X = -player.Position.X + windowSize.X * .80f -1;
                foreach (GameObject a in backgrounds.Children)
                {
                    if (a is Clouds)
                    {
                        GameObjectList cloudList = a as GameObjectList;
                        foreach (SpriteGameObject cloud in cloudList.Children)
                        {
                            cloud.Position = new Vector2(cloud.Position.X - 3, cloud.Position.Y);
                            if (cloud.Position.X > windowSize.X)
                                cloud.Position = new Vector2(-cloud.Width, cloud.Position.Y);
                        }
                    }
                    else
                    {
                        SpriteGameObject b = a as SpriteGameObject;
                        if (b.Layer == -4)
                        {
                            b.Position = new Vector2(b.Position.X - 1, b.Position.Y);
                            if (b.Position.X > windowSize.X)
                                b.Position = new Vector2(-b.Width, b.Position.Y);
                        }
                    }
                }
            }

            if (CheckPlayerPositionYtop(player.Position, windowSize))
            {
                position.Y = -player.Position.Y + windowSize.Y * .22f +1;
                GameObjectList cloudList = backgrounds.Find("clouds") as GameObjectList;
                foreach (SpriteGameObject cloud in cloudList.Children)
                {
                    cloud.Position = new Vector2(cloud.Position.X, cloud.Position.Y + 3);
                    if (cloud.Position.Y > windowSize.Y)
                        cloud.Position = new Vector2(cloud.Position.X, -cloud.Height);
                }
            }

            else if (CheckPlayerPositionYbottom(player.Position, windowSize, LevelSize.Y))
            {
                position.Y = -player.Position.Y + windowSize.Y * .78f -1;
                GameObjectList cloudList = backgrounds.Find("clouds") as GameObjectList;
                foreach (SpriteGameObject cloud in cloudList.Children)
                {
                    cloud.Position = new Vector2(cloud.Position.X, cloud.Position.Y - 3);
                    if (cloud.Position.Y < -cloud.Height)
                        cloud.Position = new Vector2(cloud.Position.X, windowSize.Y);
                }
            }
        }
    }

    protected bool CheckPlayerPositionXleft(Vector2 playerPosition, Point windowSize)
    {
        return (playerPosition.X < windowSize.X * .20f - position.X && -position.X > 0);
    }

    protected bool CheckPlayerPositionXright(Vector2 playerPosition, Point windowSize, float LevelWidth)
    {
        return (playerPosition.X > windowSize.X * .80f - position.X && -position.X + windowSize.X < LevelWidth * 72);
    }

    protected bool CheckPlayerPositionYtop(Vector2 playerPosition, Point windowSize)
    {
        return (playerPosition.Y < windowSize.Y * .22f - position.Y);
    }

    protected bool CheckPlayerPositionYbottom(Vector2 playerPosition, Point windowSize, float LevelHeight)
    {
        return (playerPosition.Y > windowSize.Y * .78f - position.Y && -Position.Y + windowSize.Y < LevelHeight * 55);
    }

    public virtual Vector2 Position
    {
        get { return position; }
        set { position = value; }
    }
}
