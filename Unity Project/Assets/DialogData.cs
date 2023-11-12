

public class DialogNode
{
    private readonly string text;
    private readonly string speaker;
    private readonly DialogOption[] dialogOptions;

    public DialogNode(string text, string speaker, DialogOption[] options)
    {
        this.text = text;
        this.speaker = speaker;
        this.dialogOptions = options;
    }

    public DialogNode(string text, string speaker) : this(text, speaker, new DialogOption[0]) { }

    public string getText() { return text; }
    public string getSpeaker() { return speaker; }
    public DialogOption[] getDialogOptions() { return dialogOptions; }
}

public class DialogOption
{
    private readonly string text;

    private readonly DialogNode nextNode;

    public DialogOption(string text, DialogNode nextNode)
    {
        this.text = text;
        this.nextNode = nextNode;
    }

    public DialogOption(string text) : this(text, null) { }

    public string getText() { return text; }
    public DialogNode getNextNode() { return nextNode; }
}