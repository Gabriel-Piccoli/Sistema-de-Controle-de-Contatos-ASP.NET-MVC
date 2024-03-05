using System.Drawing;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;

namespace CadastroDeClientes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MaxDate = DateTime.Today;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            // Verifica se há números antes de remover os caracteres não-alfabéticos.
            if (input.Any(char.IsDigit))
            {
                MessageBox.Show("Apenas letras são permitidas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Remove todos os caracteres não-alfabéticos.
                input = new string(input.Where(char.IsLetter).ToArray());

                // Define o texto da TextBox para a versão sem números.
                textBox1.Text = input;

                // Move o cursor para o final do texto.
                textBox1.SelectionStart = textBox1.Text.Length;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string text = textBox2.Text;

            // Verifica se o texto contém letras
            if (text.Any(c => !char.IsDigit(c)))
            {
                MessageBox.Show("Apenas números são permitidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Remove todos os caracteres não-dígitos
                text = new string(text.Where(char.IsDigit).ToArray());

                // Define o texto da TextBox formatado
                textBox2.Text = text;

                // Move o cursor para o final do texto
                textBox2.SelectionStart = textBox2.Text.Length;
                return;
            }

            // Limita o campo a 11 dígitos
            if (text.Length > 11)
            {
                text = text.Substring(0, 11);
            }

            // Define o texto da TextBox formatado
            textBox2.Text = text;

            // Move o cursor para o final do texto
            textBox2.SelectionStart = textBox2.Text.Length;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Define o limite máximo de dígitos
            int limiteMaximo = 11; // Por exemplo, para (XX)XXXXX-XXXX

            // Remove todos os caracteres não numéricos do texto
            string textoSemNaoNumericos = new string(textBox3.Text.Where(char.IsDigit).ToArray());

            // Verifica se o texto excede o limite máximo
            if (textoSemNaoNumericos.Length > limiteMaximo)
            {
                // Trunca o texto para o limite máximo
                textoSemNaoNumericos = textoSemNaoNumericos.Substring(0, limiteMaximo);
            }

            // Verifica o comprimento do texto
            if (textoSemNaoNumericos.Length <= 2)
            {
                // Se o texto tiver 0 ou 1 dígito, não formate
                textBox3.Text = textoSemNaoNumericos;
            }
            else if (textoSemNaoNumericos.Length <= 7)
            {
                // Formate como (XX)XXXX
                textBox3.Text = string.Format("({0}) {1}",
                    textoSemNaoNumericos.Substring(0, 2),
                    textoSemNaoNumericos.Substring(2));
            }
            else
            {
                // Formate como (XX)XXXXX-XXXX
                textBox3.Text = string.Format("({0}) {1}-{2}",
                    textoSemNaoNumericos.Substring(0, 2),
                    textoSemNaoNumericos.Substring(2, 5),
                    textoSemNaoNumericos.Substring(7));
            }

            // Define a posição do cursor no final da caixa de texto
            textBox3.SelectionStart = textBox3.Text.Length;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cadastro Realizado com Sucesso!\n\nObrigado!!");
        }
        private void label7_Click(object sender, EventArgs e)
        {
        }
    }
}