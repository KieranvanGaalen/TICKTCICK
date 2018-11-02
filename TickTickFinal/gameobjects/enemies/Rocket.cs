using Microsoft.Xna.Framework;

class Rocket : AnimatedGameObject
{
    protected double spawnTime;
    protected Vector2 startPosition;
    protected Vector2 levelSize;
    protected TileField tiles;

    public Rocket(bool moveToLeft, Vector2 startPosition, Vector2 levelSize, TileField tiles)
    {
        LoadAnimation("Sprites/Rocket/spr_rocket@3", "default", true, 0.2f);
        PlayAnimation("default");
        Mirror = moveToLeft;
        this.startPosition = startPosition;
        this.levelSize = levelSize;
        this.tiles = tiles;
        Reset();
    }

    public override void Reset()
    {
        visible = false;
        position = startPosition;
        velocity = Vector2.Zero;
        spawnTime = GameEnvironment.Random.NextDouble() * 5;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if (spawnTime > 0)
        {
            spawnTime -= gameTime.ElapsedGameTime.TotalSeconds;
            return;
        }
        if (!IsSpawned(gameTime))
            return;
        visible = true;
        velocity.X = 600;
        if (Mirror)
        {
            this.velocity.X *= -1;
        }
        CheckCollisions();
        // check if we are outside the screen
        Rectangle screenBox = new Rectangle(0, 0, (int)levelSize.X * tiles.CellWidth, (int)levelSize.Y * tiles.CellHeight);
        if (!screenBox.Intersects(this.BoundingBox))
        {
            Reset();
        }
    }

    public virtual bool IsSpawned(GameTime gameTime)
    {
        if (spawnTime > 0)
        {
            spawnTime -= gameTime.ElapsedGameTime.TotalSeconds;
            return false;
        }
        return true;
    }

    public virtual void CheckCollisions()
    {
        Player player = GameWorld.Find("player") as Player;
        if (player.IsAlive && CollidesWith(player) && visible && player.GlobalPosition.Y + player.Height < this.GlobalPosition.Y + 60)
        {
            player.Jump();
            Reset();
        }
        else if (CollidesWith(player) && visible)
            player.Die(false);
    }
}
