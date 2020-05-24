using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace pentominov1
{
    class cFigura
    {
        public int[,] mFigure;
        public SolidBrush bojaFigure;
        public SolidBrush bojaSFigure = new SolidBrush(Color.Black);
        private int tipFigure;

        public int TipFigure
        {
            get { return tipFigure; }
            set
            {
                tipFigure = value;
                napraviFiguru();
            }
        }
        private string status;
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
            }
        }
        private int trpolozaj = 1; // rotacije figura 1 - 4 (na pocetku je 1)
        public int Polozaj
        {
            get { return trpolozaj; }
            set
            {
                trpolozaj = value;
                if (trpolozaj == 1) // mnogo memorije?
                {
                    napraviFiguru();
                }
            }
        }

        public struct uredjeniPar
        {
            public int i;
            public int j;
        }
        public uredjeniPar selektovanoPolje;

        public cFigura()
        {
            mFigure = new int[5, 5];
        }

        private void napraviFiguru()
        {
            switch (tipFigure)
            {
                case 0: //F
                    mFigure = new int[5, 5]
                              {{ 0, 1, 1, 0, 0},
                               { 1, 1, 0, 0, 0},
                               { 0, 1, 0, 0, 0},
                               { 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0} };
                    bojaFigure = new SolidBrush(Color.DarkCyan);
                    break;
                case 1: // I
                    mFigure = new int[5, 5]
                              {{ 1, 0, 0, 0, 0},
                               { 1, 0, 0, 0, 0},
                               { 1, 0, 0, 0, 0},
                               { 1, 0, 0, 0, 0},
                               { 1, 0, 0, 0, 0} };
                    bojaFigure = new SolidBrush(Color.LightGreen);
                    break;
                case 2: // L
                    mFigure = new int[5, 5]
                              {{ 1, 0, 0, 0, 0},
                               { 1, 0, 0, 0, 0},
                               { 1, 0, 0, 0, 0},
                               { 1, 1, 0, 0, 0},
                               { 0, 0, 0, 0, 0} };
                    bojaFigure = new SolidBrush(Color.DeepPink);
                    break;
                case 3: // P
                    mFigure = new int[5, 5]
                              {{ 1, 1, 0, 0, 0},
                               { 1, 1, 0, 0, 0},
                               { 1, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0} };
                    bojaFigure = new SolidBrush(Color.Yellow);
                    break;
                case 4: // N
                    mFigure = new int[5, 5]
                              {{ 0, 1, 0, 0, 0},
                               { 1, 1, 0, 0, 0},
                               { 1, 0, 0, 0, 0},
                               { 1, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0} };
                    bojaFigure = new SolidBrush(Color.Blue);
                    break;
                case 5: // T
                    mFigure = new int[5, 5]
                              {{ 1, 1, 1, 0, 0},
                               { 0, 1, 0, 0, 0},
                               { 0, 1, 0, 0, 0},
                               { 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0} };
                    bojaFigure = new SolidBrush(Color.BlueViolet);
                    break;
                case 6: // U
                    mFigure = new int[5, 5]
                              {{ 1, 0, 1, 0, 0},
                               { 1, 1, 1, 0, 0},
                               { 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0} };
                    bojaFigure = new SolidBrush(Color.YellowGreen);
                    break;
                case 7: // V
                    mFigure = new int[5, 5]
                              {{ 1, 0, 0, 0, 0},
                               { 1, 0, 0, 0, 0},
                               { 1, 1, 1, 0, 0},
                               { 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0} };
                    bojaFigure = new SolidBrush(Color.Violet);
                    break;
                case 8: // W
                    mFigure = new int[5, 5]
                              {{ 1, 0, 0, 0, 0},
                               { 1, 1, 0, 0, 0},
                               { 0, 1, 1, 0, 0},
                               { 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0} };
                    bojaFigure = new SolidBrush(Color.Orange);
                    break;
                case 9: // X
                    mFigure = new int[5, 5]
                              {{ 0, 1, 0, 0, 0},
                               { 1, 1, 1, 0, 0},
                               { 0, 1, 0, 0, 0},
                               { 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0} };
                    bojaFigure = new SolidBrush(Color.LightPink);
                    break;
                case 10: // Y
                    mFigure = new int[5, 5]
                              {{ 0, 1, 0, 0, 0},
                               { 1, 1, 0, 0, 0},
                               { 0, 1, 0, 0, 0},
                               { 0, 1, 0, 0, 0},
                               { 0, 0, 0, 0, 0} };
                    bojaFigure = new SolidBrush(Color.PaleTurquoise);
                    break;
                case 11: // Z
                    mFigure = new int[5, 5]
                              {{ 1, 1, 0, 0, 0},
                               { 0, 1, 0, 0, 0},
                               { 0, 1, 1, 0, 0},
                               { 0, 0, 0, 0, 0},
                               { 0, 0, 0, 0, 0} };
                    bojaFigure = new SolidBrush(Color.Magenta);
                    break;
            }
        }
        public int pocetakX;
        public int pocetakY;

        public void PostaviPoziciju(int iX, int iY)
        {
            pocetakX = iX;
            pocetakY = iY;
        }
        public int dKvadratica = 15;
        public int dOkvira = 16;
        private Pen crna = new Pen(Color.Black, 1);
        public void Nacrtaj(Graphics g)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (mFigure[i, j] == 1)
                    {
                        //g.DrawRectangle(crna, pocetakX + dOkvira * j,
                        //   pocetakY + dOkvira * i, dOkvira, dOkvira);
                        g.DrawRectangle(crna, pocetakX + dKvadratica * j,
                          pocetakY + dKvadratica * i, dKvadratica, dKvadratica);
                        g.FillRectangle(bojaFigure, pocetakX + dKvadratica * j,
                            pocetakY + dKvadratica * i, dKvadratica, dKvadratica);
                    }
                }
            }
            //crna.Dispose();
        }
        public void Selektuj(Graphics g)
        {

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (mFigure[i, j] == 1)
                    {
                        //g.DrawRectangle(crna, pocetakX + dOkvira * j,
                        //   pocetakY + dOkvira * i, dOkvira, dOkvira);
                        g.DrawRectangle(crna, pocetakX + dKvadratica * j,
                          pocetakY + dKvadratica * i, dKvadratica, dKvadratica);
                        g.FillRectangle(bojaSFigure, pocetakX + dKvadratica * j,
                            pocetakY + dKvadratica * i, dKvadratica, dKvadratica);
                    }
                }
            }
            //crna.Dispose();
        }
        public bool MisUFiguri(int x, int y)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (mFigure[i, j] == 1)
                    {
                        if ((pocetakX + j * dKvadratica <= x &&
                            (pocetakX + (j + 1) * dKvadratica) >= x) &&
                            (pocetakY + i * dKvadratica <= y
                            && (pocetakY + (i + 1) * dKvadratica) >= y))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void OdrediPoljeUFiguri(int x, int y)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (mFigure[i, j] == 1)
                    {
                        if ((pocetakX + j * dKvadratica <= x &&
                            (pocetakX + (j + 1) * dKvadratica) >= x) &&
                            (pocetakY + i * dKvadratica <= y
                            && (pocetakY + (i + 1) * dKvadratica) >= y))
                        {
                            selektovanoPolje.i = i;
                            selektovanoPolje.j = j;
                        }
                    }
                }
            }
        }

        private bool iDrugaRot = false;
        public void rotiraj()
        {
            if (tipFigure == 1)
            {
                if (iDrugaRot)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        mFigure[0, i] = 0;
                        mFigure[i, 0] = 1;
                    }
                    iDrugaRot = !iDrugaRot;
                }
                else
                {
                    for (int i = 0; i < 5; i++)
                    {
                        mFigure[i, 0] = 0;
                        mFigure[0, i] = 1;
                    }
                    iDrugaRot = !iDrugaRot;
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    for (int j = i; j < 5 - i - 1; j++)
                    {
                        int pom = mFigure[i, j];
                        mFigure[i, j] = mFigure[j, 4 - i];
                        mFigure[j, 4 - i] = mFigure[4 - i, 4 - j];
                        mFigure[4 - i, 4 - j] = mFigure[4 - j, i];
                        mFigure[4 - j, i] = pom;
                    }
                }
                int iPrazno = 0, jPrazno = 0;
                for (int i = 0; i < 5; i++)
                {
                    bool promena = false;
                    for (int j = 0; j < 5; j++)
                    {
                        if (mFigure[i, j] != 0)
                        {
                            promena = true;
                            break;
                        }
                    }
                    if (promena)
                        break;
                    if (!promena)
                        iPrazno++;
                }

                for (int j = 0; j < 5; j++)
                {
                    bool promena = false;
                    for (int i = 0; i < 5; i++)
                    {
                        if (mFigure[i, j] != 0)
                        {
                            promena = true;
                            break;
                        }

                    }
                    if (promena)
                        break;
                    if (!promena)
                        jPrazno++;

                }

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (mFigure[i, j] == 1)
                        {
                            mFigure[Math.Abs(i - iPrazno), Math.Abs(j - jPrazno)] = 1;
                            mFigure[i, j] = 0;
                        }
                    }
                }
            }
        }
    }
}