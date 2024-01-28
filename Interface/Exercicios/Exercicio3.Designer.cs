using Interface.Componentes;
using Resolucoes;
using System.Text;

namespace Interface.Exercicios
{
    partial class Exercicio3
    {
        private System.ComponentModel.IContainer components = null;
        Label rounds, participantes; TextBox playerCount;
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
            this.Text = "Exercício 3";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            FormClosed += _FormClosed;

            InitScreen();
        }

        private void _FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void InitScreen()
        {
            Label exercicio = new Label();
            exercicio.Text = "Batata quente";
            exercicio.AutoSize = true;
            exercicio.Location = new Point(499, 134);
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
            homepageButton.Image = Image.FromFile(@"Exercicios\home.png");
            homepageButton.Click += new EventHandler((object sender, EventArgs e) =>
            {
                this.Hide();
                new HomePage().Show();
            });

            this.Controls.Add(homepageButton);

            rounds = new System.Windows.Forms.Label();
            rounds.Text = "";
            rounds.Location = new Point(236, 271);
            rounds.Size = new Size(767, 69);
            rounds.Font = new System.Drawing.Font("Ubuntu", 10);
            this.Controls.Add(rounds);

            Panel panel = new Panel();
            panel.Location = new Point(236, 434);
            panel.Size = new Size(800, 350);
            panel.BackColor = System.Drawing.Color.White;
            panel.AutoScroll = true;
            this.Controls.Add(panel);

            playerCount = new TextBox();
            playerCount.Location = new Point(236, 357);
            playerCount.Size = new Size(486, 42);
            playerCount.Text = "Quantidade de participantes";
            playerCount.Enter += playerCount_Enter;
            playerCount.Leave += playerCount_Leave;
            this.Controls.Add(playerCount);

            RoundedButton button = new RoundedButton("JOGAR", 233, 42, 32);
            button.Location = new Point(770, 357);
            button.Click += new EventHandler(button_click);
            this.Controls.Add(button);

            participantes = new System.Windows.Forms.Label();
            participantes.Text = "";
            participantes.Location = new Point(0, 0);
            participantes.AutoSize = true;
            participantes.Font = new System.Drawing.Font("Ubuntu", 10);
            panel.Controls.Add(participantes);
        }

        private void playerCount_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(playerCount.Text))
            {
                playerCount.Text = "Quantidade de participantes";
                playerCount.ForeColor = Color.Gray;
            }
        }

        private void playerCount_Enter(object sender, EventArgs e)
        {
            if (playerCount.Text == "Quantidade de participantes")
            {
                playerCount.Text = "";
                playerCount.ForeColor = Color.Black;
            }
        }

        private void button_click(object sender, EventArgs e)
        {
            if(int.TryParse(playerCount.Text, out int players))
            {
                List<(int player, int roundLeft)> list = OperacoesFila.PlayBatataQuente(players);
                participantes.Text = "";
                foreach (var item in list)
                {
                    if (item.player == 0)
                        rounds.Text = $"JOGO COM {item.roundLeft} PASSES POR ROUND";
                    else if (item.roundLeft != 0)
                        participantes.Text = participantes.Text + $"JOGADOR {item.player} SAIU NO ROUND {item.roundLeft}\n";
                    else
                        participantes.Text = $"-----JOGADOR {item.player} FOI O GANHADOR------\n" +  participantes.Text;
                }
            }
            else
            {
                MessageBox.Show("Quantidade de participantes deve ser um inteiro", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                playerCount.Text = "Quantidade de participantes";
            }
                

        }


    }
}