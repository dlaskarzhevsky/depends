using Depends.Core.Graph;
using System;
using System.Collections.Generic;

namespace Depends
{
    class ProjectFilter
    {
        DependencyGraph _graph;        

        public ProjectFilter(DependencyGraph graph)
        {
            _graph = graph;
        }

        public List<Node> Filter()
        {
            List<Node> listOfProjectNodes = new List<Node>();

            foreach (Node node in _graph.Nodes)
            {
                if (node.Id.Contains("csproj"))
                {
                    listOfProjectNodes.Add(node);
                }
            }

            return listOfProjectNodes;
        }
    }
}
