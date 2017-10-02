using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1___Thomas_Micol
{
    public partial class Form1 : Form, IView
    {
        protected GameController theCtrl;

        public Form1()
        {
            InitializeComponent();

        }

        public void SetController(GameController aCtrl)
        {
            theCtrl = aCtrl;
        }

        public void DisplayBackground()
        {
            throw new NotImplementedException();
        }

        public void DisplayClean()
        {
            throw new NotImplementedException();
        }

        public void DisplayDirectionArrow(Directions direction)
        {
            throw new NotImplementedException();
        }

        public void DisplayElement(Location location, Entity entity)
        {
            throw new NotImplementedException();
        }

        public void DisplayLevelGrid()
        {
            throw new NotImplementedException();
        }

        public void DisplayPlayerStructItem(Entity entity)
        {
            throw new NotImplementedException();
        }

        public void DisplaySystemMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void DisplayWinScreen()
        {
            throw new NotImplementedException();
        }

        public void ErrorMessage(string errorMessage)
        {
            throw new NotImplementedException();
        }

        public void OnKeyPress(object sender)
        {
            throw new NotImplementedException();
        }

        public void Redraw()
        {
            Console.Write("redrawing");
        }

        public void SoundPlayerStruckItem(Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}
