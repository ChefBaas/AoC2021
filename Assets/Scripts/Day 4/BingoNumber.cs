public class BingoNumber
{
    private string number;
    private bool crossed = false;

    public BingoNumber(string number)
    {
        this.number = number;
    }

    public void CrossNumber()
    {
        crossed = true;
    }

    public string GetNumber()
    {
        return number;
    }

    public bool GetCrossed()
    {
        return crossed;
    }
}