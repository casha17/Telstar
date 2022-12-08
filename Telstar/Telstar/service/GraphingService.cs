using Dijkstra.NET.Graph;
using Dijkstra.NET.Graph.Simple;
using Dijkstra.NET.ShortestPath;
using Telstar.Data;

namespace Telstar.service;


public class GraphingService
{
    private ApplicationDbContext _context;
    public GraphingService(ApplicationDbContext context)
    {
        _context = context;
    }

    public Graph<string,string> buildGraph(bool isUsingCost)
    {

        //Fetch the cities (nodes) from the database
        var cities = _context.destinations.ToList();

        //Fetch our own edges from the database
        var edges = _context.edges.ToList();

        //Fetch the remaining edges from EI and OA API
        //var EIedges = getEIedges();
        //var OAedges = getOAedges();
        //edges.addAll(EIedges);
        //edges.addAll(OAedges);

        // Create a new Graph object
        var graph = new Graph<string, string>();

        //Add all of the cities as nodes to the graph
        foreach (var city in cities)
        {
            graph.AddNode(city.City);
        }

        // Add the edges to the graph and reverse edges
        /*
        if (isUsingCost) {
            foreach (var edge in edges)
            {
                graph.Connect(edge.city1, edge.city2, edge.cost, "Cost");
                graph.Connect(edge.city2, edge.city1, edge.cost, "Cost");
            }
        }
        else
        {
            foreach (var edge in edges)
            {
                graph.Connect(edge.city1, edge.city2, edge.TimeHours, "Time");
                graph.Connect(edge.city2, edge.city1, edge.TimeHours, "Time");
            }

        }*/
        return graph;
    }

    public void getEIedges()
    {
        //Contruct the API call with parameters needed

    }

    public void getOAedges()
    {
        //Contruct the API call with parameters needed

    }

    public ShortestPathResult getShortestPath(Graph graph, uint from, uint to)
    {
        var path = graph.Dijkstra(from, to);
        return path;
    }


}