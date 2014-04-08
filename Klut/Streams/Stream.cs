using System;
using System.Collections.Generic;

namespace Klut.Streams
{
    class Stream<T>
    {
        private readonly Queue<T> _queue = new Queue<T>();

        public void Send( T item )
        {
            _queue.Enqueue( item );
            ItemsAdded( this, new ItemsAddedEventArgs( 1 ) );
        }

        public void SendEndOfStream()
        {
            EndOfStreamReceived( this, new EndOfStreamReceivedEventArgs() );
        }

        public T Receive()
        {
            return _queue.Dequeue();
        }

        public event EventHandler<ItemsAddedEventArgs> ItemsAdded = delegate {};

        public event EventHandler<EndOfStreamReceivedEventArgs>
            EndOfStreamReceived = delegate { };

        public class ItemsAddedEventArgs
        {
            public int Count { get; set; }

            public ItemsAddedEventArgs( int count )
            {
                Count = count;
            }
        }

        public class EndOfStreamReceivedEventArgs
        {            
        }
    }
}
