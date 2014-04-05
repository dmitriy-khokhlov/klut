using Klut.Parsing;
using Klut.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klut
{
    class Semanter
    {
        public ParseStream InputStream { public get; private set; }

        public ParseStream OutputStream { public get; private set; }

        public Semanter( ParseStream inputStream )
        {
            InputStream = inputStream;
            InputStream.OnItemAdded += handleNewInput;
            OutputStream = new ParseStream();
        }

        private void handleNewInput( int count )
        {
            for ( ; count > 0; count-- )
            {
                OutputStream.Send( InputStream.Receive() );
            }
        }
    }
}
