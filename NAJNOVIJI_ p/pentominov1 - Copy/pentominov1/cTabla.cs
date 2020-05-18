using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace pentominov1
{
    class cTabla
    {
        private int[,] mTable;
        private SolidBrush bojaTable = new SolidBrush(Color.White);

        public int tackaumatriciI;
        public int tackaumatriciJ;
        public SolidBrush[] boje = {new SolidBrush(Color.White),new SolidBrush(Color.DarkCyan),new SolidBrush(Color.LightGreen),new SolidBrush(Color.DeepPink),new SolidBrush(Color.Yellow),new SolidBrush(Color.Blue),
            new SolidBrush(Color.BlueViolet),new SolidBrush(Color.YellowGreen),
            new SolidBrush(Color.Violet),new SolidBrush(Color.Orange),new SolidBrush(Color.LightPink),new SolidBrush(Color.PaleTurquoise),
            new SolidBrush(Color.Magenta), new SolidBrush(Color.DarkGray)}; // bela = 0; siva = 13 (figure od 1 do 12)
        private int dKvadratica = 15;
        public cTabla()
        {
            mTable = new int[8, 8];
            napraviTablu();
        }
        private void napraviTablu()
        {
            for (int i = 2; i <= 5; i++)
            {
                mTable[i, i] = 13;
            }
            /*mTable[3, 3] = 13;
            mTable[3, 4] = 13;
            mTable[4, 3] = 13;
            mTable[4, 4] = 13;*/ //?
        }
        private int pocX = 350;
        private int pocY = 60;
        public void NacrtajTablu(Graphics g)
        {
            Pen crna = new Pen(Color.Black, 2);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    g.DrawRectangle(crna, pocX + dKvadratica * j,
                             pocY + dKvadratica * i, dKvadratica, dKvadratica);
                    g.FillRectangle(boje[mTable[i, j]], pocX + dKvadratica * j,
                        pocY + dKvadratica * i, dKvadratica, dKvadratica);
                }
            }
            crna.Dispose();
        }


        
        public void poljeumatrici(int x, int y) //xy misa
        {
            tackaumatriciI = (y - pocY) / dKvadratica;
            tackaumatriciJ = (x - pocX) / dKvadratica;
        }

        public bool MozeFiguraUTablu(cFigura figura, int x, int y) //xy misa
        {
            cFolija folija = new cFolija();
            poljeumatrici(x, y);
            bool moze = true;
            int[,] isecenaFolija = new int[8,8];
            if (folija.ZalepiFiguru(figura, tackaumatriciI, tackaumatriciJ))
            {
                isecenaFolija = folija.Iseci();
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (mTable[i, j] != 0 && isecenaFolija[i, j] != 0)
                            moze = false;
                    }
                }
            }
            else 
                moze = false;
            if (moze)
                UpisiFiguruUTablu(isecenaFolija);

            return moze;
        }


        public bool MozeFiguraUTabluZaKraj(cFigura figura, int i, int j)
        {
            cFolija folija = new cFolija();
            bool moze = true;
            int[,] isecenaFolija = new int[8, 8];
            if (folija.ZalepiFiguru(figura, i, j))
            {
                isecenaFolija = folija.Iseci();
                for (int p = 0; p < 8; p++)
                {
                    for (int q = 0; q < 8; q++)
                    {
                        if (mTable[p, q] != 0 && isecenaFolija[p, q] != 0)
                            moze = false;
                    }
                }
            }
            else
                moze = false;
            if (moze)
                UpisiFiguruUTablu(isecenaFolija);

            return moze;
        }

        public void UpisiFiguruUTablu(int[,] mfolije)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(mTable[i,j] == 0)
                        mTable[i, j] = mfolije[i, j];
                }
            }
        }

        public bool FiguraUTabli(int x, int y) //x,y od misa
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (mTable[i, j] == 0)
                    {
                        if ((pocX + j * dKvadratica <= x &&
                            (pocX + (j + 1) * dKvadratica) >= x) &&
                            (pocY + i * dKvadratica <= y
                            && (pocY + (i + 1) * dKvadratica) >= y))
                        {
                            return true;
                        }
                    }
                }
            }
            if ((pocX <= x && (pocX + 8 * dKvadratica) >= x) && (pocY <= y) && (pocY + 8 * dKvadratica) >= y)
            {
                return true;
            }
            return false;
        }

        public int mI, mJ;

        public void poljeumatriciPar(int x, int y)
        {

            mI = (y - pocY) / dKvadratica;
            mJ = (x - pocX) / dKvadratica;
        }

        public bool MisUTabli(int x, int y)
        {

            if ((pocX <= x && (pocX + 8 * dKvadratica) >= x) && (pocY <= y) && (pocY + 8 * dKvadratica) >= y)
            {
                poljeumatriciPar(x, y);
                return true;
            }
            return false;
        }
        
    }
}
