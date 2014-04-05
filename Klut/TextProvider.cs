using Klut.Streams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klut
{
    class TextProvider
    {
        public TextStream OutputStream { public get; private set; }

        public TextProvider()
        {
            OutputStream = new TextStream();
        }

        public TextProvider( TextStream outputStream )
        {
            OutputStream = outputStream;
        }

        public void ReadFile( String filePath )
        {
            //todo: implement ReadFile as it should be
            string fileContents = "print( \"Hello, World!\" );\n";
            foreach ( char c in fileContents )
            {
                OutputStream.Send( c );
            }
        }
    }
}
