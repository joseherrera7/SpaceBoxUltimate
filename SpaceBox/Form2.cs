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
        //variables
        int movimientos = 0;
        int espacios = 0;
        int puntaje = 0;
        Nave nave;

        char[,] juego = new char[15, 15];
        
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
                            fileContent = reader.ReadLine(); //lee linea por linea
                            if (fileContent.Length == 15)
                            {
                                //recorro la linea
                                for (int i = 0; i < fileContent.Length; i++)
                                {
                                    if (fileContent.ElementAt(i) == 'A' || fileContent.ElementAt(i) == 'B' || fileContent.ElementAt(i) == 'C' || fileContent.ElementAt(i) == 'D' || fileContent.ElementAt(i) == 'E')
                                    {
                                        if (fileContent.ElementAt(i) == 'B')
                                        {
                                            nave = new Nave(filas, i); //creo la nave
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
                                MessageBox.Show("Linea con longitud diferente a 15");
                            }
                            filas++;
                        }
                        //condicion si hay mas o menos filas
                        if (!(filas == 15))
                        {
                            estaBien = false;
                            MessageBox.Show("Archivo con cantidad de lineas diferente a 15");
                        }
                        //condicion para ver si hay solo 1 tierra
                        if (cuentaTierra != 1)
                        {
                            estaBien = false;
                            MessageBox.Show("Ninguna o mas de una tierra");
                        }
                        //concioon para ver si hay o no hay nave
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
            dataGridView1.ReadOnly = true; //Ponerlo en solo leer
            dataGridView1.Rows.Clear(); 
            dataGridView1.Columns.Clear();
            //AGREGAR COLUMNAS
            for (int i = 0; i < 15; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), "");
                dataGridView1.Columns[i].Width = 35;
            }
            //AGREGAS LAS FILAS
            dataGridView1.Rows.Add(15);

            //RECORRER DGV
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    //ver que es en el juego y poner en el data grid view
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
            //colocar el punteo, numero de movimientos y los espacios recorridos
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
                        //asigno coordenadas x y y
                        int y = nave.getX();
                        int x = nave.getY();
                        //condicion par ver si el siguiente es asteroide
                        if ((juego[y - 1, x] == 'C'))
                        {
                            estaActivo = false;
                        }
                        //condicion para ver si el siguiente es tierra
                        else if ((juego[y - 1, x] == 'D'))
                        {
                            MessageBox.Show("Ha llegado a tierra");
                            estaActivo = false;
                        }
                        else
                        {
                            //condicion para ver si el siguiente es cristal
                            if ((juego[y - 1, x] == 'E'))
                            {
                                puntaje += 100;
                            }
                            juego[y - 1, x] = 'B'; //asigno nave a la posicion siguiente en la matriz
                            nave.setxy(y - 1, x); //asigno coordenadas a la nave
                            juego[y, x] = 'Z';
                            
                        }
                        espacios += 1; //recorro 1 espacio
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
