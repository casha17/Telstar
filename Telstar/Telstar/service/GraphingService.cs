using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;
using Telstar.Data;
using Telstar.Models;
using Telstar.service;

namespace Telstar.service;


public class GraphingService : IGraphingService
{
    private ApplicationDbContext _context;
    private IshipmentService shipmentService;
    public GraphingService(ApplicationDbContext context, IshipmentService shipmentService)
    {
        _context = context;
        this.shipmentService = shipmentService;
    }

    public Graph<uint, string> buildGraph(Shipment shipment, List<Destination> cities)
    {

        // Create a new Graph object
        var graph = new Graph<uint, string>();

        //Add all of the cities as nodes to the graph
        for (uint i=0;i<cities.Count;i++)
        {
            graph.AddNode(i);
        }
        return graph;
    }

    public Graph<uint, string> connectLowestCostGraph(Graph<uint, string> graph, Dictionary<String, uint> cityIndexDictionary, Shipment shipment)
    {
        var edges = this.findEdges(shipment);

        foreach (Models.Edge edge in edges)
        {
            graph.Connect(cityIndexDictionary.GetValueOrDefault(edge.From), cityIndexDictionary.GetValueOrDefault(edge.To), (int) edge.Cost * 100, "Cost");
            graph.Connect(cityIndexDictionary.GetValueOrDefault(edge.To), cityIndexDictionary.GetValueOrDefault(edge.From), (int) edge.Cost * 100, "Cost");
        }
        return graph;

    }


    public Graph<uint, string> connectShortestTimeGraph(Graph<uint, string> graph, Dictionary<String, uint> cityIndexDictionary, Shipment shipment)
    {
        var edges = this.findEdges(shipment);

        foreach (Models.Edge edge in edges)
        {
            graph.Connect(cityIndexDictionary.GetValueOrDefault(edge.From), cityIndexDictionary.GetValueOrDefault(edge.To), (int)edge.TimeHours * 100, "Time");
            graph.Connect(cityIndexDictionary.GetValueOrDefault(edge.To), cityIndexDictionary.GetValueOrDefault(edge.From), (int)edge.TimeHours * 100, "Time");
        }
        return graph;

    }

    public List<Models.Edge> getEIedges()
    {
        //Contruct the API call with parameters needed
        return new List<Models.Edge>();
    }

    public List<Models.Edge> getOAedges()
    {
        //Contruct the API call with parameters needed
        return new List<Models.Edge>();
    }

    public ShortestPathResult getCheapestPath(Shipment shipment, string from, string to)
    {


        //Fetch the cities (nodes) from the database
        var cities = shipmentService.GetDestination();
        Dictionary<String, uint> cityIndexDictionary = new Dictionary<String, uint>();
        for (uint i = 0; i < cities.Count; i++)
        {
            cityIndexDictionary.Add(cities[(int)i].City, i+1);
        }
        var graph = this.buildGraph(shipment, cities);
        var connectedGraph = this.connectLowestCostGraph(graph, cityIndexDictionary, shipment);
        var toCity = cityIndexDictionary.GetValueOrDefault(to) + 1;
        var fromCity = cityIndexDictionary.GetValueOrDefault(from) + 1;
        var path = connectedGraph.Dijkstra(fromCity, toCity);
        return path;
    }


    public ShortestPathResult getQuickestPath(Shipment shipment, string from, string to)
    {


        //Fetch the cities (nodes) from the database
        var cities = shipmentService.GetDestination();
        Dictionary<String, uint> cityIndexDictionary = new Dictionary<String, uint>();
        for (uint i = 0; i < cities.Count; i++)
        {
            cityIndexDictionary.Add(cities[(int)i].City, i+1);
        }
        var graph = this.buildGraph(shipment, cities);
        var connectedGraph = this.connectShortestTimeGraph(graph, cityIndexDictionary, shipment);
        var toCity = cityIndexDictionary.GetValueOrDefault(to) +1;
        var fromCity = cityIndexDictionary.GetValueOrDefault(from) +1;
        var path = connectedGraph.Dijkstra(fromCity, toCity);
        return path;
    }

    private List<Models.Edge> findEdges(Shipment shipment)
    {

        //Fetch our own edges from the database
        var edges = _context.edges.ToList();

        //Fetch the remaining edges from EI and OA API
        var allowedCompanies = shipmentService.findAllowedExternalCompanies(shipment);
        if (allowedCompanies.Contains(Company.EITC))
        {
            edges.AddRange(getEIedges());
        }
        if (allowedCompanies.Contains(Company.OA))
        {
            edges.AddRange(getOAedges());
        }
        return edges;
    }


}