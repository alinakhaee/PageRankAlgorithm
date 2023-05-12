using System;
using System.Linq;
using model.graph;
using QuickGraph;
using core.pagerank;

namespace PageRank
{
    class Program
    {
        static void Main(string[] args)
        {
            // unweighted graph
            var graph = new BidirectionalGraph<CustomVertex, CustomEdge>();
            CustomVertex vertex1 = new CustomVertex("1");
            CustomVertex vertex2 = new CustomVertex("2");
            CustomVertex vertex3 = new CustomVertex("3");
            CustomVertex vertex4 = new CustomVertex("4");

            graph.AddVertex(vertex1);
            graph.AddVertex(vertex2);
            graph.AddVertex(vertex3);
            graph.AddVertex(vertex4);

            graph.AddEdge(new CustomEdge(vertex1, vertex2));
            graph.AddEdge(new CustomEdge(vertex2, vertex3));
            graph.AddEdge(new CustomEdge(vertex2, vertex4));
            graph.AddEdge(new CustomEdge(vertex3, vertex2));
            graph.AddEdge(new CustomEdge(vertex4, vertex3));

            PageRankProvider pageRankProvider = new PageRankProvider(graph);
            var tokenDB = pageRankProvider.CalculatePageRank(false);
            Console.WriteLine("Unweighted Graph PageRank:");
            tokenDB.ToList().ForEach(x => Console.WriteLine($"{x.Key}: {x.Value}"));

            Console.WriteLine("");

            // weighted graph
            var weightedGraph = new BidirectionalGraph<CustomVertex, CustomEdge>();
            CustomVertex vertex1Weighted = new CustomVertex("1");
            CustomVertex vertex2Weighted = new CustomVertex("2");
            CustomVertex vertex3Weighted = new CustomVertex("3");
            CustomVertex vertex4Weighted = new CustomVertex("4");

            weightedGraph.AddVertex(vertex1Weighted);
            weightedGraph.AddVertex(vertex2Weighted);
            weightedGraph.AddVertex(vertex3Weighted);
            weightedGraph.AddVertex(vertex4Weighted);

            weightedGraph.AddEdge(new CustomEdge(vertex1Weighted, vertex2Weighted, 1.0));
            weightedGraph.AddEdge(new CustomEdge(vertex2Weighted, vertex3Weighted, 1.1));
            weightedGraph.AddEdge(new CustomEdge(vertex2Weighted, vertex4Weighted, 1.2));
            weightedGraph.AddEdge(new CustomEdge(vertex3Weighted, vertex2Weighted, 1.3));
            weightedGraph.AddEdge(new CustomEdge(vertex4Weighted, vertex3Weighted, 1.4));

            PageRankProvider pageRankProviderWeighted = new PageRankProvider(weightedGraph);
            var tokenDBWeighted = pageRankProviderWeighted.CalculatePageRank(true);
            Console.WriteLine("Weighted Graph PageRank:");
            tokenDBWeighted.ToList().ForEach(x => Console.WriteLine($"{x.Key}: {x.Value}"));
        }
    }
}
