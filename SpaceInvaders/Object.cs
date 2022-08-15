using SpaceInvaders.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    abstract class Object
    {
        /// <summary>
        /// Position
        /// </summary>
        public Vecteur2D position;

        public Size size;

        public Object()
        {
        }

    }
}
