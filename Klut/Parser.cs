using Klut.Streams;
using Klut.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klut
{
    class Parser
    {
        public TokenStream InputStream { public get; private set; }

        public ParseStream OutputStream { public get; private set; }

        public Parser( TokenStream inputStream )
        {
            InputStream = inputStream;
            InputStream.OnItemAdded += handleNewInput;
            OutputStream = new ParseStream();
        }

        private void handleNewInput( int count )
        {
            for ( ; count > 0; count-- )
            {
                Token inputToken = InputStream.Receive();

                //todo: implement handleNewInput
            }
        }
    }
}
