using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

class SmallBomb : Rocket
{
    protected bool isSpawned;
    
    public SmallBomb(bool moveToLeft, Vector2 startPosition, Vector2 levelSize, TileField tiles) : base(moveToLeft, startPosition, levelSize, tiles)
    {
        LoadAnimation("Sprites/spr_smallbomb@1", "default", true, 0.2f); //moeten we veranderen.
        PlayAnimation("default");
    }

    public override bool IsSpawned(GameTime gameTime) 
    {
        return isSpawned;
    }

    public override void Reset()
    {
        visible = false;
        velocity = Vector2.Zero;
        isSpawned = false;
    }

    public override void CheckCollisions() 
    {
        if (TickTick.GameStateManager.CurrentGameState is PlayingState) 
        {
            PlayingState state = TickTick.GameStateManager.CurrentGameState as PlayingState;
            GameObjectList enemies = state.CurrentLevel.Find("enemies") as GameObjectList;
            foreach (AnimatedGameObject obj in enemies.Children)
            {
                if (obj is Turtle)
                    continue; //Want turtles kunnen soms nodig zijn om een level te halen.
                if (CollidesWith(obj))
                {
                    if (obj is Rocket)
                        obj.Reset();
                    else
                        obj.Visible = false;
                }
            }
        }
    }

    public void Spawn(Vector2 position, bool mirror)
    {
        if (isSpawned == false)
        {
            isSpawned = true;
            visible = true;
            this.position = position;
            this.position.Y -= 28;
            Mirror = mirror;
        }

    }
}

