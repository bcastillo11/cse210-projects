public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();


    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        ParseTextToWords(text);
    }

    public Scripture() => _reference = null;

    private void ParseTextToWords(string text)
    {
        _words.Clear();
        foreach (string w in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            Word word = new Word(w);
            _words.Add(word);
        }
    }

    public bool IsCompletelyHidden()
    {

        int counter = 0;
        foreach (Word w in _words)
        {
            if (w.IsHidden())
            {
                counter += 1;
            }
        }

        return counter == _words.Count;
    }

    public string GetDisplayText()
    {
        string text = $"{_reference.GetTextDisplay()}    ";

        foreach (Word w in _words)
        {
            text += $"{w.GetDisplayText()} ";
        }

        return text;
    }

    public void HideRandomWords(int quant)
    {
        Random random = new Random();

        if (IsCompletelyHidden()) return;

        if (quant <= 0) return;

        int visibleCount = _words.Count(w => !w.IsHidden());
        int toHide = Math.Min(quant, visibleCount);

        for (int i = 0; i < toHide; i++)
        {
            int pos;
            int attempts = 0;

            // Look for one word that is not hidden
            do
            {
                pos = random.Next(0, _words.Count);
                attempts++;

                if (attempts > _words.Count * 2) break;
            } while (_words[pos].IsHidden());


            if (!_words[pos].IsHidden())
            {
                _words[pos].Hide();

            }
        }
    }
}