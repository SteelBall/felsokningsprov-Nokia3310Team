using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SpaceShooter
{
    class GameObject
    {
        protected Texture2D gfx; //grafiken
        protected Vector2 position; //spelarens position

        // GameObject() - konstruktor 

        public GameObject(Texture2D gfx, float X, float Y)
        {
            this.gfx = gfx;
            this.position.X = X;
            this.position.Y = Y;
        }

        // Draw() - skriver ut grafiken

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(gfx, position, Color.White);
        }
        // Egenskaper för GameObject
        public float X { get { return position.X; } }
        public float Y { get { return position.Y; } }
        public float Width { get { return gfx.Width; } }
        public float Height { get { return gfx.Height; } }
    }
    // MovingObject - rörelse

    abstract class MovingObject : GameObject
    {
        protected Vector2 speed;// hastighet
        // MovingObject() - konstruktor
        public MovingObject(Texture2D gfx, float X, float Y, float speedX, float speedY) 
            : base(gfx, X, Y)
        {
            this.speed = new Vector2(speedY, speedY);
        }
    }
    // PhysicalObject - kollar fysik mellan objeckterna så dem kan inte gå i varandra
    abstract class PhysicalObject : MovingObject
    {
        private bool isAlive = true;

        protected PhysicalObject(Texture2D gfx, float X, float Y, float speedX, float speedY)
            : base(gfx, X, Y, speedX, speedY)
        {
        }

        public bool IsAlive { get { return isAlive; }
            set { isAlive = value; } }

        // CheckCollision() - kollar om objekten gå in varandra
        public bool CheckCollision(PhysicalObject other)
        {
            Rectangle myRect = new Rectangle(Convert.ToInt32(X), Convert.ToInt32(Y),
                Convert.ToInt32(Width), Convert.ToInt32(Height));
            Rectangle otherRect = new Rectangle(Convert.ToInt32(other.X), Convert.ToInt32(other.Y),
                Convert.ToInt32(other.Width), Convert.ToInt32(other.Height));
            return myRect.Intersects(otherRect);
        }
    }
}
