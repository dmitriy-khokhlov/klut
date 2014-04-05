using Klut.Parsing;
using Klut.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klut
{
    class CodeSaver
    {

        public ParseStream InputStream { public get; private set; }

        public string OutputFilePath { get; set; }

        public CodeSaver() {}

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
