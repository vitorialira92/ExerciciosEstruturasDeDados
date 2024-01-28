
using Interface.Componentes;
using Resolucoes;
using System.Text;

namespace Interface.Exercicios
{
    partial class Exercicio1
    {
        private System.ComponentModel.IContainer components = null;

        List<string> words = new List<string>();
        List<string> filteredWords = new List<string>();

        Label wordsLabel;
        Label filteredWordsLabel;
        TextBox addWordTextBox;
        Button addWordButton;

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
            this.Text = "Exercício 1";
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
            exercicio.Text = "Palavras com mais de\n10 caracteres";
            exercicio.AutoSize = true;
            exercicio.Location = new Point(351, 145);
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

            wordsLabel = new System.Windows.Forms.Label();
            wordsLabel.Text = "Palavras na lista: ";
            wordsLabel.Location = new Point(236, 271);
            wordsLabel.Size = new Size(767, 69);
            wordsLabel.Font = new System.Drawing.Font("Ubuntu", 10);
            this.Controls.Add(wordsLabel);

            addWordTextBox = new TextBox();
            addWordTextBox.Location = new Point(236,357);
            addWordTextBox.Size = new Size(486,42);

            this.Controls.Add(addWordTextBox);

            RoundedButton button = new RoundedButton("Add", 233, 42, 32);
            button.Location = new Point(770, 357);
            button.Click += new EventHandler(button_click);
            this.Controls.Add(button);

            filteredWordsLabel = new System.Windows.Forms.Label();
            filteredWordsLabel.Text = "";
            filteredWordsLabel.Location = new Point(236, 434);
            filteredWordsLabel.Size = new Size(767, 69);
            filteredWordsLabel.Font = new System.Drawing.Font("Ubuntu", 10);
            this.Controls.Add(filteredWordsLabel);
        }

        private void button_click(object sender, EventArgs e)
        {
            if(addWordTextBox.Text.Trim() != "")
            {
                AddWordList();
                AddFilteredList();
                addWordTextBox.Text = "";
            }
            

        }

        private void AddWordList()
        {
            string word = addWordTextBox.Text;
            words.Add(word);

            StringBuilder sb = new StringBuilder();
            sb.Append("Palavras na lista: ");
            foreach (string w in this.words)
            {
                sb.Append(w + ", ");
            }
            this.wordsLabel.Text = sb.ToString().Substring(0, sb.Length - 2);

        }

        private void AddFilteredList()
        {
            filteredWords = OperacoesListas.FilterLongStrings(words);
            StringBuilder sb = new StringBuilder();
            sb.Append("Palavras com 10 ou mais caracteres:  ");
            foreach (string word in filteredWords)
            {
                sb.Append(word + ", ");
            }
            this.filteredWordsLabel.Text = sb.ToString().Substring(0, sb.Length - 2);
        }
    }
}