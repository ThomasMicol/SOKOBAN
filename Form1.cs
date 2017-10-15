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

        public void DrawGameControls()
        {
            throw new NotImplementedException();
        }

        public void DisplayMenu()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();

            this.button1.Location = new System.Drawing.Point(91, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Game";
            this.button1.UseVisualStyleBackColor = true;

            this.button2.Location = new System.Drawing.Point(91, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 34);
            this.button2.TabIndex = 1;
            this.button2.Text = "New Game";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);

            this.button3.Location = new System.Drawing.Point(91, 151);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 34);
            this.button3.TabIndex = 2;
            this.button3.Text = "Load Game";
            this.button3.UseVisualStyleBackColor = true;

            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
