using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TextGameObject : GameObject
{
    protected SpriteFont spriteFont;
    protected Color color;
    protected string text;

    public TextGameObject(string assetname, int layer = 0, string id = "")
        : base(layer, id)
    {
        spriteFont = GameEnvironment.AssetManager.Content.Load<SpriteFont>(assetname);
        color = Color.White;
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (visible)
        {
            if (layer >= 100)
                spriteBatch.DrawString(spriteFont, text, new Vector2(-GameEnvironment.Camera.Position.X + Position.X, -GameEnvironment.Camera.Position.Y + Position.Y), color);
            else
                spriteBatch.DrawString(spriteFont, text, GlobalPosition, color);
        }
    }

    public Color Color
    {
        get { return color; }
        set { color = value; }
    }

    public string Text
    {
        get { return text; }
        set { text = value; }
    }

    public Vector2 Size
    {
        get
        { return spriteFont.MeasureString(text); }
    }
}