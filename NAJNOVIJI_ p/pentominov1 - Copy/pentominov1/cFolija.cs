using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pentominov1
{
    class cFolija
    {
        int[,] mFolije;
        public cFolija()
        {
            mFolije = new int[16,16];
        }

        public bool ZalepiFiguru(cFigura figura, int poljeTi, int poljeTj) 
        {
            int pocFigureI = (poljeTi + 4) - figura.selektovanoPolje.i;
            int pocFigureJ = (poljeTj + 4) - figura.selektovanoPolje.j;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mFolije[i + pocFigureI, j + pocFigureJ] = figura.mFigure[i, j] * (figura.TipFigure + 1);
                }
            }
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    if (mFolije[i,j] != 0 && (i < 4 || i > 11 || j < 4 || j > 11))
                        return false;
                }
            }
            return true;
        }

        public int[,] Iseci()
        {
            int[,] matrica = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    matrica[i, j] = mFolije[i + 4, j + 4];
                }
            }
            return matrica;
        }


    }
}
