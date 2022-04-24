using System;
using System.Collections.Generic;
using System.Text;

namespace CargoDelivery
{

    public class PrimAlg
    {
        private static double sonsuz = 999999999.0;
        double[,] Maliyet;
        int NodeSayisi;
        public PrimAlg(double[,] mat)
        {

            int i, j;
            Console.WriteLine(mat.Length);
            NodeSayisi = mat.GetLength(0);
            Maliyet = new double[NodeSayisi, NodeSayisi];
            for (i = 0; i < NodeSayisi; i++)
            {
                for (j = 0; j < NodeSayisi; j++)
                {
                    Maliyet[i, j] = mat[i, j];
                    if (Maliyet[i, j] == 0)
                    {
                        Maliyet[i, j] = sonsuz;
                    }
                }
            }
        }
        public int unReached(bool[] r)
        {

            bool done = true;
            for (int i = 0; i < r.Length; i++)
            {
                if (r[i] == false)
                {
                    return i;
                }

            }
            return -1;
        }
        public int[,] Prim()
        {
            int i, j, k, x, y;
            bool[] ulasildi = new bool[NodeSayisi];
            int[] preNode = new int[NodeSayisi];
            ulasildi[0] = true;
            for (k = 1; k < NodeSayisi; k++)
            {
                ulasildi[k] = false;
            }
            preNode[0] = 0;
            for (k = 1; k < NodeSayisi; k++)
            {
                x = y = 0;
                for (i = 0; i < NodeSayisi; i++)
                {
                    for (j = 0; j < NodeSayisi; j++)
                    {
                        if (ulasildi[i] && !ulasildi[j] && Maliyet[i, j] < Maliyet[x, y])
                        {
                            x = i;
                            y = j;
                        }
                    }
                }

                preNode[y] = x;
                ulasildi[y] = true;
            }

            Console.WriteLine(preNode.ToString());
            int[] a = preNode;
            var res = new int[NodeSayisi, 2];
            for (i = 0; i < NodeSayisi; i++) { Console.WriteLine(a[i] + ">" + i); res[i, 0] = a[i];res[i, 1] = i; }

            return res;
        }


    }
}
