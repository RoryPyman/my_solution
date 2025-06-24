using CommandLine;
class Parameters {
    [Option('n', "numbers", Required = false, HelpText = "Specify which rules to enable as a comma seperated list")]
    public string numbers { get; set; }
    [Option('f', "factor", Required = false, HelpText = "Specify the factor whose multiples should have a new rule applied")]
    public int factor { get; set; }
    [Option('w', "word", Required = false, HelpText = "The word which should be inserted when a multiple of the factor (use in conjunction with -f)")]
    public string word { get; set; }
    [Option('e', "end", Required = false, HelpText = "Set this flag if the word should appear at the end of the word (defaults to the start)")]
    public bool end { get; set; }


}