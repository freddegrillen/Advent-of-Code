// See https://aka.ms/new-console-template for more information

int current = 50;
int zeroCount = 0;

string input = Console.ReadLine();

while (input != "")
{
    var change = int.Parse(input.Substring(1));
    int fullRounds = (change - (change % 100)) / 100;
    zeroCount += fullRounds;

    change = change % 100;

    if (input[0] == 'L')
    {
        if (change >= current && current != 0)
        {
            zeroCount++;

        }
        current -= change;
    }
    else
    {
        if(change + current > 99)
        {
            zeroCount++;
        }
        current += change;
    }
    AdaptCurrent();
    if(current == 0)
    {
        //zeroCount++;
        //Console.WriteLine($"zerocount is {zeroCount}. input: {input}");
    }
    Console.WriteLine($"Current: {current} - Zerocount: {zeroCount}");
    input = Console.ReadLine();
}

Console.WriteLine($"Final Zerocount: {zeroCount}");
Console.ReadLine();

void AdaptCurrent()
{
    if (current > 99)
    {
        current = current % 100;
    }
    if(current < 0)
    {
        current += 100;
    }

}
