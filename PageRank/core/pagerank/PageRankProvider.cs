using System;
using System.Collections.Generic;
using System.Linq;
using config.data;
using QuickGraph;
using model.graph;

namespace core.pagerank
{
    class PageRankProvider
    {
        public BidirectionalGraph<CustomVertex, CustomEdge> Graph { get; }

        public PageRankProvider(BidirectionalGraph<CustomVertex, CustomEdge> graph)
        {
            this.Graph = graph;
        }

        public Dictionary<CustomVertex, double> CalculatePageRank(bool normalize)
        {
            var vertexScoreMap = Graph.Vertices.ToDictionary(vertex => vertex, _ => StaticData.InitialVertexScore);
            var temporaryVertexScoreMap = Graph.Vertices.ToDictionary(vertex => vertex, _ => StaticData.InitialVertexScore);
            int iterationCount = 0;

            while (iterationCount < StaticData.MaxIteration)
            {
                int insignificantVerticesCount = 0;
                foreach (CustomVertex vertex in Graph.Vertices)
                {
                    double newScore = 0;

                    foreach (var edge in Graph.InEdges(vertex))
                    {
                        int outDegreeOfSourceVertex = Graph.OutDegree(edge.Source);
                        double scoreOfSourceVertex = vertexScoreMap[edge.Source] * edge.Weight;
                        newScore += scoreOfSourceVertex / Math.Max(1.0, outDegreeOfSourceVertex);
                    }

                    newScore *= StaticData.DampingFactor;
                    double trank = 1.0 - StaticData.DampingFactor + newScore;

                    if (CheckSignificantDiff(vertexScoreMap[vertex], trank))
                        temporaryVertexScoreMap[vertex] = trank;
                    else
                        insignificantVerticesCount++;
                }

                foreach (var kvp in temporaryVertexScoreMap)
                {
                    vertexScoreMap[kvp.Key] = kvp.Value;
                }

                iterationCount++;
                if (insignificantVerticesCount == Graph.VertexCount)
                    break;
            }

            if (normalize)
                return NormalizeVertexScoreMap(vertexScoreMap);
            else
                return vertexScoreMap;
        }

        bool CheckSignificantDiff(double oldValue, double newValue)
        {
            double diff = Math.Abs(newValue - oldValue);
            return diff > StaticData.SignificanceThreshold;
        }

        protected Dictionary<CustomVertex, Double> NormalizeVertexScoreMap(Dictionary<CustomVertex, Double> vertexScoreMap)
        {
            var normalizedVertexScoreMap = new Dictionary<CustomVertex, Double>();
            double maxRank = vertexScoreMap.Values.Max();
            foreach (var kvp in vertexScoreMap)
            {
                double score = kvp.Value;
                score /= maxRank;
                normalizedVertexScoreMap[kvp.Key] = score;
            }
            return normalizedVertexScoreMap;
        }

    }
}
