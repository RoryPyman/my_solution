using System;
using System.Collections;
using System.Globalization;

public class FizzValue {
    public FizzValue(int index, string value) {
        this.index = index;
        this.value = value;
    }
    public int index;
    public string value;
}

class FizzValues : IEnumerable {
    private int[] numbers;
    public FizzValues(string numbers) {
        this.numbers = Array.ConvertAll(numbers.Split(","), s => int.Parse(s));
    }

    public FizzValues() {
        this.numbers = new int[0];
    }


    public IEnumerator GetEnumerator() {
        return new FizzValuesEnum(numbers);
    }
}


public class FizzValuesEnum : IEnumerator {
    private int next_val = 1;
    private int[] numbers;

    public FizzValuesEnum(int[] numbers) {
        this.numbers = numbers;
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
    string findval(int i) {
        List<string> word_list = new List<string>();

        if (i % 11 == 0) {
            if (numbers.Contains(11) || numbers.Count() == 0) word_list.Add("Bong");
        }
        else {
            if (i % 3 == 0) {
                if (numbers.Count() == 0 || numbers.Contains(3)) word_list.Add("Fizz");
            }
            if (i % 5 == 0) {
                if (numbers.Count() == 0 || numbers.Contains(5))word_list.Add("Buzz");
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

        if ((numbers.Count() == 0 || numbers.Contains(17)) && i % 17 == 0) {
            word_list.Reverse();
        }

        return word_list.Count == 0 ? i.ToString() : string.Join("", word_list);

    }
}
