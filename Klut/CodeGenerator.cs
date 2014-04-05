using Klut.Parsing;
using Klut.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klut
{
    class CodeGenerator
    {
        public ParseStream InputStream { public get; private set; }

        public CodeStream OutputStream { public get; private set; }

        public CodeGenerator( ParseStream inputStream )
        {
            InputStream = inputStream;
            InputStream.OnItemAdded += handleNewInput;
            OutputStream = new CodeStream();
        }

        private void handleNewInput( int count )
        {
            for ( ; count > 0; count-- )
            {
                ParseTree inputTree = InputStream.Receive();

                // todo: implement handleNewInput
            }
        }
    }
}
