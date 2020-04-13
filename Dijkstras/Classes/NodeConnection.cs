namespace Classes
{
    public class NodeConnection
    {
        public Node Node { get; private set; }
        public int Distance { get; private set; }

        public NodeConnection(Node targetNode, int distance)
        {
            Node = targetNode;
            Distance = distance;
        }
    }
}
