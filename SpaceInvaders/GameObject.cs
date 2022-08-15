using SpaceInvaders.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    /// <summary>
    /// This is the generic abstact base class for any entity in the game
    /// </summary>
    abstract class GameObject : Object
    {

        /// <summary>
        /// The lives of the gameobject
        /// </summary>
        public int PV { get; protected set; } = 3;

        /// <summary>
        /// Tells if the gameobject is alive or not
        /// </summary>
        private bool alive = true;

        /// <summary>
        /// Gameobject speed in pixel/second
        /// </summary>
        public int moveSpeed = 100;

        /// <summary>
        /// The image bitmap of the gameobject
        /// </summary>
        private Bitmap image;
        protected Bitmap Image
        {
            get { return image; }
            set
            {
                image = value;
                size = new Size(image.Size.Width,image.Size.Height);
            }
        }

        /// <summary>
        /// Return the image bitmap of the gameobject
        /// </summary>
        public Bitmap GetImage()
        {
            return image;
        }

        public GameObject()
        {
        }

        /// <summary>
        /// Update the state of a game objet
        /// </summary>
        /// <param name="gameInstance">instance of the current game</param>
        /// <param name="deltaT">time ellapsed in seconds since last call to Update</param>
        public abstract void Update(Game gameInstance, double deltaT);

        /// <summary>
        /// Determines if object is alive. If false, the object will be removed automatically.
        /// </summary>
        /// <returns>Am I alive ?</returns>
        public virtual bool IsAlive() { return alive; }

        /// <summary>
        /// Render the game object
        /// </summary>
        /// <param name="gameInstance">instance of the current game</param>
        /// <param name="graphics">graphic object where to perform rendering</param>
        public virtual void Draw(Game gameInstance, Graphics graphics)
        {
            graphics.DrawImage(image, (float)position.X, (float)position.Y, image.Width, image.Height);
        }

        /// <summary>
        /// Kills the gameobject
        /// </summary>
        public virtual void Kill()
        {
            alive = false;
        }

        public void Damage(int pv)
        {
            PV -= pv;
            if (PV <= 0) { Kill(); };
        }
    }
}
