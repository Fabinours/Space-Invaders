using SpaceInvaders.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SpaceInvaders
{
    class EnemyBlock : GameObject
    {
        /// <summary>
        /// Number of enemy rows
        /// </summary>
        private int rows;

        /// <summary>
        /// The set of enemies
        /// </summary>
        private HashSet<EnemyShip> enemies = new HashSet<EnemyShip>();

        /// <summary>
        /// The initial movespeed of the enemyblock
        /// </summary>
        private int initMoveSpeed;

        /// <summary>
        /// EnemyBlock constructor
        /// </summary>
        /// <param name="position">Position of the top-left corner of the block</param>
        public EnemyBlock(Vecteur2D position, Size size,int rows) : base()
        {
            this.position = position;
            this.size = size;
            this.rows = rows;
            Init();
            initMoveSpeed = 8;
            moveSpeed = initMoveSpeed;
        }

        /// <summary>
        /// Updates the enemyblock
        /// </summary>
        public override void Update(Game gameInstance, double deltaT)
        {
            enemies.RemoveWhere(gameObject => !gameObject.IsAlive());
            if (enemies.Count == 0){Kill();}
            UpdateSize();
            Move(gameInstance,deltaT);
        }

        /// <summary>
        /// Initialize the enemyblock
        /// </summary>
        private void Init()
        {
            Size maxShipSize = EnemyShip.GetMaxEnemyShipSize(); Array enums = Enum.GetValues(typeof(Enemy));
            double x = -maxShipSize.Width / 2; double y = -maxShipSize.Height / 2; int xOffset = maxShipSize.Width / 2; int yOffset = maxShipSize.Height / 2;
            for (int i = 0; i < rows; i++){
                Enemy eType = (Enemy)enums.GetValue(i);
                while (x+xOffset+maxShipSize.Width<size.Width){
                    EnemyShip e = new EnemyShip(x + xOffset,y+yOffset,eType);
                    Game.game.AddNewGameObject(e); enemies.Add(e);
                    x += maxShipSize.Width+ xOffset;
                }
                x = -maxShipSize.Width / 2; y += maxShipSize.Height + yOffset;
                if (y + maxShipSize.Height > size.Height){break;}
            }
        }

        /// <summary>
        /// Moves the enemyblock
        /// </summary>
        private void Move(Game gameInstance,double deltaT)
        {
            double xOffset = moveSpeed * deltaT; double yOffset = 0;
            Vecteur2D newPos = new Vecteur2D(position.X + xOffset + initMoveSpeed, position.Y);
            if (gameInstance.IsOutOfBounds(newPos, size))
            {
                initMoveSpeed = -initMoveSpeed;
                moveSpeed = -moveSpeed;
                moveSpeed += initMoveSpeed;
                yOffset = initMoveSpeed > 0 ? initMoveSpeed: -initMoveSpeed;
            }
            DecalPosition(new Vecteur2D(xOffset, yOffset));
        }

        /// <summary>
        /// Tells if the enemyblock is the winner
        /// </summary>
        public bool IsWinner()
        {
            if (!Game.player.IsAlive()) { return true; }
            foreach (EnemyShip enemy in enemies)
            {
                if (enemy.position.Y + enemy.GetImage().Height >= Game.player.position.Y){return true;}
            }
            return false;
        }

        /// <summary>
        /// Updates the position of the enemyblock and every enemyship
        /// </summary>
        private void DecalPosition(Vecteur2D v)
        {
            position += v;
            foreach (EnemyShip enemy in enemies)
            {
                enemy.position += v;
            }
        }

        /// <summary>
        /// Kill the enemyblock and every enemyship 
        /// </summary>
        public override void Kill()
        {
            base.Kill();
            foreach ( EnemyShip enemy in enemies)
            {
                enemy.Kill();
            }
        }

        /// <summary>
        /// Updates the size of the enemyblock according to the death of the enemyships
        /// </summary>
        private void UpdateSize()
        {
            Size maxSize = new Size(0,0);
            foreach (EnemyShip enemy in enemies)
            {
                if (enemy.position.X + enemy.size.Width-position.X>maxSize.Width){maxSize.Width = (int)(enemy.position.X + enemy.size.Width - position.X);}
                if (enemy.position.Y + enemy.size.Height -position.Y> maxSize.Height){maxSize.Height = (int)(enemy.position.Y + enemy.size.Height - position.Y);}
            }
            size = maxSize;
        }

        public virtual void Draw(Game gameInstance, Graphics graphics){}
    }
}
