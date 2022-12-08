using Dijkstra.NET.Graph;
using Dijkstra.NET.Graph.Simple;
using Dijkstra.NET.ShortestPath;

namespace TelstarLogistics.service;

using Dijkstra.NET;
using Dijkstra.NET.Model;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


public class GraphingService
{

    public Graph buildGraph()
    {

        //Fetch the edges from the database
        
        
        //Fetch the remaining edges from EI and OA API
        

        // Create a new Graph object
        var graph = new Graph();

        // Add the nodes to the graph
        foreach (var node in nodes)
        {
            graph.AddNode(node.Id);
        }

        // Add the edges to the graph
        

        return graph;
    }

    public ShortestPathResult getShortestPath(Graph graph, string from, string to, bool useTime)
    {

        ShortestPathResult path = new ShortestPathResult();
        
        if (useTime)
        {
            path = graph.Dijkstra(from, to, weight => weight.Time);
        }
        else
        {
            path= graph.Dijkstra(from, to, weight => weight.Cost);
        }

        return path;
    }



}