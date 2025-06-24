using CommandLine;

public class Program {
    static void Main(string[] args) {
        FizzValues fizzValues;
        Parser.Default.ParseArguments<Parameters>(args)
            .WithParsed(o => {
                if (o.numbers != null) fizzValues = new FizzValues(o.numbers);
                else fizzValues = new FizzValues();
                int i = 0;
                foreach (FizzValue val in fizzValues) {
                    Console.WriteLine("Good Morning " + val.value);
                    if (i >= 1000) {
                        break;
                    }
                    i++;
                }

            });

    }
}