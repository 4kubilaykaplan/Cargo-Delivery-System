using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CargoDelivery
{

    class Graph
    {

        private List<NodeData> vertices;
        private int graphSize;
       // private double[,] adjMatrix;
        private const int infinity = 9999;

        class NodeData
        {

            List<int> indexNo = new List<int>();
            List<double> locLat = new List<double>();
            List<double> locLong = new List<double>();
            public NodeData(double lat, double longi, int index)
            {
                locLat.Add(lat);
                locLong.Add(longi);
                indexNo.Add(index);
            }
        }
        public Graph(int graphSize, List<double> loclatitude, List<double> loclongitude)
        {

            vertices = new List<NodeData>();
            //adjMatrix= CreateGraph(graphSize,loclatitude,loclongitude);

        }

        public void RunDijkstra()
        {


        }

    }
}
