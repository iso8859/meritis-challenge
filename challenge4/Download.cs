using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuikGraph;
using QuikGraph.Algorithms;

public class Download : BaseChallenge
{

    public class ServerLink
    {
        public Server server;
        public int time;

        public override string ToString() => $"{server};t={time}";
    }

    public class Server
    {
        public int serverId;
        public List<int> files = new List<int>();
        public List<ServerLink> links = new List<ServerLink>();

        public override string ToString() => $"{serverId};f={files.Count};l={links.Count}";

        public static Server Parse(string[] items, HashSet<int> files)
        {
            Server server = new Server() { serverId = int.Parse(items[0]) };
            for (int i = 1; i < items.Length; i++)
            {
                int fileId = int.Parse(items[i]);
                files.Add(fileId);
                server.files.Add(fileId);
            }
            return server;
        }

        public void AddLink(Server otherServer, int time)
        {
            ServerLink existing = links.Find(_ => _.server.serverId == otherServer.serverId);
            if (existing != null)
                existing.time = Math.Max(existing.time, time);
            else
                links.Add(new ServerLink() { server = otherServer, time = time });
        }
    }

    public override void Run()
    {
        Console.WriteLine("--- Challenge4 (pas optimum, pas terminé)");
        
        List<Server> servers = new List<Server>();
        var server0 = new Server() { serverId = 0 };
        servers.Add(server0);

        BidirectionalGraph<int, TaggedEdge<int, int>> graph = new();

        int index = 0;
        HashSet<int> files = new HashSet<int>();
        ReadTextFile("challenge4\\server.txt", items =>
        {
            if (index < 2500)
                servers.Add(Server.Parse(items, files));
            else
            {
                var source1 = servers.Find(s => s.serverId == int.Parse(items[0]));
                var source2 = servers.Find(s => s.serverId == int.Parse(items[1]));
                source1.AddLink(source2, int.Parse(items[2]));
                source2.AddLink(source1, int.Parse(items[2]));
                graph.AddVerticesAndEdge(new TaggedEdge<int, int>(source1.serverId, source2.serverId, int.Parse(items[2])));
            }
            index++;
        });

        // Trouver les serveurs les plus proches (time le plus petit)
        // Pour cela on va calculer le temps total pour arriver sur un serveur en additionnant le temps pour y arriver
        List<ServerLink> st = new List<ServerLink>();

        foreach (var server in servers)
        {
            foreach (var link in server.links)
            {
                var s = st.Find(_ => _.server.serverId == link.server.serverId);
                if (s == null)
                    st.Add(new ServerLink() { server = link.server, time = link.time });
                else
                    s.time += link.time;
                s = st.Find(_ => _.server.serverId == server.serverId);
                if (s == null)
                    st.Add(new ServerLink() { server = server, time = link.time });
                else
                    s.time += link.time;
            }
        }

        // Ordonner par le temps
        st.Sort((a, b) => a.time.CompareTo(b.time));

        int total = 3600;
        int count = 0;
        foreach (ServerLink sl in st)
        {
            var tryGetPaths = graph.ShortestPathsDijkstra(e => e.Tag, 0);
            if (tryGetPaths(sl.server.serverId, out IEnumerable<TaggedEdge<int, int>> edges))
            {
                foreach (var edge in edges)
                {
                    count++;
                    Console.WriteLine(edge.Source + "=>" + edge.Target + ":" + edge.Tag + " " + total + " " + count);
                    total -= edge.Tag;
                }
            }
            if (total < 0)
                break;
        }

        return;

        //HashSet<int> downloaded = new HashSet<int>();
        //server0.links.Sort((a, b) => a.time.CompareTo(b.time));
        //while (total>0)
        //{
        //    foreach (var link in server0.links)
        //    {
        //        bool bFound = false;
        //        while (!bFound)
        //        {
        //            foreach (int file in link.server.files)
        //            {
        //                if (!downloaded.Contains(file))
        //                {
        //                    Console.WriteLine($"{link.server.serverId} {file} {link.time}");
        //                    downloaded.Add(file);
        //                    total -= link.time;
        //                    count++;
        //                    bFound = true;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //}
        // Trouver toutes les routes les plus courtes pour chaque serveur
        for (int d = 0; d < 60; d++)
        {
            List<int> final = new List<int>();
            foreach (Server server in servers)
            {
                foreach (var link in server.links)
                {
                    if (link.time == d)
                        final.Add(link.server.serverId);
                }
            }
            // Trier les serveur les plus proches du serveur 0
            foreach (int serverId in final)
            {
                var tryGetPaths = graph.ShortestPathsDijkstra(e => e.Tag, 0);
                if (tryGetPaths(serverId, out IEnumerable<TaggedEdge<int, int>> edges))
                {
                    foreach (var edge in edges)
                    {
                        count++;
                        Console.WriteLine(edge.Source + "=>" + edge.Target + ":" + edge.Tag + " " + total + " " + count);
                        total -= edge.Tag;
                    }
                }
            }
            if (total <= 0)
                break;
        }
    }
}
