namespace Classes
{
    public class NodeConnection
    {
        public Node Node { get; private set; }
        public double Distance { get; private set; }

        public NodeConnection(Node targetNode, double distance)
        {
            Node = targetNode;
            Distance = distance;
        }
    }
}
