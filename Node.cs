namespace Assignmentsc_
{
     //property to store the nodes data
    public class Node<T>
{
    public T Data { 
        get;
        set; }
        
    //left child    
    public Node<T>? LeftNode {
         get; 
         set; 
         }
     
     //right child
    public Node<T>? RightNode { 
        get; 
        set; }

    //Node constructor
    public Node(T data)
    {
        Data = data;
        LeftNode = null;
        RightNode = null;
    }
}
}