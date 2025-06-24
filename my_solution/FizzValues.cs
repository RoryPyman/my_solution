using System.Collections;

public class FizzValue {
    public FizzValue(int index, string value) {
        this.index = index;
        this.value = value;
    }
    public int index;
    public string value;
}

class FizzValues : IEnumerable {
    private int[] reservedNumbers = new int[6] { 3, 5, 7, 11, 13, 17 };
    private int[] numbers;
    private bool rule_present = false;
    private int factor;
    private string word;
    private bool end;
    public FizzValues(Parameters args) {
        this.numbers = args.numbers != null ? Array.ConvertAll(args.numbers.Split(","), s => int.Parse(s)) : new int[0];

        if (args.word != null && args.factor != 0 && !reservedNumbers.Contains(args.factor)) {
            rule_present = true;
            this.factor = args.factor;
            this.word = args.word;
            this.end = args.end;
        }
    }


    public IEnumerator GetEnumerator() {
        return new FizzValuesEnum(numbers, rule_present, word, factor, end);
    }
}


public class FizzValuesEnum : IEnumerator {
    private int next_val = 0;
    private int[] numbers;
    private bool rule_present = false;
    private int factor;
    private string word;
    private bool end;

    public FizzValuesEnum(int[] numbers, bool rule_present, string word, int factor, bool end) {
        this.numbers = numbers;
        this.rule_present = rule_present;
        this.word = word;
        this.factor = factor;
        this.end = end;
    }

    public void Reset() {
        next_val = 1;
    }
    public bool MoveNext() {
        next_val++;
        return true;
    }


    public object Current {
        get {
            return new FizzValue(next_val, findval(next_val));
        }
    }
    public string findval(int i) {
        List<string> word_list = new List<string>();

        if (i % 11 == 0 && (numbers.Contains(11) || numbers.Count() == 0)) {
            word_list.Add("Bong");
        }
        else {
            if (i % 3 == 0) {
                if (numbers.Count() == 0 || numbers.Contains(3)) word_list.Add("Fizz");
            }
            if (i % 5 == 0) {
                if (numbers.Count() == 0 || numbers.Contains(5)) word_list.Add("Buzz");
            }
            if (i % 7 == 0) {
                if (numbers.Count() == 0 || numbers.Contains(7)) word_list.Add("Bang");
            }
        }

        // Handle special 13 case
        if (i % 13 == 0 && (numbers.Count() == 0 || numbers.Contains(13))) {
            if (word_list.Count == 0) {
                word_list.Add("Fezz");
            }
            else {
                bool found = false;
                // Loop through words, find first with B, insert before, else insert at end
                for (int j = 0; j < word_list.Count; j++) {
                    if (word_list[j].StartsWith("B")) {
                        word_list.Insert(j, "Fezz");
                        found = true;
                        break;
                    }
                }
                if (!found) {
                    word_list.Add("Fezz");
                }
            }
        }

        // Handle custom rule
        if (rule_present && i % factor == 0) {
            if (end) {
                word_list.Add(word);
            }
            else {
                word_list.Insert(0, word);
            }
        }
        if ((numbers.Count() == 0 || numbers.Contains(17)) && i % 17 == 0) {
            word_list.Reverse();
        }

        return word_list.Count == 0 ? i.ToString() : string.Join("", word_list);

    }
}
