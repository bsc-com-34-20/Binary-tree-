namespace Assignmentsc_
{
   class Program
{
    static void Main()
    {
        BinaryTree<int> binaryTree = new BinaryTree<int>();

        while (true)
        {
            Console.WriteLine("\t\tBINARY TREE OPERATIONS");
            Console.WriteLine("\t1. Insert Node");
            Console.WriteLine("\t2. Search Node");
            Console.WriteLine("\t3. Remove Node");
            Console.WriteLine("\t4. Inorder Traversal");
            Console.WriteLine("\t5. Postorder Traversal");
            Console.WriteLine("\t6. Exit\n");
            Console.Write("\tEnter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("\tEnter the value to insert: ");
                        if (int.TryParse(Console.ReadLine(), out int insertValue))
                        {
                            binaryTree.Insert(insertValue);
                            Console.WriteLine($"\tsuccefully inserted {insertValue} into the tree!.");
                        }
                        else
                        {
                            Console.WriteLine("\tInvalid input. Please enter a valid integer.");
                        }
                        break;

                    case 2:
                        Console.Write("\tEnter the value to search: ");
                        if (int.TryParse(Console.ReadLine(), out int searchValue))
                        {
                            Node<int> searchNode;
                            Node<int> parentNode;
                            Node<int> leftNode;
                            Node<int> rightNode;

                            if (binaryTree.Search(searchValue, out searchNode, out parentNode, out leftNode, out rightNode))
                            {
                                Console.WriteLine($"\t{searchValue} found in the tree.");
                                binaryTree.PrintNodeInfo(searchNode);

                                if (parentNode != null)
                                {
                                    Console.WriteLine($"\tParent of {searchValue}: {parentNode.Data}");
                                }
                                else
                                {
                                    Console.WriteLine($"\t{searchValue} is the root node.");
                                }

                                if (leftNode != null)
                                {
                                    Console.WriteLine($"\tLeft Child of {searchValue}: {leftNode.Data}");
                                }
                                else
                                {
                                    Console.WriteLine($"\t{searchValue} does not have a left Node.");
                                }

                                if (rightNode != null)
                                {
                                    Console.WriteLine($"\tRight Child of {searchValue}: {rightNode.Data}");
                                }
                                else
                                {
                                    Console.WriteLine($"\t{searchValue} does not have a right Node.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"\t{searchValue} not found in the tree.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\tInvalid input. Please enter a valid integer.");
                        }
                        break;

                    case 3:
                      Console.Write("\tEnter the value to remove: ");
                       if (int.TryParse(Console.ReadLine(), out int removeValue))
                          {
                              if (binaryTree.Search(removeValue, out _, out _, out _, out _))
                                 {
                                binaryTree.Remove(removeValue);
                                Console.WriteLine($"\t{removeValue} removed from the tree.");
                              }
                             else
                              {
                                Console.WriteLine($"\t{removeValue} does not exist ");
                             }
                         }
                      else
                        {
                          Console.WriteLine("\tInvalid input. Please enter a valid integer.");
                        }
                        break;

                    case 4:
                        binaryTree.InOrderTraversal();
                        break;

                    case 5:
                        binaryTree.PostOrderTraversal();
                        break;

                    case 6:
                        Console.WriteLine("\n\tBye Bye!!.");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\tInvalid choice. Please enter a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\tInvalid input. Please enter a valid integer.");
            }

            Console.WriteLine(); // Add a newline for better readability
        }
    }
}
}