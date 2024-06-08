using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace JuegoAvanzadoBusquedaPalabras
{
    public partial class Form1 : Form
    {
        private List<string> words = new List<string> { "PALABRA", "BUSCAR", "JUEGO" };
        private char[,] grid = {
            { 'P', 'A', 'L', 'A', 'B', 'R' },
            { 'X', 'X', 'U', 'X', 'X', 'X' },
            { 'X', 'X', 'E', 'X', 'X', 'X' },
            { 'X', 'X', 'R', 'X', 'X', 'X' },
            { 'X', 'X', 'C', 'X', 'X', 'X' },
            { 'X', 'X', 'A', 'X', 'X', 'X' },
        };

        private SoundPlayer correctSound;
        private SoundPlayer wrongSound;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();

            correctSound = new SoundPlayer("correct.wav");
            wrongSound = new SoundPlayer("wrong.wav");
        }

        private void InitializeGame()
        {
            dataGridView1.RowCount = grid.GetLength(0);
            dataGridView1.ColumnCount = grid.GetLength(1);

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    dataGridView1[j, i].Value = grid[i, j];
                }
            }

            foreach (var word in words)
            {
                listBox1.Items.Add(word);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.ToUpper();
            if (words.Contains(input))
            {
                correctSound.Play();
                MessageBox.Show($"¡Correcto! {input} está en la cuadrícula.");
            }
            else
            {
                wrongSound.Play();
                MessageBox.Show($"{input} no está en la lista de palabras.");
            }
        }
    }
}
