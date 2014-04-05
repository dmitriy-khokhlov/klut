using Klut.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klut
{
    class Lexer
    {
        public TextStream InputStream { public get; private set; }

        public TokenStream OutputStream { public get; private set; }

        public Lexer( TextStream inputStream )
        {
            InputStream = inputStream;
            InputStream.OnItemAdded += handleNewInput;
            OutputStream = new TokenStream();
        }

        private void handleNewInput( int count )
        {
            for ( ; count > 0; count-- )
            {
                char inputChar = InputStream.Receive();

                //todo: implement handleNewInput
            }
        }
    }
}
