using Resolucoes;
using static System.Net.Mime.MediaTypeNames;
using System.Data;

namespace Interface.Exercicios
{
    partial class Exercicio2
    {
        private System.ComponentModel.IContainer components = null;
        TextBox text; Label rsult;
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
            this.Text = "Exercício 2";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            FormClosed += _FormClosed;

            InitScreen();
        }

        private void _FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void InitScreen()
        {
            Label exercicio = new Label();
            exercicio.Text = "Verificar se a expressão\nestá balanceada";
            exercicio.AutoSize = true;
            exercicio.Location = new Point(406, 134);
            exercicio.Font = new System.Drawing.Font("Ubuntu", 28);
            exercicio.ForeColor = ColorTranslator.FromHtml("#7DA5FA");
            exercicio.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(exercicio);

            Button homepageButton = new System.Windows.Forms.Button();
            homepageButton.Location = new Point(54, 46);
            homepageButton.Size = new Size(40, 43);
            homepageButton.FlatStyle = FlatStyle.Flat;
            homepageButton.FlatAppearance.BorderSize = 0;
            homepageButton.Cursor = Cursors.Hand;
            homepageButton.Image = System.Drawing.Image.FromFile(@"Exercicios\home.png");
            homepageButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                this.Hide();
                new HomePage().Show();
            });

            this.Controls.Add(homepageButton);

            Label label = new Label();
            label.Text = "Digite a expressão:";
            label.AutoSize = true;
            label.Location = new Point(170, 278);
            label.Font = new System.Drawing.Font("Ubuntu", 28);
            label.ForeColor = ColorTranslator.FromHtml("#7DA5FA");

            this.Controls.Add(label);

            rsult = new Label();
            rsult.Text = "";
            rsult.Size = new Size(826, 174);
            rsult.Location = new Point(170, 573);
            rsult.Font = new System.Drawing.Font("Ubuntu", 16);
            rsult.ForeColor = ColorTranslator.FromHtml("#7DA5FA");

            this.Controls.Add(rsult);

            text = new TextBox();
            text.Text = "";
            text.Location = new Point(649, 278);
            text.Size = new Size(347, 112);
            text.Multiline = true;
            text.ScrollBars = ScrollBars.Vertical;


            this.Controls.Add(text);

            Button button = new Button();
            button.Text = "VERIFICAR";
            button.Location = new Point(510, 485);
            button.Size = new Size(278, 66);
            button.Cursor = Cursors.Hand;
            button.Click += new EventHandler(buttonClick);
            this.Controls.Add(button);
        }

        private void buttonClick(object sender, EventArgs e)
        {
            bool resultado = OperacoesPilha.IsExpressionBalanced(text.Text);
            string rst = resultado ? "balanceada" : "desbalanceada";
            rsult.Text = $"A expressão está {rst}";
            text.Text = "";
        }

    }
}