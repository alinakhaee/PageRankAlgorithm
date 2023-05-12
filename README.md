# PageRankAlgorithm
In this project I have implemented the PageRank algorithm and I used [this Java repository](https://github.com/masud-technope/PageRank-MR) as my source and convert it to a C# project. <br>
The main class, inside which you can find the algorithm, is `PageRankProvider` which is located in the `core.pagerank` namespace.

# Definition
PageRank is an algorithm used to measure the importance or "rank" of nodes in a graph. It was originally developed by Google to help rank web pages in their search engine, but has since been adapted for use in other types of graphs.<br>
<br>
The algorithm works by considering each node in the graph as a "web page" and calculating its importance based on the importance of the nodes that link to it. The basic idea is that a node is important if it is linked to by other important nodes.<br>
<br>
The PageRank algorithm assigns a score to each node in the graph based on the following formula:<br>
<br>
PR(A) = (1-d) + d (PR(T1)/C(T1) + ... + PR(Tn)/C(Tn)) <br>
<br>
Where:<br>
<br>
PR(A) is the PageRank score for node A <br>
d is a damping factor that determines the probability of a user clicking on a random link <br>
T1...Tn are the nodes that link to node A <br>
C(T1)...C(Tn) are the number of outbound links from each of the nodes that link to node A <br>
PR(T1)...PR(Tn) are the PageRank scores for each of the nodes that link to node A <br>
The algorithm works by iteratively calculating the PageRank scores for each node in the graph. At each iteration, the score for each node is updated based on the scores of the nodes that link to it. The algorithm continues until the scores for all nodes converge, or when a maximum number of iterations is reached. <br>

Nodes with higher PageRank scores are considered more important than nodes with lower scores. In a web page ranking scenario, pages with higher PageRank scores would be more likely to appear at the top of search engine results. <br>

The PageRank algorithm has many applications beyond web page ranking, including social network analysis, recommendation systems, and more. It is a powerful tool for analyzing the importance of nodes in a graph and understanding the structure of complex networks. <br>

## How To Use
My project is capable of both weighted and unweighted graphs and it can handle bi-directional graphs. <br>
I have created a `CustomVertex` class, so that in the future we can store more properties of a vertex rather than just a simple string as its name. <br>
I have also created a class called `CustomEdge` that implements the `IEdge` interface of `QuickGraph` library, so that we could store it in the `BidirectionalGraph`. <br>
This `CustomEdge` class can either be a weighted or normal edge. It has two constructors, one of which takes only source and target vertex and a default value of 1.0 would be set as its weight, the other one takes three arguments, source, target and weight. <br>
To use the algorithm, you should initially define the nodes and edges, and just call the `PageRankProvider.CalculatePageRank(bool normalize)` function. <br>
Below is as an example of unweighted graph: <br>
```
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
```
