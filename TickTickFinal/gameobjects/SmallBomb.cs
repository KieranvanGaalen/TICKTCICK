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

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

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

    public override void CheckPlayerCollision()
    {
        if (TickTick.GameStateManager.CurrentGameState is PlayingState) 
        {
            PlayingState state = TickTick.GameStateManager.CurrentGameState as PlayingState;
            foreach (GameObject obj in state.CurrentLevel.Children)
            {
                System.Console.WriteLine("D");
                if (obj is Player || obj is Turtle || obj is SmallBomb /*|| !(obj is AnimatedGameObject)*/)
                {
                    System.Console.WriteLine("C");
                    continue;
                }
                if (obj is AnimatedGameObject)
                {
                    System.Console.WriteLine("B");
                    AnimatedGameObject obj2 = obj as AnimatedGameObject;
                    if (CollidesWith(obj2))
                    {
                        System.Console.WriteLine("jaa");
                        obj2.Visible = false;
                    }
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

