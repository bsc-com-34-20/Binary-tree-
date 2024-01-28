namespace Assignmentsc_
{
  public class BinaryTree<T> where T : IComparable<T>
{
    //Binarytree root node
    private Node<T>? root;

    //insert a node with data into the binary tree    
    public void Insert(T data)
    {
        root = InsertRecursive(root, data);
    }

    //inserting a node recursively 
    private Node<T> InsertRecursive(Node<T>? node, T data)
    {
        //if the node is null, create a node with the given data 
        if (node == null)
        {
            return new Node<T>(data);
        }
        //compare data and insert reecursively in the left or right subtree
        if (data.CompareTo(node.Data) < 0)
        {
            node.LeftNode = InsertRecursive(node.LeftNode, data);
        }
        else if (data.CompareTo(node.Data) > 0)
        {
            node.RightNode = InsertRecursive(node.RightNode, data);
        }

        return node;
    }

    //search for a node with the specified data in the binary tree
    public bool Search(T data, out Node<T>? foundNode, out Node<T>? parentNode, out Node<T>? leftChild, out Node<T>? rightChild)
    {
        foundNode = null;
        parentNode = null;
        leftChild = null;
        rightChild = null;

        return SearchRecursive(root, data, null, ref foundNode, ref parentNode, ref leftChild, ref rightChild);
    }

    //searching a node in binary tree recursively 
    private bool SearchRecursive(Node<T>? node, T data, Node<T>? parent, ref Node<T>? foundNode, ref Node<T>? parentNode, ref Node<T>? leftChild, ref Node<T> rightChild)
    {
        if (node == null)
        {
            return false;
        }

        if (data.CompareTo(node.Data) == 0)
        {
            foundNode = node;
            parentNode = parent;
            leftChild = node.LeftNode;
            rightChild = node.RightNode;
            return true;
        }

        if (data.CompareTo(node.Data) < 0)
        {
            return SearchRecursive(node.LeftNode, data, node, ref foundNode, ref parentNode, ref leftChild, ref rightChild);
        }
        else
        {
            return SearchRecursive(node.RightNode, data, node, ref foundNode, ref parentNode, ref leftChild, ref rightChild);
        }
    }

     //remove a specified node from a binary tree
    public void Remove(T data)
    {
        if (!Search(data, out _, out _, out _, out _))
    {
        Console.WriteLine($"\t{data} does not exist .");
        return;
    }
    else{
      root = RemoveRecursive(root, data);
      Console.WriteLine($"\tremoved from the tree.");
    }
       
    }

    //remove a node recursively from the binary tree
    private Node<T>? RemoveRecursive(Node<T>? node, T data)
    {
        if (node == null)
        {
            return null;
        }

        if (data.CompareTo(node.Data) < 0)
        {
            node.LeftNode = RemoveRecursive(node.LeftNode, data);
        }
        else if (data.CompareTo(node.Data) > 0)
        {
            node.RightNode = RemoveRecursive(node.RightNode, data);
        }
        else
        {
            if (node.LeftNode == null)
            {
                return node.RightNode;
            }
            else if (node.RightNode == null)
            {
                return node.LeftNode;
            }

            node.Data = FindMinValue(node.RightNode);
            node.RightNode = RemoveRecursive(node.RightNode, node.Data);
        }

        return node;
    }

    private T FindMinValue(Node<T>? node)
    {
        T minValue = node.Data;
        while (node.LeftNode != null)
        {
            minValue = node.LeftNode.Data;
            node = node.LeftNode;
        }
        return minValue;
    }
    public void InOrderTraversal()
    {
        if(root == null){
            Console.WriteLine("\tThe Tree is empty");
        }
        else{
        Console.Write("\tInorder Traversal: ");
        InOrderTraversalRecursive(root);
        Console.WriteLine();
        }
    }

    private void InOrderTraversalRecursive(Node<T>? node)
    {
        if(root != null){
            InOrderTraversalRecursive(node.LeftNode);
            Console.Write(node.Data + " ");
            InOrderTraversalRecursive(node.RightNode);
        }
    }

    //Postorder Go to the Left then the right then the root recursively
    public void PostOrderTraversal()
    {
        if(root ==null){
            Console.WriteLine("\tThe Tree is empty");
        }
        else{
        Console.Write("\tPostorder Traversal: ");
        PostOrderTraversalRecursive(root );
        Console.WriteLine();
        }
    }

    private void PostOrderTraversalRecursive(Node<T>? node)
    {
        if (node == null)
        {
            PostOrderTraversalRecursive(node.LeftNode);
            PostOrderTraversalRecursive(node.RightNode);
            Console.Write(node.Data + " ");
        }
    }

    //6 Additional methods for testing and demonstration purposes

    public void PrintNodeInfo(Node<T>? node)
    {
        Console.WriteLine("\tNode Info:");
        Console.WriteLine("\tNode: " + node.Data);
        Console.WriteLine("\tLeft Node: " + (node.LeftNode != null ? node.LeftNode.Data.ToString() : "null"));
        Console.WriteLine("\tRight Node: " + (node.RightNode != null ? node.RightNode.Data.ToString() : "null"));
        Console.WriteLine();
    }
}

}