using SpaceInvaders.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceInvaders
{
    class Image : Object
    {
        /// <summary>
        /// Image bitmap
        /// </summary>
        private Bitmap b;

        /// <summary>
        /// Image constructor
        /// </summary>
        public Image(Bitmap b,Vecteur2D position)
        {
            this.b = b;
            this.position = position;
            this.size = b.Size;
        }

        /// <summary>
        /// Draw the image
        /// </summary>
        /// <param name="g">Graphics to draw in</param>
        public void Draw(Graphics g)
        {
            g.DrawImage(b,(float)position.X, (float)position.Y, size.Width, size.Height);
        }

        /// <summary>
        /// Check collision with another image
        /// </summary>
        /// <param name="removePixel">Remove collided pixels</param>
        public bool CheckCollision(Image b2,bool removePixel)
        {
            if (CheckIntersection(b2)){
                for (int i = 0; i < b2.size.Width; i++){
                    for (int j = 0; j < b2.size.Height; j++){
                        if (b2.b.GetPixel(i, j).A==255){
                            Vecteur2D pixel = new Vecteur2D(b2.position.X + i, b2.position.Y + j);
                            if (PixelInImage(pixel) && PixelCollision(pixel)){   
                                if (removePixel) { RemovePixelAround(b2, i, j, 15); }; return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Remove pixel around one pixel
        /// </summary>
        /// <param name="x">Pixel x coordinate</param>
        /// <param name="y">Pixel y coordinate</param>
        /// <param name="range">Range from remove</param>
        private void RemovePixelAround(Image image, int x, int y, int range)
        {
            for (int i = x-(range / 2)+1; i < x+(range/2); i++){
                for (int j = y - (range / 2) + 1; j < y+(range / 2); j++){
                    if(i>=0 && i<image.b.Width && j>=0 && j< image.b.Height)
                    {
                        image.b.SetPixel(i, j, Color.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Checks intersection between two images
        /// </summary>
        private bool CheckIntersection(Image b2)
        {
            if (b2.position.X > position.X + size.Width || b2.position.Y+b2.size.Height < position.Y ){return false;}
            if (position.X > b2.position.X + b2.size.Width || position.Y +size.Height< b2.position.Y ){return false;}
            return true;
        }

        /// <summary>
        /// Checks collision with a pixel
        /// </summary>
        private bool PixelCollision(Vecteur2D pixel)
        {
            for (int i = 0; i < size.Width; i++){
                for (int j = 0; j < size.Height; j++){
                    if (b.GetPixel(i, j).A == 255){
                        if ((int)position.X+i==(int)pixel.X && (int)position.Y+j==(int)pixel.Y){return true;}
                    }  
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the pixel is in the image
        /// </summary>
        private bool PixelInImage(Vecteur2D pixel)
        {
            //Check X
            if(pixel.X<=position.X + size.Width && pixel.X >= position.X){
                //Check Y
                if (pixel.Y <= position.Y + size.Height && pixel.Y >= position.Y){return true;}
            }
            return false;
        }
    }
}
