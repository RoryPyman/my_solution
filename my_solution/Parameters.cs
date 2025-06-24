using CommandLine;
class Parameters {
    [Option('n', "numbers", Required = false, HelpText = "Specify which rules to enable as a comma seperated list")]
    public string numbers { get; set; }
}