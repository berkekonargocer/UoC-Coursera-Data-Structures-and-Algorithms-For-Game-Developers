namespace Nojumpo.Collections
{
    public class UnsortedLinkedList<T> : LinkedList<T>
    {
        // ------------------------- CUSTOM PUBLIC METHODS -------------------------
        public override void Add(T item) {
            if (_head == null)
            {
                _head = new LinkedListNode<T>(item, null, null);
            }
            else
            {
                _head = new LinkedListNode<T>(item, null,_head);
            }

            _count++;
        }
    }
}