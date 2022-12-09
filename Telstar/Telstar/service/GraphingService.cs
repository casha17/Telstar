using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;
using Humanizer;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using Telstar.Data;
using Telstar.DTOs;
using Telstar.Models;
using Telstar.service;

namespace Telstar.service;


public class GraphingService : IGraphingService
{
    private ApplicationDbContext _context;
    private IshipmentService shipmentService;
    private ICalloutService calloutService;
    public GraphingService(ApplicationDbContext context, IshipmentService shipmentService, ICalloutService calloutService)
    {
        _context = context;
        this.shipmentService = shipmentService;
        this.calloutService = calloutService;
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

    public List<Models.Edge> getEIedges(Shipment shipment)
    {
        //Contruct the API call with parameters needed
        var task = Task.Run(() => this.calloutService.calloutEITC(shipment));
        task.Wait();
        List<EdgeResponseDTO> edgeResponseDTOs = task.Result;
        return edgeResponseDTOs.Select(e => new Models.Edge() { To = e.City1, From = e.City2, Cost = Decimal.ToDouble(e.CostInUSD), TimeHours = Decimal.ToDouble(e.TimeInHours) }).ToList();
    }

    public List<Models.Edge> getOAedges(Shipment shipment)
    {
        //Contruct the API call with parameters needed

        //Contruct the API call with parameters needed
        
        var task = Task.Run(() => this.calloutService.calloutOA(shipment));
        task.Wait();
        List<EdgeResponseDTO> edgeResponseDTOs = task.Result;
        return edgeResponseDTOs.Select(e => new Models.Edge() { To = e.City1, From = e.City2, Cost = Decimal.ToDouble(e.CostInUSD), TimeHours = Decimal.ToDouble(e.TimeInHours) }).ToList();
        
        // return new List<Models.Edge>() { };
    }

    public ShortestPathResult getCheapestPath(Shipment shipment, string from, string to)
    {


        //Fetch the cities (nodes) from the database
        var cities = shipmentService.GetDestination();
        Dictionary<String, uint> cityIndexDictionary = new Dictionary<String, uint>();
        for (uint i = 0; i < cities.Count; i++)
        {
            cityIndexDictionary.Add(cities[(int)i].City, i);
        }
        var graph = this.buildGraph(shipment, cities);
        var connectedGraph = this.connectLowestCostGraph(graph, cityIndexDictionary, shipment);
        var path = connectedGraph.Dijkstra(cityIndexDictionary.GetValueOrDefault(from), cityIndexDictionary.GetValueOrDefault(to));
        return path;
    }


    public ShortestPathResult getQuickestPath(Shipment shipment, string from, string to)
    {


        //Fetch the cities (nodes) from the database
        var cities = shipmentService.GetDestination();
        Dictionary<String, uint> cityIndexDictionary = new Dictionary<String, uint>();
        for (uint i = 0; i < cities.Count; i++)
        {
            cityIndexDictionary.Add(cities[(int)i].City, i);
        }
        var graph = this.buildGraph(shipment, cities);
        var connectedGraph = this.connectShortestTimeGraph(graph, cityIndexDictionary, shipment);
        var path = connectedGraph.Dijkstra(cityIndexDictionary.GetValueOrDefault(from), cityIndexDictionary.GetValueOrDefault(to));
        return path;
    }

    private List<Models.Edge> findEdges(Shipment shipment)
    {

        //Fetch our own edges from the database
        var edges = _context.edges.ToList();

        //Fetch the remaining edges from EI and OA API
        List<Company> allowedCompanies = shipmentService.findAllowedExternalCompanies(shipment);
        if (allowedCompanies.Contains(Company.EITC))
        {
            edges.AddRange(getEIedges(shipment));
        }
        if (allowedCompanies.Contains(Company.OA))
        {
            edges.AddRange(getOAedges(shipment));
        }
        var camelCaseEdges = edges.Select(edge => new Models.Edge() { From = this.ConvertToCamelCase(edge.From), To = this.ConvertToCamelCase(edge.To), Cost = edge.Cost, TimeHours = edge.TimeHours }).ToList();
        return  camelCaseEdges;
    }

    private string ConvertToCamelCase(String input)
    {
        return String.Join(" ", input.Split(" ").Select(namePart => namePart.Substring(0, 1).ToUpper() + namePart.Substring(1).ToLower()));
    } 


}