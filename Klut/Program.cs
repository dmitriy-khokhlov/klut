using Klut.Pipeline;

namespace Klut
{
    class Program
    {
        private static void Main( string[] args )
        {
            var textProvider = new TextProvider();
            var codeSaver =
                new CodeSaver(
                    new CodeGenerator(
                        new Optimizer(
                            new Semanter(
                                new Parser(
                                    new Lexer(
                                        textProvider.OutputStream
                                        ).OutputStream
                                    ).OutputStream
                                ).OutputStream
                            ).OutputStream
                        ).OutputStream
                    );
            textProvider.ReadFile( "aoe" );
        }
    }
}
