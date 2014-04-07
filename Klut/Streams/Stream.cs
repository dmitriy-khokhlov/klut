using System;
using System.Collections.Generic;

namespace Klut.Streams
{
    class Stream<T>
    {
        public class ItemsAddedEventArgs
        {
            public int Count { get; set; }

            public ItemsAddedEventArgs( int count )
            {
                Count = count;
            }
        }

        private Queue<T> _queue = new Queue<T>();

        public void Send( T item )
        {
            _queue.Enqueue( item );
            ItemsAdded( this, new ItemsAddedEventArgs( 1 ) );
        }

        public T Receive()
        {
            return _queue.Dequeue();
        }

        public event EventHandler<ItemsAddedEventArgs> ItemsAdded = delegate {};
    }
}
