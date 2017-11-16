using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1___Thomas_Micol
{
    class SystemDrawingRedrawLevel : Form1
    {
        public override void RedrawLevel()
        {
            SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            Graphics graphic = this.CreateGraphics();
            graphic.FillRectangle(brush, new Rectangle(31, 20, 848, 520));
            Level g = theCtrl.theLevel;
            int tileWidth = 848 / g.GetRowWidth();
            int tileHeight = 520 / g.GetColumnHeight();
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
            }
        }
    }
}
