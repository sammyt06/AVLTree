class AVLTree<T> : BSTree<T> where T : IComparable
{
    public new void InsertItem(T item)
    {
        InsertItem(item, ref root);
    }

    private void InsertItem(T item, ref Node<T> tree)
    {
        if (tree == null)
        {
            tree = new Node<T>(item);
            return;
        }

        if (item.CompareTo(tree.Data) < 0)
        {
            InsertItem(item, ref tree.Left);
        } else if (item.CompareTo(tree.Data) > 0) {
            InsertItem(item, ref tree.Right);
        } else
        {
            return; //No duplicates
        }

        tree.BalanceFactor = Height(tree.Left) - Height(tree.Right);

        if (tree.BalanceFactor <= -2)
        {
            RotateLeft(ref tree);
        }
        if (tree.BalanceFactor >= 2)
        {
            RotateRight(ref tree);
        }


    }

    public void RotateLeft(ref Node<T> tree)
    {

        if (tree.Right.BalanceFactor > 0)
        {
            RotateRight(ref tree.Right);
        }

        Node<T> oldRoot = tree;
        Node<T> newRoot = tree.Right;

        oldRoot.Right = newRoot.Left;
        newRoot.Left = oldRoot;

        tree = newRoot;

    }

    public void RotateRight(ref Node<T> tree)
    {

        if (tree.Left.BalanceFactor < 0)
        {
            RotateLeft(ref tree.Left);
        }

        Node<T> oldRoot = tree;
        Node<T> newRoot = tree.Left;

        oldRoot.Left = newRoot.Right;
        newRoot.Right = oldRoot;

        tree = newRoot;

    }

    public T GetRoot()
    {
        return root.Data;
    }



}