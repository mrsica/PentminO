﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pentominov1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int maliKvadrat = 15; //jedinicni kv figurice
        cFigura[] nizFigura = new cFigura[12];
        public Point[] nizPocPozicija = new Point[12];
        static cTabla tabla = new cTabla();
        string fazaIgre;
        int igracNaRedu;
        public Point[] figure1Pozicije = new Point[6];
        public int brIzabranih1 = 0;
        public Point[] figure2Pozicije = new Point[6];
        public int brIzabranih2 = 0;

        static cTabla novatabla = new cTabla(); //kopija trenutne table


        private void Form1_Load(object sender, EventArgs e)
        {
            fazaIgre = "biranjeFigura";
            igracNaRedu = 1;
            for (int i = 0; i < 12; i++)
            {
                nizFigura[i] = new cFigura();
                nizFigura[i].TipFigure = i;
                nizFigura[i].Status = "slobodan"; // statusi : slobodan, levi, desni, naTabli, racunaj(leviracunaj i desniracunaj)
                nizPocPozicija[i].X = 150 + (i % 6) * 100;
                if (i < 6) nizPocPozicija[i].Y = 230;
                else nizPocPozicija[i].Y = 310;
                nizFigura[i].PostaviPoziciju(nizPocPozicija[i].X, nizPocPozicija[i].Y);
                for (int j = 0; j < 6; j++)
                {
                    figure1Pozicije[j].X = 30 + (j % 3) * 100;
                    figure1Pozicije[j].Y = 60
                        + (j % 2) * 100;

                    figure2Pozicije[j].X = 500 + (j % 3) * 100;
                    figure2Pozicije[j].Y = 60 + (j % 2) * 100;
                }

            }

        }
        public int selektovano = -1;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            tabla.NacrtajTablu(e.Graphics);
            for (int i = 0; i < 12; i++)
            {
                if (nizFigura[i].Status == "naTabli")
                {

                }
                else if (selektovano == i)
                    nizFigura[i].Selektuj(e.Graphics);
                else
                    nizFigura[i].Nacrtaj(e.Graphics);
            }


            labelBrIgraca.Text = igracNaRedu.ToString();
        }
        public Point mis;
        public int rX;
        public int rY;

        public Point vrati;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mis = PointToClient(MousePosition);
            if (fazaIgre == "biranjeFigura" && brIzabranih1 == 6 && brIzabranih2 == 6)
                fazaIgre = "partija";
            if (fazaIgre == "biranjeFigura")
            {
                for (int i = 0; i < 12; i++)
                {
                    if (nizFigura[i].MisUFiguri(mis.X, mis.Y))
                    {
                        if (igracNaRedu == 1)
                        {
                            nizFigura[i].pocetakX = figure1Pozicije[brIzabranih1].X;
                            nizFigura[i].pocetakY = figure1Pozicije[brIzabranih1].Y;
                            nizFigura[i].Status = "levi"; //figura pripada levom igracu
                            brIzabranih1++;
                            igracNaRedu = 2;
                            KompjuterBira();
                            Invalidate();
                        }
                        /*else
                        {
                            nizFigura[i].pocetakX = figure2Pozicije[brIzabranih2].X; 
                            nizFigura[i].pocetakY = figure2Pozicije[brIzabranih2].Y;
                            nizFigura[i].Status = "desni"; //figura pripada desnom igracu
                            brIzabranih2++;
                            igracNaRedu = 1;
                            Invalidate();
                        }*/
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 12; i++)
                {
                    if (nizFigura[i].MisUFiguri(mis.X, mis.Y))
                    {
                        if (((nizFigura[i].Status == "levi" || nizFigura[i].Status == "leviracunaj") && igracNaRedu == 2) ||
                            ((nizFigura[i].Status == "desni" || nizFigura[i].Status == "desniracunaj") && igracNaRedu == 1))
                        {
                            MessageBox.Show("Nemoguće je pomerati figure drugog igrača");
                            break;
                        }
                        else
                        {
                            selektovano = i;
                            rX = mis.X - nizFigura[i].pocetakX;
                            rY = mis.Y - nizFigura[i].pocetakY;
                            vrati.X = nizFigura[i].pocetakX;
                            vrati.Y = nizFigura[i].pocetakY;
                            nizFigura[i].OdrediPoljeUFiguri(mis.X, mis.Y);
                            Invalidate();
                            break;
                        }
                    }
                    else
                    {
                        selektovano = -1;
                        Invalidate();
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if (selektovano != -1)
                    {
                        nizFigura[selektovano].rotiraj();
                        Invalidate();
                    }
                }
                timerPomeranje.Enabled = true;
            }
        }

        private void KompjuterBira()
        {
            /*Random rnd = new Random();
            int br = rnd.Next(0, 12);*/
            for (int i = 0; i < 12; i++)
            {
                //int m = Math.Abs(i - br); //malo vise random, da ne bude prva sledeca
                if (nizFigura[i].Status == "slobodan")
                {
                    nizFigura[i].pocetakX = figure2Pozicije[brIzabranih2].X;
                    nizFigura[i].pocetakY = figure2Pozicije[brIzabranih2].Y;
                    nizFigura[i].Status = "desni"; //figura pripada desnom igracu
                    brIzabranih2++;
                    igracNaRedu = 1;
                    Invalidate();
                    return;
                }
            }


        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mis = PointToClient(MousePosition);
            if (selektovano != -1)
            {
                nizFigura[selektovano].pocetakX = mis.X - rX;
                nizFigura[selektovano].pocetakY = mis.Y - rY;
            }
        }
        int OstaloLevom = 6, OstaloDesnom = 6;

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (selektovano != -1 && tabla.FiguraUTabli(mis.X, mis.Y))
            {
                if (tabla.MozeFiguraUTablu(nizFigura[selektovano], mis.X, mis.Y))
                {
                    nizFigura[selektovano].Status = "naTabli";
                    novatabla.zameni(novatabla, tabla);
                    if (igracNaRedu == 1)
                    {
                        OstaloLevom--;
                        igracNaRedu = 2;
                        int z = Minimax(novatabla, 2, true);
                        MessageBox.Show(z.ToString());
                    }

                    else
                    {
                        OstaloDesnom--;
                        igracNaRedu = 1;
                    }

                    Invalidate();

                    labelBrIgraca.Text = igracNaRedu.ToString();
                    if (OstaloLevom <= 3 && OstaloDesnom <= 3 && KrajIgre(igracNaRedu))
                        MessageBox.Show("KRAJ IGRE");


                }
                else
                {
                    nizFigura[selektovano].pocetakX = vrati.X;
                    nizFigura[selektovano].pocetakY = vrati.Y;
                }

            }
            selektovano = -1;
            timerPomeranje.Enabled = false;
        }

        private void timerPomeranje_Tick(object sender, EventArgs e)
        {
            if (timerPomeranje.Enabled && selektovano != -1)
            {
                Invalidate();
            }

        }

        private void buttonNovaIgra_Click(object sender, EventArgs e)
        {
            selektovano = -1;
            for (int i = 0; i < 12; i++)
            {
                nizFigura[i].Status = "slobodan";
                nizFigura[i].Polozaj = 1; // vraca na pocetnu rotaciju
                nizFigura[i].PostaviPoziciju(nizPocPozicija[i].X, nizPocPozicija[i].Y);
            }

            tabla = new cTabla();
            novatabla.zameni(novatabla, tabla);
            fazaIgre = "biranjeFigura";
            brIzabranih1 = 0;
            brIzabranih2 = 0;
            OstaloLevom = 6;
            OstaloDesnom = 6;
            igracNaRedu = 1;
            Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
        }
        
        //bas je glup0
        private bool KrajIgre(int igracNaRedu)
        {

            for (int p = 0; p < 12; p++)
            {
                if (igracNaRedu == 1 && (nizFigura[p].Status == "levi" || nizFigura[p].Status == "leviracunaj"))
                {
                    for (int q = 0; q < 4; q++)
                    {
                        nizFigura[p].rotiraj();
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (tabla.MozeFiguraUTabluZaKraj(nizFigura[p], i, j))
                                    return false;
                            }
                        }
                    }
                }
                if (igracNaRedu == 2 && (nizFigura[p].Status == "desni" || nizFigura[p].Status == "desniracunaj"))
                {
                    for (int q = 0; q < 4; q++)
                    {
                        nizFigura[p].rotiraj();
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (tabla.MozeFiguraUTabluZaKraj(nizFigura[p], i, j))
                                    return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        


        private int Minimax(cTabla novatabla, int dubina, bool maximizingPlayer)
        {
            string status;
            int igracnaredu;
            if (maximizingPlayer)
            {
                status = "desniracunaj";
                igracnaredu = 2;
            }
            else
            {
                status = "leviracunaj";
                igracnaredu = 1;
            }

            if (dubina == 0)
            {
                int pot = brojmogucihpoteza(novatabla, status);
                MessageBox.Show(pot.ToString(), "brojmogucihpoteza");
                //return brojmogucihpoteza(novatabla, status);
                return pot;
            }
            
            if (KrajIgre(igracnaredu))
                return 0;
            if (maximizingPlayer)
            {
                int maxVrednost = int.MinValue;
                
                for (int p = 0; p < 12; p++)
                {
                    bool prekid = false;
                    if (nizFigura[p].Status == "desni" || nizFigura[p].Status == "desniracunaj")
                    {
                        for (int q = 0; q < 4; q++)
                        {
                            nizFigura[p].rotiraj();
                            for (int i = 0; i < 8; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    if (novatabla.MozeFiguraUTabluRacunaj(nizFigura[p], i, j))
                                    {
                                        nizFigura[p].Status = "desniracunaj";

                                        int vrednost = Minimax(novatabla, dubina - 1, false);
                                        maxVrednost = Math.Max(vrednost, maxVrednost);
                                        prekid = true;
                                        break;
                                    }
                                }
                                if (prekid) break;
                            }
                            if (prekid) break;
                        }
                    }
                }
                MessageBox.Show(maxVrednost.ToString(), "maxVrednost");
                return maxVrednost;
            }
            else
            {
                int minVrednost = int.MaxValue;


                for (int p = 0; p < 12; p++)
                {
                    bool prekid = false;
                    if (nizFigura[p].Status == "levi" || nizFigura[p].Status == "leviracunaj")
                    {
                        for (int q = 0; q < 4; q++)
                        {
                            nizFigura[p].rotiraj();
                            for (int i = 0; i < 8; i++)
                            {
                                for (int j = 0; j < 8; j++)
                                {
                                    if (novatabla.MozeFiguraUTabluRacunaj(nizFigura[p], i, j))
                                    {
                                        nizFigura[p].Status = "leviracunaj";


                                        int vrednost = Minimax(novatabla, dubina - 1, true);
                                        minVrednost = Math.Min(vrednost, minVrednost);
                                        prekid = true;
                                        break;
                                    }
                                }
                                if (prekid) break;
                            }
                            if (prekid) break;
                        }
                    }
                }
                MessageBox.Show(minVrednost.ToString(), "minVrednost");
                return minVrednost;
            }
        }

        private int brojmogucihpoteza(cTabla tablab, string status)
        {
            int broj = 0;
            for (int t = 0; t < 12; t++)
            {
                if (nizFigura[t].Status == status)
                {
                    for (int q = 0; q < 4; q++)
                    {
                        nizFigura[t].rotiraj();
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {

                                if (tablab.MozeFiguraUTabluZaKraj(nizFigura[t], i, j))
                                {
                                    broj++;
                                }
                            }
                        }
                    }
                } 
            }
            if (status == "leviracunaj")
                broj *= -1;
            return broj;

        }
    }

}
