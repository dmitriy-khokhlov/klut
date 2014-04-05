using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klut.Streams
{
    class Stream<T>
    {
        public delegate void ItemsAddedHandler( Stream<T> sender, int count );

        private Queue<T> queue = new Queue<T>();

        private ItemsAddedHandler onItemAdded;

        public void Send( T item ) {
            queue.Enqueue( item );
            onItemAdded( this, 1 );
        }

        public T Receive() {
            return queue.Dequeue();
        }

        public event ItemsAddedHandler OnItemAdded {
            add { onItemAdded += value; }
            remove { onItemAdded -= value; }
        }
    }
}
