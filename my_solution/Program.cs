
class Program {

    static void Main(string[] args) {
        int max = 100;
        if (args.Count() > 0) {
            if (!int.TryParse(args[0], out max)) {
                return;
            }
        }

        List<string> res = new List<string>();

        for (int i = 0; i <= max; i++) {
            if (i % 11 == 0) {
                res.Add("Bong");
            }
            else {
                if (i % 3 == 0) {
                    res.Add("Fizz");
                }
                if (i % 5 == 0) {
                    res.Add("Buzz");
                }
                if (i % 7 == 0) {
                    res.Add("Bang");
                }
            }

            // Handle special 13 case
            if (i % 13 == 0) {
                if (res.Count == 0) {
                    res.Add("Fezz");
                }
                else {
                    bool found = false;
                    // Loop through words, find first with B, insert before, else insert at end
                    for (int j = 0; j < res.Count; j++) {
                        if (res[j].StartsWith("B")) {
                            res.Insert(j, "Fezz");
                            found = true;
                            break;
                        }
                    }
                    if (!found) {
                        res.Add("Fezz");
                    }
                }
            }

            // Reverse if 17
            if (i % 17 == 0) {
                res.Reverse();
            }

            Console.WriteLine($"{i}: {(res.Count == 0 ? i : string.Join("", res))}");
            res.Clear();

        }
    }
}