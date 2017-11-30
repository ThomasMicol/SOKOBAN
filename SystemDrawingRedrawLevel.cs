using System;
using System.Collections.Generic;
using System.Drawing;


namespace Assignment1___Thomas_Micol
{
    public class SystemDrawingRedrawLevel : Form1
    {
        public override void RedrawLevel()
        {
            int windowWidth = 848;
            int windowHeight = 520;
            int gridWidth = 2;
            SolidBrush brush = new SolidBrush(Color.White);
            SolidBrush gridLine = new SolidBrush(Color.Black);
            Graphics graphic = this.CreateGraphics();
            graphic.FillRectangle(brush, new Rectangle(31, 20, windowWidth, windowHeight));
            Level g = theCtrl.theLevel;
            int moves = g.GetMoveCount();
            this.lbl_moveCount.Text = "Move Count: " + moves.ToString();
            int tileWidth = windowWidth / g.GetRowWidth();
            int tileHeight = windowHeight / g.GetColumnHeight();
            List<IEntity> l = g.GetLevelData();
            foreach (Entity e in l)
            {
                Location myLoc = e.GetLocation();
                if (e.GetEntityType() == EntityTypes.Floor)
                {
                    brush.Color = Color.LightGray;
                }
                if (e.GetEntityType() == EntityTypes.Wall)
                {
                    brush.Color = Color.DarkGray;
                }
                if (e.GetEntityType() == EntityTypes.GoalTile)
                {
                    brush.Color = Color.Gold;
                }
                if (e.GetEntityType() == EntityTypes.MovableBlock)
                {
                    brush.Color = Color.Green;
                }
                if (e.GetEntityType() == EntityTypes.Player)
                {
                    brush.Color = Color.Blue;
                }
                graphic.FillRectangle(brush, new Rectangle(31 + (myLoc.x * tileWidth), 20 + (myLoc.y * tileHeight), tileWidth, tileHeight));
                graphic.FillRectangle(gridLine, new Rectangle(31 + (myLoc.x * tileWidth), 20 + (myLoc.y * tileHeight), gridWidth, tileHeight));
                graphic.FillRectangle(gridLine, new Rectangle(31 + (myLoc.x * tileWidth), 20 + (myLoc.y * tileHeight), tileWidth, gridWidth));
            }
        }
    }
}
