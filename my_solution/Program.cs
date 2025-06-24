using CommandLine;

public class Program {
    static void Main(string[] args) {
        FizzValues fizzValues;
        Parser.Default.ParseArguments<Parameters>(args)
            .WithParsed(o => {
                fizzValues = new FizzValues(o);
                int i = 0;
                foreach (FizzValue val in fizzValues) {
                    Console.WriteLine(val.value);
                    if (i >= 10) {
                        break;
                    }
                    i++;
                }

            });

    }
}