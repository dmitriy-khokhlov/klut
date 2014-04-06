using System.Collections.Generic;

namespace Klut.Streams
{
    class Stream<T>
    {
        public delegate void ItemsAddedHandler( int count );

        private Queue<T> _queue = new Queue<T>();

        private ItemsAddedHandler _onItemAdded;

        public void Send( T item )
        {
            _queue.Enqueue( item );
            _onItemAdded( 1 );
        }

        public T Receive()
        {
            return _queue.Dequeue();
        }

        public event ItemsAddedHandler OnItemAdded
        {
            add { _onItemAdded += value; }
            remove { _onItemAdded -= value; }
        }
    }
}
