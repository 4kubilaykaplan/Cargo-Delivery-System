using System;
using System.Collections.Generic;
using System.Device.Location;

namespace CargoDelivery
{
    class Distance
    {
        public int graphSize;
        List<double> locLatitude = new List<double>();
        List<double> locLongitude = new List<double>();

        public double CalculateDistance(double currentlat1, double lat2, double currentlong1, double long2)
        {
            var startloc = new GeoCoordinate(currentlat1, currentlong1);
            var stoploc = new GeoCoordinate(lat2, long2);
            return Convert.ToInt32(startloc.GetDistanceTo(stoploc) / 1000.0); // The distance is in kilometers.

        }

        /* void printSolution(double[,] dist)
         {

             for (int i = 0; i < nodeCount; ++i)
             {
                 for (int j = 0; j < nodeCount; ++j)
                 {
                     if (dist[i, j] == 0)
                     {
                         Console.Write("INF ");
                     }
                     else
                     {
                         Console.Write(dist[i, j] + " ");
                     }
                 }

                 Console.WriteLine();
             }
         }*/


        public double[,] CreateGraph(int graphSize, List<double> loclatitude, List<double> loclongitude)
        {

            double[,] DistanceMatrix = new double[graphSize, graphSize];
            for (int i = 0; i < graphSize; i++)
            {
                for (int t = 0; t < graphSize; t++)
                {
                    if (i == t)
                    {
                        DistanceMatrix[i, t] = 0.0;
                    }
                    else
                    {
                        double d = CalculateDistance(locLatitude[i], locLatitude[t], locLongitude[i], locLongitude[t]);
                        DistanceMatrix[i, t] = d;
                    }
                }
            }

            for (int k = 0; k < graphSize; k++)
            {
                // Pick all vertices as source
                // one by one
                for (int i = 0; i < graphSize; i++)
                {
                    // Pick all vertices as destination
                    // for the above picked source
                    for (int j = 0; j < graphSize; j++)
                    {
                        // If vertex k is on the shortest
                        // path from i to j, then update
                        // the value of dist[i][j]
                        if (DistanceMatrix[i, k] + DistanceMatrix[k, j] < DistanceMatrix[i, j])
                        {
                            DistanceMatrix[i, j] = DistanceMatrix[i, k] + DistanceMatrix[k, j];
                        }
                    }
                }
            }
            return DistanceMatrix;



        }




    }
}
