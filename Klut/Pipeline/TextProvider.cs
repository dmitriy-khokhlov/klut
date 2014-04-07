using System;
using Klut.Streams;

namespace Klut.Pipeline
{
    class TextProvider
    {
        public TextStream OutputStream { get; private set; }

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
            // todo: temporary fake implementation, rewrite
            const string fileContents = "print( \"Hello, World!\" );\n";
            foreach ( var c in fileContents )
            {
                OutputStream.Send( c );
            }
        }
    }
}
