
using Interface.Componentes;
using Interface.Exercicios;
using System.Diagnostics;
using static System.Windows.Forms.Design.AxImporter;

namespace Interface
{
    partial class HomePage
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

       
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 832);
            this.Text = "Exercícios";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            FormClosed += _FormClosed;

            InitScreen();
        }

        private void InitScreen()
        {
            Label label = new Label();
            label.Text = "Escolha um exercício";
            label.AutoSize = true;
            label.Location = new Point(400, 268);
            label.Font = new Font("Ubuntu", 28);
            label.ForeColor = ColorTranslator.FromHtml("#7DA5FA");

            this.Controls.Add(label);

            InitButtons();

        }

        private void InitButtons()
        {
            RoundedButton firstButton = new RoundedButton("Exercício 1", 224, 57,  32);
            firstButton.Location = new Point(268, 356);
            firstButton.Cursor = Cursors.Hand;
            firstButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                new Exercicio1().Show();
                this.Hide();
            });

            this.Controls.Add(firstButton);

            RoundedButton secondButton = new RoundedButton("Exercício 2", 224, 57, 32);
            secondButton.Location = new Point(528, 356);
            secondButton.Cursor = Cursors.Hand;
            secondButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                new Exercicio2().Show();
                this.Hide();
            });

            this.Controls.Add(secondButton);

            RoundedButton thirdButton = new RoundedButton("Exercício 3", 224, 57, 32);
            thirdButton.Location = new Point(788, 356);
            thirdButton.Cursor = Cursors.Hand;
            thirdButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                new Exercicio3().Show();
                this.Hide();
            });

            this.Controls.Add(thirdButton);

            RoundedButton fourthButton = new RoundedButton("Exercício 4", 224, 57, 32);
            fourthButton.Location = new Point(528, 447);
            fourthButton.Cursor = Cursors.Hand;
            fourthButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                new Exercicio4().Show();
                this.Hide();
            });

            this.Controls.Add(fourthButton);
        }

        private void _FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
