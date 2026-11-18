class Program
{
    public static void Main()
    {
        AVLTree<int> tree = new AVLTree<int>();

        foreach (int value in new[] { 25, 15, 10, 20, 23, 17 })
        {
            tree.InsertItem(value);
        }

        Console.WriteLine(tree.InOrder());
        Console.WriteLine(tree.GetRoot());


    }
}