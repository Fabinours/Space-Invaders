using SpaceInvaders.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class Background
    {
        /// <summary>
        /// Backgrounds to alternate
        /// </summary>
        private Image[] backgrounds;

        /// <summary>
        /// Background movement speed
        /// </summary>
        private int moveSpeed = 50;

        /// <summary>
        /// Image to draw
        /// </summary>
        private Bitmap image = SpaceInvaders.Properties.Resources.Background;

        /// <summary>
        /// Background constructor
        /// </summary>
        public Background()
        {
            backgrounds = new Image[2] { new Image(image,new Vecteur2D(0,-1)), new Image(image, new Vecteur2D(0, -image.Height)) };
        }

        /// <summary>
        /// Draws the background
        /// </summary>
        /// <param name="g">Graphics to draw in</param>
        public void Draw(Graphics g)
        {

            backgrounds[0].Draw(g);
            backgrounds[1].Draw(g);
        }

        /// <summary>
        /// Moves the background, alternates both images
        /// </summary>
        /// <param name="deltaT">deltaT</param>
        public void Move(double deltaT) 
        {
            backgrounds[0].position += new Vecteur2D(0, deltaT * moveSpeed);
            backgrounds[1].position += new Vecteur2D(0, deltaT * moveSpeed);
            if ((int)backgrounds[1].position.Y == -1)
            {
                backgrounds[0].position = new Vecteur2D(0, -1);
                backgrounds[1].position = new Vecteur2D(0, -image.Height);
            }
        }
    }
}
