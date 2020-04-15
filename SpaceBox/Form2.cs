using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceBox
{
    public partial class Form2 : Form
    {
        int movimientos = 0;
        int espacios = 0;
        int puntaje = 0;
        Nave nave;

        char[,] juego = new char[14, 14];
        
        public Form2()
        {
            InitializeComponent();

        }
        public Form2(string texto)
        {
            InitializeComponent();
            nombreNave.Text = texto;
        }

        private void buttonArchivo_Click(object sender, EventArgs e)
        {
            
            var fileContent = string.Empty;
            var filePath = string.Empty;
            int filas = 0;
            bool estaBien = true;
            int cuentaNave = 0;
            int cuentaTierra = 0;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();
                    
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        while (!reader.EndOfStream)
                        {
                            fileContent = reader.ReadLine();
                            if (fileContent.Length == 14)
                            {
                                for (int i = 0; i < fileContent.Length; i++)
                                {
                                    if (fileContent.ElementAt(i) == 'A' || fileContent.ElementAt(i) == 'B' || fileContent.ElementAt(i) == 'C' || fileContent.ElementAt(i) == 'D' || fileContent.ElementAt(i) == 'E')
                                    {
                                        if (fileContent.ElementAt(i) == 'B')
                                        {
                                            nave = new Nave(filas, i);
                                            cuentaNave++;
                                        }
                                        if (fileContent.ElementAt(i) == 'D')
                                        {
                                            cuentaTierra++;
                                        }
                                        juego[filas, i] = fileContent.ElementAt(i);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Caracteres invalidos en clave");
                                        estaBien = false;
                                    }
                                }
                            }
                            else
                            {
                                estaBien = false;
                                MessageBox.Show("Linea con longitud diferente a 14");
                            }
                            filas++;
                        }
                        if (!(filas == 14))
                        {
                            estaBien = false;
                            MessageBox.Show("Archivo con cantidad de lineas diferente a 14");
                        }
                        if (cuentaTierra != 1)
                        {
                            estaBien = false;
                            MessageBox.Show("Ninguna o mas de una tierra");
                        }
                        if (cuentaNave != 1)
                        {
                            estaBien = false;
                            MessageBox.Show("Ninguna o mas de una nave");
                        }
                    }
                }
            }
            if (estaBien)
            {
                DibujarDGV();
            }
            else
            {
                MessageBox.Show("Ingrese nuevamente un archivo correcto");
            }
           
            
        }
        public void DibujarDGV()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            for (int i = 0; i < 14; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), "");
                dataGridView1.Columns[i].Width = 35;
            }
            
            dataGridView1.Rows.Add(14);
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (juego[i, j] == 'A')
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "";
                    }
                    else if (juego[i, j] == 'B')
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "Δ";
                    }
                    else if (juego[i, j] == 'C')
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "☼";

                    }
                    else if (juego[i, j] == 'D')
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "╬";
                    }
                    else if (juego[i, j] == 'E')
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "♦";
                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "·";
                    }
                    
                }
            }
            labelPunteoCristales.Text = puntaje.ToString();
            labelNoMovimientos.Text = movimientos.ToString();
            labelespacioRecorrido.Text = espacios.ToString();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                bool estaActivo = true;
                if (e.KeyCode == Keys.W)
                {
                    while (estaActivo)
                    {
                        int y = nave.getX();
                        int x = nave.getY();
                        if ((juego[y - 1, x] == 'C'))
                        {
                            estaActivo = false;
                        }
                        else if ((juego[y - 1, x] == 'D'))
                        {
                            MessageBox.Show("Ha llegado a tierra");
                            estaActivo = false;
                        }
                        else
                        {
                            if ((juego[y - 1, x] == 'E'))
                            {
                                puntaje += 100;
                            }
                            juego[y - 1, x] = 'B';
                            nave.setxy(y - 1, x);
                            juego[y, x] = 'Z';
                            
                        }
                        espacios += 1;
                    }
                }
                if (e.KeyCode == Keys.S)
                {
                    while (estaActivo)
                    {
                        int y = nave.getX();
                        int x = nave.getY();
                        if ((juego[y + 1, x] == 'C'))
                        {
                            estaActivo = false;
                        }
                        else if ((juego[y + 1, x] == 'D'))
                        {
                            MessageBox.Show("Ha llegado a tierra");
                            estaActivo = false;
                        }
                        else
                        {
                            if ((juego[y + 1, x] == 'E'))
                            {
                                puntaje += 100;
                            }
                            juego[y + 1, x] = 'B';
                            nave.setxy(y + 1, x);
                            juego[y, x] = 'Z';
                            
                        }
                        espacios += 1;
                    }
                }
                if (e.KeyCode == Keys.D)
                {
                    while (estaActivo)
                    {
                        int y = nave.getX();
                        int x = nave.getY();

                        if ((juego[y, x+1] == 'C'))
                        {
                            estaActivo = false;
                        }
                        else if ((juego[y, x+1] == 'D'))
                        {
                            MessageBox.Show("Ha llegado a tierra");
                            estaActivo = false;
                        }
                        else
                        {
                            if ((juego[y , x+1] == 'E'))
                            {
                                puntaje += 100;
                            }
                            juego[y, x + 1] = 'B';
                            nave.setxy(y, x + 1);
                            juego[y, x] = 'Z';
                            
                        }

                        espacios += 1;
                    }
                }
                if (e.KeyCode == Keys.A)
                {
                    while (estaActivo)
                    {
                        int y = nave.getX();
                        int x = nave.getY();
                        if ((juego[y, x - 1] == 'C'))
                        {
                            estaActivo = false;
                        }
                        else if ((juego[y, x - 1] == 'D'))
                        {
                            MessageBox.Show("Ha llegado a tierra");
                            estaActivo = false;
                        }
                        else
                        {
                            if ((juego[y, x - 1] == 'E'))
                            {
                                puntaje += 100;
                            }
                            juego[y, x - 1] = 'B';
                            nave.setxy(y, x - 1);
                            juego[y, x] = 'Z';
                            

                        }
                        espacios += 1;

                    }
                }
                movimientos += 1;
                DibujarDGV();
            }
            catch (IndexOutOfRangeException w)
            {

                MessageBox.Show("Se está yendo fuera de los límites, perdió vuelva a empezar");
                this.Close();
            }
           
        }
        
        private void buttonReiniciar_Click(object sender, EventArgs e)
        {
            Form3 otro = new Form3();
            otro.Show();
            this.Close();
            
        }
    }
}
