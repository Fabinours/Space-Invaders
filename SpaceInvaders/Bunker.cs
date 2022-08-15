using SpaceInvaders.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class Bunker : GameObject
    {
        /// <summary>
        /// Bunker images
        /// </summary>
        private static ArrayList images = new ArrayList { SpaceInvaders.Properties.Resources.Bunker1, SpaceInvaders.Properties.Resources.Bunker2, SpaceInvaders.Properties.Resources.Bunker3 };

        /// <summary>
        /// Index of current used image
        /// </summary>
        private static int imageIndex = 0;

        /// <summary>
        /// Bunker constructor
        /// </summary>
        /// <param name="position">Position of the bunker</param>
        public Bunker(Vecteur2D position) : base()
        {
            Image = (Bitmap) images[imageIndex];
            this.position = new Vecteur2D(position.X-Image.Width/2,position.Y);
            imageIndex++;
            if (imageIndex == 3)
            {
                imageIndex = 0;
            }
        }

        public override void Update(Game gameInstance, double deltaT)
        {
            
        }
    }
}
